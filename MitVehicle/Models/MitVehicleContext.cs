using System.Data.Entity;

namespace MitVehicle.Models
{
    public class MitVehicleContext : DbContext, IMitVehicleContext
    {    
        public MitVehicleContext() : base("name=MitVehicleContext")
        {
        }

        public System.Data.Entity.IDbSet<MitVehicle.Models.Vehicle> Vehicles { get; set; }
        
        public new object setStateModified(Vehicle vehicle)
        {
            
            Entry(vehicle).State= EntityState.Modified;
            return vehicle;
        }

        void IMitVehicleContext.SaveChanges()
        {
            SaveChanges();
        }
    }
}
