using System;

namespace TaxiBackApi.Models
{
    /// <summary>
    /// Model of log
    /// <para></para>
    /// <paramref name="id"/> : Dont set this
    /// <para></para>
    /// <paramref name="EventName"/> : Yore exception message
    /// <para></para>
    /// <paramref name="EventPlace"/> : Where exception created
    /// <para></para>
    /// <paramref name="EventDataTime"/> : Time at which the error occurred 
    /// </summary >
    public class Log
    {
        public int id { get; set; }

        public string EventName { get; set; }

        public string EventPlace { get; set; }

        public DateTime EventDataTime {get; set;}
    }
}
