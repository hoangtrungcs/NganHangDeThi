using System;
using System.ComponentModel;

namespace Model {
    public class BaseEntity : INotifyPropertyChanged {
        public event PropertyChangedEventHandler PropertyChanged;
        private BaseEntity m_originEntity;
        public bool IsAddNew { get; set; }
        public bool HasChanged { get; set; }

        protected void NotifyPropertyChanged(string name) {
            if (PropertyChanged != null) {
                HasChanged = true;
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }


        protected virtual void CopyFromEntity(BaseEntity source, BaseEntity dest) {
            // NOP override in each chil
        }

        public void AcceptChanged() {
            m_originEntity = m_originEntity?? (BaseEntity)Activator.CreateInstance(this.GetType());
            CopyFromEntity(this, m_originEntity);
            HasChanged = false;
        }

        public void CancelEdit() {
            CopyFromEntity(m_originEntity, this);
            HasChanged = false;
        }
    }
}
