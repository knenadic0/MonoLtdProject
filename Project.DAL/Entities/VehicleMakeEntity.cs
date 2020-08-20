using System;
using System.Collections.Generic;
using System.Text;

namespace Project.DAL.Entities
{
    public class VehicleMakeEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Abrv { get; set; }
        public virtual ICollection<VehicleModelEntity> Models { get; set; }
    }
}
