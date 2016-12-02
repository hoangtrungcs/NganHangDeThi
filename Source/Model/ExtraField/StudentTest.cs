
namespace Model.POCO {
    public partial class StudentTest {
        public string StudentName {
            get { return this.Student == null ? string.Empty : this.Student.FullName; }
        }

        public string TestName {
            get { return this.Test == null ? string.Empty : this.Test.Name; }
        }
    }
}
