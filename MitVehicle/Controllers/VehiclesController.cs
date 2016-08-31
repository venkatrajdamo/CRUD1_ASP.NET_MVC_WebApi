using MitVehicle.Models;
using System;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;

namespace MitVehicle.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class VehiclesController : ApiController
    {
        private IMitVehicleContext db;

        public VehiclesController()
        {
            this.db = new MitVehicleContext();
        }

        //Constructor Used to pass repository reference while running test cases
        public VehiclesController(IMitVehicleContext context)
        {
            this.db = context;
        }

        // GET: api/Vehicles
        public IQueryable<Vehicle> GetVehicles()
        {
            return db.Vehicles;
        }

        // GET: api/Vehicles/5
        [ResponseType(typeof(Vehicle))]
        public IHttpActionResult GetVehicle(int id)
        {
            Vehicle vehicle = db.Vehicles.Find(id);
            if (vehicle == null)
            {
                return NotFound();
            }

            return Ok(vehicle);
        }

        // GET: api/Vehicles/year/1999
        [Route("api/vehicles/year/{year:int}")]
        public IQueryable<Vehicle> GetVehicleByYear(int year)
        {
            IQueryable<Vehicle> vehicles = db.Vehicles.Where(item => (item.Year == year)).AsQueryable();
            return vehicles;
        }

        // GET: api/Vehicles/make/ABC
        [Route("api/vehicles/make/{make}")]
        public IQueryable<Vehicle> GetVehicleByMake(String make)
        {
            IQueryable<Vehicle> vehicles = db.Vehicles.Where(item => (item.Make == make)).AsQueryable();
            return vehicles;
        }

        // GET: api/Vehicles/model/TR568
        [Route("api/vehicles/model/{model}")]
        public IQueryable<Vehicle> GetVehicleByModel(String model)
        {
            IQueryable<Vehicle> vehicles = db.Vehicles.Where(item => (item.Model == model)).AsQueryable();
            return vehicles;
        }
         // GET: api/Vehicles/object
         [Route("api/vehicles/filter/{year:int}/{make}/{model}")]
         public IQueryable<Vehicle> GetVehicleByFilter(int year, String make="", String model="")
         {
             IQueryable<Vehicle> vehicles = db.Vehicles.Where(item => (item.Year == year || item.Make == make || item.Model == model)).AsQueryable();
             return vehicles;
         }

        // PUT: api/Vehicles/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutVehicle(int id, Vehicle vehicle)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != vehicle.Id || String.IsNullOrWhiteSpace(vehicle.Make) 
                || String.IsNullOrWhiteSpace(vehicle.Model) 
                || vehicle.Year < 1950 || vehicle.Year > 2050)
            {
                return BadRequest();
            }

            
            db.setStateModified(vehicle);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VehicleExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Vehicles
        [ResponseType(typeof(Vehicle))]
        public IHttpActionResult PostVehicle(Vehicle vehicle)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (String.IsNullOrWhiteSpace(vehicle.Make) || String.IsNullOrWhiteSpace(vehicle.Model)
                || vehicle.Year < 1950 || vehicle.Year > 2050)
            {
                return BadRequest();
            }

            db.Vehicles.Add(vehicle);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = vehicle.Id }, vehicle);
        }

        // DELETE: api/Vehicles/5
        [ResponseType(typeof(Vehicle))]
        public IHttpActionResult DeleteVehicle(int id)
        {
            Vehicle vehicle = db.Vehicles.Find(id);
            if (vehicle == null)
            {
                return NotFound();
            }

            db.Vehicles.Remove(vehicle);
            db.SaveChanges();

            return Ok(vehicle);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool VehicleExists(int id)
        {
            return db.Vehicles.Count(e => e.Id == id) > 0;
        }
    }
}