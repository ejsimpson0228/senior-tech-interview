using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RxLightningAPI.Services.Interfaces;

namespace RxLightningAPI.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IPatientService _patientService;
        public PatientController(IPatientService patientService)
        {
            _patientService = patientService;
        }

        [HttpGet]
        [Route("patients")]
        public async Task<IActionResult> GetPatients()
        {
            var patients = await _patientService.GetPatients();
            return Ok(patients);
        }

        [HttpGet]
        [Route("patients/{patientId}")]
        public async Task<IActionResult> GetPatientById(int patientId)
        {
            var patient = await _patientService.GetPatientById(patientId);
            return Ok(patient);
        }
    }
}
