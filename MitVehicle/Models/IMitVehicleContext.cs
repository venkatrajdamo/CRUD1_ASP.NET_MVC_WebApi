namespace MitVehicle.Models
{
    //Interface to VehicleContext can be used for refering different data source
    public interface IMitVehicleContext
    {
        System.Data.Entity.IDbSet<MitVehicle.Models.Vehicle> Vehicles { get; }
        object setStateModified(Vehicle vehicle);
        void SaveChanges();
        void Dispose();
    }
}
