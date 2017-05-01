using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace FootballFixturesApp1.Models
{
    public class SearchViewModel
    {
        [Display(Name = "Home Team")]
        public string TeamOne { get; set; }

        [Display(Name = "Away Team")]
        public string TeamTwo { get; set; }

        [Display(Name = "Report")]
        public string AReport { get; set; }
    }
}