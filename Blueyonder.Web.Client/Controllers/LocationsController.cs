using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Blueyonder.DataAccess.Interfaces;
using Blueyonder.Entities;
using Blueyonder.Companion.Controllers.DataTransferObjects;
using Blueyonder.Companion.Entities.Mappers;
using Blueyonder.Companion.Entities;
using Blueyonder.DataAccess.Repositories;


namespace Blueyonder.Companion.Controllers
{
    public class LocationsController : ApiController
    {
        public ILocationRepository Locations { get; set; }

        public LocationsController(ILocationRepository locations)
        {
            Locations = locations;
        }

        public IQueryable<Location> Get()
        {
            return Locations.GetAll();
        }

        public LocationDTO Get(int id)
        {
            var location = Locations.GetSingle(id);

            return location.ToLocationDTO();
        }
    }
}