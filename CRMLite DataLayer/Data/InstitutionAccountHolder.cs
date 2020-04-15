using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMLite_DataLayer.Data
{
    public class InstitutionAccountHolder
    {

        public float Id { get; set; }
        public bool IsDelete { get; set; }
        public DateTime? DeletedDateTime { get; set; }
        public long AccountHolderId { get; set; }
        public AccountHolder AccountHolder { get; set; }
        public long ClientAccountAccountNo { get; set; }
        public int ClientAccountBranchCode { get; set; }
        [MaxLength(20)]
        public string ClientAccountType { get; set; }
        [MaxLength(50)]
        public string RegistrationNumber { get; set; }

        public DateTime CreatedDateTime { get; set; }

    }

}
