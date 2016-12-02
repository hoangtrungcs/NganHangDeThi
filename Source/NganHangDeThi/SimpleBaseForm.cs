using Controller.Interfaces;
using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using Telerik.WinControls;

namespace NganHangDeThi {
    public class SimpleBaseForm<T, TService> : BaseForm
        where T : BaseEntity, new()
        where TService : IService<T>, new() {

        #region Fields

        private bool m_isSaving = false;
        protected BindingSource BindingSource { get; set; }
        public T CurrentEntity { get { return BindingSource != null ? BindingSource.Current as T : null; } }
        public List<T> EntitiesCollection { get; set; }
        protected TService Service { get; private set; }

        #endregion Fields
        
        #region Constructors
        
        public SimpleBaseForm() {
            InitializeComponent();
            Service = new TService();
            this.Load += SimpleBaseFormLoad;
        }

        void SimpleBaseFormLoad(object sender, EventArgs e) {
            InternalLoadData();
            BindingSource = new BindingSource();
            BindingSource.DataSource = EntitiesCollection;
            BindingSource.CurrentItemChanged += SelectedEntityChanged;
            SetBindingSource();
            SetDetailBindingSource();
            RegisterEntityChanged();
            LoadSecurityStatus();
            NotifyStateChanged();
        }
        
        #endregion Constructors

        #region Methods
        void SelectedEntityChanged(object sender, EventArgs e) {
            RegisterEntityChanged();
        }

        private void RegisterEntityChanged() {
            if (CurrentEntity != null) {
                if (!CurrentEntity.HasChanged) {
                    CurrentEntity.AcceptChanged();
                }
                CurrentEntity.PropertyChanged += EntityChanged;
            }
        }

        private void EntityChanged(object sender, PropertyChangedEventArgs e) {
            if (!m_isSaving) {
                IsDirty = true;
                LoadSecurityStatus();
                NotifyStateChanged();    
            }
        }
        public override void Save() {
            m_isSaving = true;
            IsDirty = false;
            List<T> entities = EntitiesCollection.Where(x => x.HasChanged || x.IsAddNew).ToList();
            entities.ForEach(x => {
                x.AcceptChanged();
                x.IsAddNew = false;
            });
            
            Service.SaveAll(entities);
            m_isSaving = false;
            IsDirty = false;
            LoadSecurityStatus();
            NotifyStateChanged();
        }
        public override void Add() {
            var item = InternalCreateNew();
            IsDirty = true;
            item.IsAddNew = true;
            item.AcceptChanged();
            BindingSource.Add(item);
            BindingSource.ResetBindings(true);
            BindingSource.MoveLast();
        }
        protected virtual T InternalCreateNew() {
            return new T(){IsAddNew =  true};
        }

        public override void Cancel() {
            EntitiesCollection.RemoveAll(x => x.IsAddNew);
            EntitiesCollection.ForEach(x => { if (x.HasChanged) { x.CancelEdit(); } });
            IsDirty = false;
            BindingSource.ResetBindings(true);
            BindingSource.DataSource = EntitiesCollection;
            NotifyStateChanged();
        }
        public override void Delete() {
            if (CurrentEntity == null) return;
            if (MessageBox.Show("Bạn muốn xóa record này?", "Confirmation", MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question) == DialogResult.Yes) {
                T curent = CurrentEntity;
                EntitiesCollection.Remove(CurrentEntity);
                BindingSource.DataSource = EntitiesCollection;
                BindingSource.MoveFirst();
                BindingSource.ResetBindings(true);
                if (!curent.IsAddNew) {
                    Service.Delete(curent);
                    
                }
                IsDirty = EntitiesCollection.Any(x => x.HasChanged || x.IsAddNew);
            }
        }
        protected virtual void InternalLoadData() {
            EntitiesCollection = Service.GetAll();
        }
        protected virtual void SetDetailBindingSource() {

        }
        protected virtual void SetBindingSource() {

        }
        public override void Edit() {

        }
        protected override void OnClosing(CancelEventArgs e) {
            if (EntitiesCollection != null &&  EntitiesCollection.Any(x => x.HasChanged)) {
                if (RadMessageBox.Show("Bạn có muốn lưu những thay đổi không?", "Confirmation", MessageBoxButtons.YesNo) ==
                    DialogResult.Yes) {
                    Service.SaveAll(EntitiesCollection.Where(x => x.HasChanged));
                }
            }
            base.OnClosing(e);
        }
        #endregion Methods

        private void InitializeComponent() {
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // SimpleBaseForm
            // 
            this.ClientSize = new System.Drawing.Size(372, 312);
            this.Name = "SimpleBaseForm";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }
    }
}
