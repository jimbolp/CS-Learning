using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintersData
{
    class CustomPrintersTable
    {
        [DisplayName("Име на принтер")]
        public string Name { get; set; }
        [DisplayName("IP адрес")]
        public string IP { get; set; }
        [DisplayName("Склад")]
        public string Branch { get; set; }
        [DisplayName("Pharmos Print ID")]
        public string PrintID { get; set; }
        [DisplayName("DNS име")]
        public string DNSName { get; set; }
        [DisplayName("Модел")]
        public string PrinterModel { get; set; }
        [DisplayName("Описание")]
        public string Description { get; set; }
        
    }
}
