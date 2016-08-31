using MitVehicle.Models;
using System.Linq;

namespace MitVehicleTest.Model
{
    //DBset to store and manipulate repository
    class FakeVehicleSet : FakeDbSet<Vehicle>
    {

        public override Vehicle Find(params object[] keyValues)
        {
            return this.SingleOrDefault(d => d.Id == (int)keyValues.Single());
        }
    }
}
