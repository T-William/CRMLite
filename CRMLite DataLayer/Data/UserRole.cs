using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMLite_DataLayer.Data
{
    public class UserRole
    {
        [Column(TypeName = "bigint")]
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedDateTime { get; set; }
        public int Role { get; set; }
        public long? AccountHolderId { get; set; }
        public AccountHolder AccountHolder { get; set; }
        public DateTime CreatedDateTime { get; set; }

    }

}
