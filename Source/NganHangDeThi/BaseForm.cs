using Common;
using System;
namespace NganHangDeThi {
    public class BaseForm : Telerik.WinControls.UI.RadForm, IForm {
        public bool IsActive { get; set; }

        public FormAction CurrentAction { get; set; }

        public virtual void Save() { }

        public virtual void Add() { }

        public virtual void Edit() { }

        public virtual void Cancel() { }

        public virtual void Delete() { }

        public bool IsDirty { get; set; }
        protected void NotifyStateChanged() {
            if (ActionStateChanged != null) {
                ActionStateChanged(this, EventArgs.Empty);
            }
        }
        public event System.EventHandler ActionStateChanged;

        public bool CanCreate { get; set; }

        public bool CanDelete {
            get;
            set;
        }

        public bool CanEdit { get; set; }

        public virtual void LoadSecurityStatus() {
            CanCreate = true;
            CanDelete = true;
            CanEdit = true;
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BaseForm));
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // BaseForm
            // 
            this.ClientSize = new System.Drawing.Size(292, 266);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "BaseForm";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }
    }
}
