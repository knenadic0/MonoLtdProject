using Project.Models.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Models
{
    public class VehicleModel : IVehicleModel
    {
        public int Id { get; set; }
        public int MakeId { get; set; }
        public IVehicleMake Make { get; set; }
        public string Name { get; set; }
        public string Abrv { get; set; }
    }
}
