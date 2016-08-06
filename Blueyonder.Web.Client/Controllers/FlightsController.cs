using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Blueyonder.DataAccess.Entities;
namespace Blueyonder.Web.Client.Controllers
{
    public class FlightsController : ApiController
    {

        /*SINGLETON */
        /*
        private static volatile object objblueyonder = new object();
        private blueyonderdbEntities context; 
        public blueyonderdbEntities Context {
            get {
                lock (objblueyonder)
                {
                    if (context == null)
                        context = new blueyonderdbEntities();

                    return context; 
                }
            }
        }
        */
        private readonly blueyonderdbEntities _context
            = new blueyonderdbEntities();

        public IEnumerable<Flight> Get()
        {
            return _context.Flight.ToArray();
        }


    }
}