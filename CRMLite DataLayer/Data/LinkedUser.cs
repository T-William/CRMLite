using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMLite_DataLayer.Data
{
    public class LinkedUser
    {
        public long Id { get; set; }

        [ForeignKey("AccountHolder")]
        public long RecipientId { get; set; }
        public AccountHolder AccountHolder { get; set; }

        [MaxLength(10)]
        public string UserId { get; set; }

        [MaxLength(100)]
        public string AccountIdWithRecipient { get; set; }

        public bool IsDeleted { get; set; }
        public DateTime? DeletedDateTime { get; set; }

        public DateTime CreatedDateTime { get; set; }

    }

}
