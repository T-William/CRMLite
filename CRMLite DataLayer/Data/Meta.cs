using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMLite_DataLayer.Data
{
    public class Meta
    {
        public long Id { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedDateTime { get; set; }
        [MaxLength(50)]
        public string Key { get; set; }
        [MaxLength(1000)]
        public string Value { get; set; }

        public long? AccountHolderId { get; set; }
        public AccountHolder AccountHolder { get; set; }
        public DateTime CreatedDateTime { get; set; }

    }

}
