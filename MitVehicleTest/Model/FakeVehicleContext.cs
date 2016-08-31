using MitVehicle.Models;
using System;
using System.Data.Entity;

namespace MitVehicleTest.Model
{
    //Repository context used in testing
    public class FakeVehicleContext : IMitVehicleContext
    {
        public IDbSet<Vehicle> Vehicles { get; set; }
        public FakeVehicleContext()
        {
            this.Vehicles = new FakeVehicleSet();
        }

        public new object setStateModified(Vehicle vehicle)
        {
            //Entry(vehicle);
            return vehicle;
            //throw new NotImplementedException();
        }

        void IMitVehicleContext.SaveChanges()
        {

            //throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
