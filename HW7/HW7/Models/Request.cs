namespace HW7.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Request")]
    public partial class Request
    {
        public int ID { get; set; }

        public string RequestType { get; set; }

        public string SourceIP { get; set; }

        public string BrowserType { get; set; }

        public DateTime? Date { get; set; }
    }
}
