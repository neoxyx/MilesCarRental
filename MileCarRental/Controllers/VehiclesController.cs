using Microsoft.AspNetCore.Mvc;
using MileCarRental.Models;
using System.Collections.Generic;
using System.Linq;

namespace MilesCarRental.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiclesController : ControllerBase
    {
        private readonly List<Vehicle> _vehicles; // Suponiendo una lista de vehículos en memoria

        public VehiclesController()
        {
            // Inicializa la lista de vehículos (podemos cargarla desde una base de datos, servicio externo, etc.)
            _vehicles = new List<Vehicle>
            {
                new Vehicle { Id = 1, Brand = "Toyota", Model = "Corolla", Year = 2020, Type = "Sedan", Location = "Medellín" },
                new Vehicle { Id = 2, Brand = "Honda", Model = "Civic", Year = 2019, Type = "Sedan", Location = "Medellín" },
                new Vehicle { Id = 3, Brand = "Ford", Model = "F-150", Year = 2021, Type = "Truck", Location = "Bogotá" },
                // Agregar más vehículos según sea necesario
            };
        }

        // GET: api/vehicles
        [HttpGet]
        public ActionResult<IEnumerable<Vehicle>> Get()
        {
            return _vehicles;
        }

        // GET: api/vehicles/search
        [HttpGet("search")]
        public ActionResult<IEnumerable<Vehicle>> Search([FromQuery] string pickupLocation, [FromQuery] string returnLocation)
        {
            // Filtrar vehículos por localidad de recogida
            var result = _vehicles.Where(v => v.Location.ToLower() == pickupLocation.ToLower());

            // Si se especifica una localidad de devolución, filtrar también por ella
            if (!string.IsNullOrEmpty(returnLocation))
                result = result.Where(v => v.Location.ToLower() == returnLocation.ToLower());

            // Retorna los vehículos disponibles en la localidad de recogida y/o devolución
            return result.ToList();
        }
    }
}
