using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CsvHelper.Configuration;

namespace BSBChecker.Models
{
    public class BSBData
    {

        //"012-002","ANZ","ANZ Smart Choice","115 Pitt Street","Sydney","NSW","2000","PEH"
        public string BSB { get; set; }
        public string Bank { get; set; }
        public string Branch { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Postcode { get; set; }
        public string PaymentTypeCodes { get; set; }
    }

    public sealed class BSBDataMap : CsvClassMap<BSBData>
    {
        public BSBDataMap()
        {
            Map(m => m.BSB).Index(0);
            Map(m => m.Bank).Index(1);
            Map(m => m.Branch).Index(2);
            Map(m => m.Address).Index(3);
            Map(m => m.City).Index(4);
            Map(m => m.State).Index(5);
            Map(m => m.Postcode).Index(6);
            Map(m => m.PaymentTypeCodes).Index(7);
        }
    }
}
