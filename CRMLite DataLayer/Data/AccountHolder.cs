using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMLite_DataLayer.Data
{
    public class AccountHolder
    {
        public long Id { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedDateTime { get; set; }
        [MaxLength(10)]
        public string UserId { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }

        public int StatusId { get; set; }
        public int KycLevel { get; set; }
        public DateTime CreatedDateTime { get; set; }

    }

}
