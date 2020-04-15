using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMLite_DataLayer.Data
{
    public class Contact
    {
        public long Id { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedDateTime { get; set; }

        public long? AccountHolderId { get; set; }
        public AccountHolder AccountHolder { get; set; }
        [MaxLength(50)]
        public string Value { get; set; }

        public int ContactTypeId { get; set; }
        public DateTime CreatedDateTime { get; set; }

    }

}
