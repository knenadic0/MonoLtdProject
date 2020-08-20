using Project.Models.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Models
{
    public class VehicleMake : IVehicleMake
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Abrv { get; set; }
        public ICollection<IVehicleModel> Models { get; set; }
    }
}
