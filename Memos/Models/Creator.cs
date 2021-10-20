using System;
using System.Collections.Generic;

#nullable disable

namespace Memos.Models
{
    public partial class Creator
    {
        public Creator()
        {
            Memos = new HashSet<Memo>();
        }

        public int CreatorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual ICollection<Memo> Memos { get; set; }
    }
}
