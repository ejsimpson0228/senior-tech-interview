using RxLightningAPI.Models.DTOs;

namespace RxLightningAPI.Services.Interfaces
{
    public interface IPatientService
    {
        Task<PatientViewDTO> GetPatientById(int patientId);
        Task<List<PatientViewDTO>> GetPatients();
    }
}
