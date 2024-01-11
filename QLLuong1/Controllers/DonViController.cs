using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using QLLuong1.Models;

namespace QLLuong1.Controllers
{
    public class DonViController : ApiController
    {
        QLLuong1Entities1 db = new QLLuong1Entities1();

        [HttpGet]
        public List<DonVi> layDonVi()
        {
            return db.DonVis.ToList();
        }
    }
}
