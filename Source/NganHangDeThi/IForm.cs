
using Common;
using System;
namespace NganHangDeThi {
    public interface IForm {
        event EventHandler ActionStateChanged;
        bool IsActive { get; set; }
        bool CanCreate { get; set; }
        bool CanDelete { get; set; }
        bool CanEdit { get; set; }
        FormAction CurrentAction { get; set; }
        void Save();
        void Add();
        void Edit();
        void Cancel();
        void Delete();
        void LoadSecurityStatus();
        bool IsDirty { get; }
    }
}
