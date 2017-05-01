using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FootballFixturesApp1.DAL;
using FootballFixturesApp1.Models;

namespace FootballFixturesApp1.Controllers
{
    public class SearchController : Controller

    {
        private MatchContext db = new MatchContext();

        public ActionResult Index(string search)
        {
            // var fixtures = from f in db.Fixtures
            // select f;

            var reports = (from x in db.Fixtures
                           join y in db.Reports on x.ID equals y.ID
                           orderby x.TeamOne
                           select new SearchViewModel { TeamOne = x.TeamOne, TeamTwo = x.TeamTwo, AReport = y.AReport });


            if (!String.IsNullOrEmpty(search))
            {
                reports = reports.Where(f => f.TeamOne.Contains(search) || f.TeamTwo.Contains(search));

            }

            return View(reports);
        }

    }
}