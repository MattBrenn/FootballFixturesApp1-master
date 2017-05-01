using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FootballFixturesApp1.Models
{
    public enum Result
    {
        [Display(Name = "Home Win")]
        TeamOneWin,

        [Display(Name = "Away Win")]
        TeamTwoWin,

        Draw }


    public class Fixture
    {
        [Key]
        [Required]
        [Display(Name = "ID")]
        public string ID { get; set; }

        [Required]
        [Display(Name = "Date")]
        public DateTime Date { get; set; }

        [Required]
        [Display(Name = "Home Team")]
        public string TeamOne { get; set; }

        [Required]
        [Display(Name = "Away Team")]
        public string TeamTwo { get; set; }


        public Result Result { get; set; }

        public virtual ICollection<Report> Reports { get; set; }


    }
}