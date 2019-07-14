using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    public class Lead
    {
        public int LeadId { get; set; }
        public string Title { get; set; }

        public ICollection<Contract> Contracts { get; set; }
        public ICollection<Company> Companies { get; set; }
    }


    public class Company
    {
        public int CompanyId { get; set; }
        public string Title { get; set; }

        public ICollection<Lead> Leads { get; set; }
    }

    public class Site
    {
        public int SiteId { get; set; }
        public string Address { get; set; }
        public Meter Meter { get; set; }
    }

    public class Meter
    {
        [ForeignKey("Site")]
        public int MeterId { get; set; }
        public string MeterRef { get; set; }

        public Site Site { get; set; }
    }

    public class Contract
    {
        public int ContractId { get; set; }
        public string Title { get; set; }

        public Lead Lead { get; set; }
        public BankDetail BankDetail { get; set; }
    }

    public class BankDetail
    {
        [ForeignKey("Contract")]
        public int BankDetailId { get; set; }
        public string Title { get; set; }

        public Contract Contract { get; set; }
    }


}
