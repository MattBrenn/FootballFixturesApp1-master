using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FootballFixturesApp1.Models
{


    public class Report
    {
        [Key]
        [Required]
        [Display(Name = "ID")]
        public string ID { get; set; }

        [Display(Name = "Report")]
        public string AReport { get; set; }

        public virtual ICollection<Fixture> Fixtures { get; set; }

    }
}