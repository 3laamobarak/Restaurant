﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.Models
{
    public class Ordered_Items
    {
        [Key]
        public string Id { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }

        [ForeignKey("Order")]
        public string OrderId { get; set; }
        public virtual Order Order { get; set; }

        [ForeignKey("Item")]
        public string ItemId { get; set; }
        public virtual Item Item { get; set; }
    }
}
