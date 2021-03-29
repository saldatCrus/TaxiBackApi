using System;
using System.Collections.Generic;

namespace TaxiBackApi.Models
{
    /// <summary>
    /// Model of Order
    /// <para></para>
    /// <paramref name="OrderNumber"/> : Oder Number :/
    /// <para></para>
    /// <paramref name="Products"/> : List of products in order
    /// <para></para>
    /// <paramref name="createdAt"/> : Time of creation
    /// </summary>
    public class Order
    {

        public int OrderNumber { get; set; }

        public List<Product> Products { get; set; }

        public DateTime createdAt { get; set; }

    }
}

