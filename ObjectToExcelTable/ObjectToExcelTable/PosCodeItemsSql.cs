using System;
using System.Collections.Generic;
using System.Linq;
//using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ObjectToExcelTable
{
    public class PosCodeItemsSql
    {
        [DisplayName("Експорт")]
        public string Caption { get; set; }

        public List<PosCodeItemSql> items { get; set; }

        public PosCodeItemsSql(bool emptyClass)
        {
            items = new List<PosCodeItemSql>();
            Caption = "Позиционни кодове с артикули"; 
        }
    }

    public class PosCodeItemSql
    {

        [DisplayName("Склад")]
        public string StoreName { get; set; }

        [DisplayName("Позиционен код")]
        public string PosCodeName { get; set; }

        [DisplayName("PalletID")]
        public int? PalletID { get; set; }

        [DisplayName("ArticleID")]
        public int? ArticleID { get; set; }

        [DisplayName("Производител")]
        public string Producer { get; set; }

        [DisplayName("Артикул")]
        public string ArticleName { get; set; }

        [DisplayName("Партида")]
        public string ParcelNo { get; set; }

        [DisplayName("Срок на годност")]
        [DisplayFormat(DataFormatString = "MM.yyyy")]
        public DateTime? ExpiryDate { get; set; }

        [DisplayName("К-во")]
        public int? Qty { get; set; }

    }
}
