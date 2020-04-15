using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMLite_DataLayer.Data
{
    public class Address
    {
        public long Id { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedDateTime { get; set; }
        public long AccountHolderId { get; set; }
        public AccountHolder AccountHolder { get; set; }
        public int AddressTypeId { get; set; }
        [MaxLength(100)]
        public string Description { get; set; }
        [MaxLength(100)]
        public string AddressLine1 { get; set; }
        [MaxLength(100)]
        public string AddressLine2 { get; set; }
        [MaxLength(100)]
        public string AddressLine3 { get; set; }
        [MaxLength(50)]
        public string Locality { get; set; }
        [MaxLength(50)]
        public string Region { get; set; }
        [MaxLength(50)]
        public string Country { get; set; }
        [MaxLength(20)]
        public string PostalCode { get; set; }
        public DateTime CreatedDateTime { get; set; }

    }

}
