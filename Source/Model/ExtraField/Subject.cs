using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.POCO {
    public partial class Subject {
        public string SubjectNoName {
            get {
                return string.Format("{0}: {1}", SubjectNo, Name);
            }
        }
    }
}
