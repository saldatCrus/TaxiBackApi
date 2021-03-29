using System;

namespace TaxiBackApi.Models
{
    /// <summary>
    /// Model of Order
    /// <para></para>
    /// <paramref name="Id "/> : Id of order on Data Base 
    /// <para></para>
    /// <paramref name="OrderType"/> : Type of Handler system
    /// <para></para>
    /// <paramref name="OrderNumber"/> : Number Of Order
    /// <para></para>
    /// <paramref name="JsonOrder"/> : Json Input Order
    /// <para></para>
    /// <paramref name="ConvertedJsonOrder"/> : Json Output Oder 
    ///  <para></para>
    /// <paramref name="DateTime"/> :  Server upload time
    /// </summary>
    public class PackagedOrder
    {
        public int Id { get; set; }

        public string OrderType { get; set; }

        public int OrderNumber { get; set; }

        public string JsonOrder { get; set; }

        public string ConvertedJsonOrder { get; set;  }

        public DateTime DateTime { get; set; }
    }
}
