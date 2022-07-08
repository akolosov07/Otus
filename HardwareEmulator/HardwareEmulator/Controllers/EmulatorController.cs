using HardwareEmulator.Models;
using HardwareEmulator.Services;
using Microsoft.AspNetCore.Mvc;

namespace HardwareEmulator.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmulatorController : ControllerBase
    {
        private static Guid requestId;
        private readonly EmulatorService _emulatorService;

        public EmulatorController(EmulatorService emulatorService)
        {
            _emulatorService = emulatorService;
        }

        [HttpGet]
        public async Task<ActionResult> StartCharge([FromQuery]StartHardwareCharge request)
        {
            if (request.RequestId != requestId)
                await _emulatorService.StartCharge(request);
            return Ok();
        }
    }
}
