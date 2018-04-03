using System.ComponentModel;

namespace UserAccounts
{
    class CustomUser 
    {
        [DisplayName("�")]
        public int ID { get; set; }
        [DisplayName("��� �� ����������")]
        public string UserName { get; set; }
        public string Email { get; set; }
        [DisplayName("������� ����������")]
        public string ActiveDirectory { get; set; }
        [DisplayName("��������")]
        public string Position { get; set; }
        [DisplayName("�����")]
        public string Depo { get; set; }
        [DisplayName("������ ������")]
        public string PharmosUserName { get; set; }
        [DisplayName("������ � UADM")]
        public string UADMUserName { get; set; }
        [DisplayName("������ �� GoodsIn")]
        public string GoodsIn { get; set; }
        [DisplayName("������ �� Purchase")]
        public string PurchaseAccount { get; set; }
        [DisplayName("������ �� Tender")]
        public string TenderAccount { get; set; }
        [DisplayName("������ �� �����")]
        public string PhibraAccount { get; set; }
        [DisplayName("KSC ������")]
        public string KSCAccount { get; set; }
        [DisplayName("������")]
        public string State { get; set; }
        [DisplayName("���. ����������")]
        public string Description { get; set; }
    }
}