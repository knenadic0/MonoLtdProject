using System;
using System.Collections.Generic;
using System.Text;

namespace Project.DAL.Entities
{
    public class VehicleModelEntity
    {
        public int Id { get; set; }
        public int MakeId { get; set; }
        public virtual VehicleMakeEntity Make { get; set; }
        public string Name { get; set; }
        public string Abrv { get; set; }
    }
}
