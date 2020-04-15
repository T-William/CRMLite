using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMLite_DataLayer.Data
{
    public class Account
    {
        public long Id { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedDateTime { get; set; }
        [MaxLength(10)]
        public string AccountNumber { get; set; }

        public long? AccountHolderId { get; set; }
        public AccountHolder AccountHolder { get; set; }
        public DateTime CreatedDateTime { get; set; }

    }

}
