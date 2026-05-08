using Microsoft.AspNetCore.Mvc;

namespace Laboratorio.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SmartphoneController : ControllerBase
    {
        private static readonly string[] Marcas = new[]
        {
            "Samsung", "Apple", "Xiaomi", "Motorola", "Huawei"
        };

        private readonly ILogger<SmartphoneController> _logger;

        public SmartphoneController(ILogger<SmartphoneController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetSmartphones")]
        public IEnumerable<Smartphone> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new Smartphone
            {
                Id = index,
                Marca = Marcas[Random.Shared.Next(Marcas.Length)],
                Precio = Random.Shared.Next(300, 2000),
                Modelo = $"Modelo {index}"
            })
            .ToArray();
        }
    }

    public class Smartphone
    {
        public int Id { get; set; }

        public string? Marca { get; set; }

        public int Precio { get; set; }

        public string? Modelo { get; set; }
    }
}