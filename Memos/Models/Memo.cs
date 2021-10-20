using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Memos.Models
{
    public partial class Memo
    {
        public int MemoId { get; set; }
        public int? CreatorId { get; set; }
        [StringLength(80)]
        public string MemoHeader { get; set; }
        [StringLength(280)]
        public string MemoBody { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ExpiredDate { get; set; }

        public virtual Creator Creator { get; set; }
    }
}
