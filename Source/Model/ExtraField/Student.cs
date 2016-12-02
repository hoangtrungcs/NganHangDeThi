using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.POCO {
    public partial class Student {
        public string FullName {
            get { return (LastName +" "+ FirstName); }
        }
        public bool Checked { get; set; }
    }
}
