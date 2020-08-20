using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Models.Common
{
    public interface IVehicleMake 
    {
        int Id { get; set; }
        string Name { get; set; }
        string Abrv { get; set; }
        ICollection<IVehicleModel> Models { get; set; }
    }
}
