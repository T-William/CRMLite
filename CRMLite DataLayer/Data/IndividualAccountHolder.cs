using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMLite_DataLayer.Data
{
    public class IndividualAccountHolder
    {

        public long Id { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedDateTime { get; set; }
        [MaxLength(50)]
        public string Title { get; set; }
        public int Gender { get; set; }
        public long? AccountHolderId { get; set; }
        public AccountHolder AccountHolder { get; set; }
        public DateTime DateOfBirth { get; set; }
        [MaxLength(100)]
        public string Surname { get; set; }

        public DateTime CreatedDateTime { get; set; }

    }

}
