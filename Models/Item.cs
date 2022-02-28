using System;
using System.Collections.Generic;

#nullable disable

namespace Todo.Models
{
    public partial class Item
    {
        public long Id { get; set; }
        public string ItemName { get; set; }
        public bool? IsCompleted { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
