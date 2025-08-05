using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Services;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValueController1 : ControllerBase
    {
        private readonly IConsumerService _consumerService;
        public ValueController1(IConsumerService consumerService)
        {
            _consumerService = consumerService;
            _consumerService.StartConsuming();
        }
    }
}
