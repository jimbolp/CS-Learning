
using System.ComponentModel;
using System.Security;

namespace UserAccounts
{
    public class CustomKSCUser
    {
        public int UserID { get; set; }
        [DisplayName("Име Фамилия")]
        public string UserName { get; set; }
        [DisplayName("KSC Потребител")]
        public string KSCUserName { get; set; }
        public string TermID { get; set; }
        public int UID { get; set; }
        [DisplayName("FC поръчки")]
        public string AllowFC { get; set; }
        [DisplayName("Склад")]
        public string Branch { get; set; }
    }
}
