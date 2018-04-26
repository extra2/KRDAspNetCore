using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KRDAspNetCore.Model
{
    public class Packages
    {
        [Key]
        public int ID { get; set; }

        public int IdUser { get; set; }
        public string Status { get; set; }
        public DateTime StatucChangedDate { get; set; }
    }
}
