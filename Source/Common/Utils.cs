using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class DbHelper {
        static DbHelper() {
            ConnectionString = LocalConnectionString;
        }
        private DbHelper() {
            
        }
        public static string ConnectionString { get; set; }
        public const string ServerConnectionString = "name=NganHangEntities";
        public const string LocalConnectionString = "name=LocalNganHangEntities";


    }
    public class QuestionLevelDisplay
    {
        public string DisplayMember { get; set; }
        public int ValueMember { get; set; }
    }

    public class PurposeOverviewDisplay
    {
        public string DisplayMember { get; set; }
        public int ValueMember { get; set; }
    }
    
}
