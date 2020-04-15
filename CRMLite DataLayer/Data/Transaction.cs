using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMLite_DataLayer.Data
{
    public class Transaction
    {
        public long Id { get; set; }
        public DateTime DateTime { get; set; }
        public Guid TransactionId { get; set; }
        public DateTime CompletedDateTime { get; set; }
        [MaxLength(100)]
        public string Reference { get; set; }
        public long AmountValue { get; set; }
        [MaxLength(3)]
        public string AmountCurrency { get; set; }

        public long CurrentBalance { get; set; }
        public long AccountId { get; set; }
        public Account Account { get; set; }
        [MaxLength(100)]
        public string OtherAccountReference { get; set; }

        public int SenderOrReceiver { get; set; }
        public int TransactionType { get; set; }
        public int DebitOrCredit { get; set; }
        public int ClearedDateTime { get; set; }

        //Not Sure about reference/relationship
        public long? OtherAccountId { get; set; }
        public long? BatchNo { get; set; }
        public Guid? LinkedTransactionId { get; set; }

    }

}
