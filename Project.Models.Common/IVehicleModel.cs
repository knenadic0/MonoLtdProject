using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Models.Common
{
    public interface IVehicleModel
    {
        int Id { get; set; }
        int MakeId { get; set; }
        IVehicleMake Make { get; set; }
        string Name { get; set; }
        string Abrv { get; set; }
    }
}
