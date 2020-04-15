using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMLite_DataLayer.Data
{
    public class IdentityDocument
    {

        public long Id { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedDateTime { get; set; }
        [MaxLength(20)]
        public string Number { get; set; }

        public int IdentityDocumentTypeId { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public long? IndividualAccountHolderId { get; set; }
        public IndividualAccountHolder IndividualAccountHolder { get; set; }
        public DateTime CreatedDateTime { get; set; }

    }

}
