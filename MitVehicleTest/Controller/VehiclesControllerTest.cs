using Microsoft.VisualStudio.TestTools.UnitTesting;
using MitVehicle.Controllers;
using MitVehicle.Models;
using MitVehicleTest.Model;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Results;

namespace MitVehicleTest.Controller
{
    //Test cases to test wep api functions in vehicle controller
    [TestClass]
    public class VehiclesControllerTest
    {
        //Test Case: Retrieve all vehicle details
        [TestMethod]
        public void GetVehiclesTest()
        {
            FakeVehicleContext context = new FakeVehicleContext
            {
                Vehicles =
                {
                    new Vehicle { Id = 1, Year=1999, Make="ABC",Model="CX568"},
                    new Vehicle { Id = 2, Year=2000, Make="DEF",Model="TKX78"},
                    new Vehicle { Id = 3, Year=2001, Make="GHJ",Model="TLX789"}
                }
            };
            VehiclesController controller = new VehiclesController(context);

            IQueryable<Vehicle> result = controller.GetVehicles();

            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Count());
            Assert.AreEqual(context.Vehicles.ElementAt(0), result.ElementAt(0));
            Assert.AreEqual(context.Vehicles.ElementAt(1), result.ElementAt(1));
            Assert.AreEqual(context.Vehicles.ElementAt(2), result.ElementAt(2));
        }

        //Test Case: Retrieve a vehicle details using ID
        [TestMethod]
        public void GetVehiclesByIdTest()
        {
            FakeVehicleContext context = new FakeVehicleContext
            {
                Vehicles =
                {
                    new Vehicle { Id = 1, Year=1999, Make="ABC",Model="CX568"},
                    new Vehicle { Id = 2, Year=2000, Make="DEF",Model="TKX78"},
                    new Vehicle { Id = 3, Year=2001, Make="GHJ",Model="TLX789"}
                }
            };
            VehiclesController controller = new VehiclesController(context);

            IHttpActionResult result = controller.GetVehicle(2);

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(OkNegotiatedContentResult<Vehicle>));
        }

        //Test Case: Retrieve vehicles detail using Year
        [TestMethod]
        public void GetVehiclesByYearTest()
        {
            FakeVehicleContext context = new FakeVehicleContext
            {
                Vehicles =
                {
                    new Vehicle { Id = 1, Year=1999, Make="ABC",Model="CX568"},
                    new Vehicle { Id = 2, Year=2000, Make="DEF",Model="TKX78"},
                    new Vehicle { Id = 3, Year=2001, Make="GHJ",Model="TLX789"}
                }
            };
            VehiclesController controller = new VehiclesController(context);

            IQueryable<Vehicle> result = controller.GetVehicleByYear(2000);

            Assert.IsNotNull(result);
            Assert.AreNotEqual(0, result.Count());
            Assert.AreEqual(context.Vehicles.ElementAt(1),result.ElementAt(0));
        }

        //Test Case: Retrieve vehicles detail using Make
        [TestMethod]
        public void GetVehiclesByMakeTest()
        {
            FakeVehicleContext context = new FakeVehicleContext
            {
                Vehicles =
                {
                    new Vehicle { Id = 1, Year=1999, Make="ABC",Model="CX568"},
                    new Vehicle { Id = 2, Year=2000, Make="DEF",Model="TKX78"},
                    new Vehicle { Id = 3, Year=2001, Make="GHJ",Model="TLX789"}
                }
            };
            VehiclesController controller = new VehiclesController(context);

            IQueryable<Vehicle> result = controller.GetVehicleByMake("DEF");

            Assert.IsNotNull(result);
            Assert.AreNotEqual(0, result.Count());
            Assert.AreEqual(context.Vehicles.ElementAt(1), result.ElementAt(0));
        }

        //Test Case: Retrieve vehicles detail using Model
        [TestMethod]
        public void GetVehiclesByModelTest()
        {
            FakeVehicleContext context = new FakeVehicleContext
            {
                Vehicles =
                {
                    new Vehicle { Id = 1, Year=1999, Make="ABC",Model="CX568"},
                    new Vehicle { Id = 2, Year=2000, Make="DEF",Model="TKX78"},
                    new Vehicle { Id = 3, Year=2001, Make="GHJ",Model="TLX789"}
                }
            };
            VehiclesController controller = new VehiclesController(context);

            IQueryable<Vehicle> result = controller.GetVehicleByModel("TKX78");

            Assert.IsNotNull(result);
            Assert.AreNotEqual(0, result.Count());
            Assert.AreEqual(context.Vehicles.ElementAt(1), result.ElementAt(0));
        }

        //Test Case: Create a new vehicles detail
        [TestMethod]
        public void PostVehiclesTest()
        {
            FakeVehicleContext context = new FakeVehicleContext
            {
                Vehicles =
                {
                    new Vehicle { Id = 1, Year=1999, Make="ABC",Model="CX568"},
                    new Vehicle { Id = 2, Year=2000, Make="DEF",Model="TKX78"},
                    new Vehicle { Id = 3, Year=2001, Make="GHJ",Model="TLX789"}
                }
            };
            Vehicle newVehicle = new Vehicle { Year = 2003, Make = "BNM", Model = "TT989" };
            VehiclesController controller = new VehiclesController(context);

            IHttpActionResult result = controller.PostVehicle(newVehicle);

            Assert.IsNotNull(result);
            Assert.AreEqual(4, context.Vehicles.Count());
            Assert.AreEqual(newVehicle, context.Vehicles.ElementAt(3));
            Assert.IsInstanceOfType(result, typeof(CreatedAtRouteNegotiatedContentResult<Vehicle>));
        }

        //Test Case: Update a new vehicles detail
        [TestMethod]
        public void PutVehiclesTest()
        {
            FakeVehicleContext context = new FakeVehicleContext
            {
                Vehicles =
                {
                    new Vehicle { Id = 1, Year=1999, Make="ABC",Model="CX568"},
                    new Vehicle { Id = 2, Year=2000, Make="DEF",Model="TKX78"},
                    new Vehicle { Id = 3, Year=2001, Make="GHJ",Model="TLX789"}
                }
            };
            Vehicle editVehicle = new Vehicle { Id = 2, Year = 2003, Make = "BNM", Model = "TT989" };
            VehiclesController controller = new VehiclesController(context);

            IHttpActionResult result = controller.PutVehicle(2, editVehicle);

            Assert.IsNotNull(result);
            Assert.AreEqual(3, context.Vehicles.Count());
            Assert.AreEqual(0, controller.GetVehicleByMake("BNM").Count());
            Assert.IsInstanceOfType(result, typeof(StatusCodeResult));
        }

        //Test Case: Delete a new vehicles from list
        [TestMethod]
        public void DeleteVehiclesTest()
        {
            FakeVehicleContext context = new FakeVehicleContext
            {
                Vehicles =
                {
                    new Vehicle { Id = 1, Year=1999, Make="ABC",Model="CX568"},
                    new Vehicle { Id = 2, Year=2000, Make="DEF",Model="TKX78"},
                    new Vehicle { Id = 3, Year=2001, Make="GHJ",Model="TLX789"}
                }
            };
            VehiclesController controller = new VehiclesController(context);

            IHttpActionResult result = controller.DeleteVehicle(2);

            Assert.IsNotNull(result);
            Assert.AreEqual(2, context.Vehicles.Count());
            Assert.IsInstanceOfType(result, typeof(OkNegotiatedContentResult<Vehicle>));
        }
    }
}
