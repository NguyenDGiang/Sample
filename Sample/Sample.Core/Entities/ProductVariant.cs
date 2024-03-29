﻿using Sample.Shared.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Core.Entities
{
    [Table("ProductVariant")]
    public class ProductVariant : EntityAuditBase<int>
    {
        public string Sku { get; set; }
        public decimal Quantity { get; set; }
        public decimal Price { get; set; }
        [ForeignKey("Product")]
        public Guid ProductId { get; set; }
        public Product? Product { get; set; }
        [ForeignKey("Attribute")]
        public int AttributeId { get; set; }
        public Attribute? Attribute { get; set; }
        [ForeignKey("AttributeProduct")]
        public int AttributeProductId { get; set; }
        public AttributeProduct? AttributeProduct { get; set; }
    }
}