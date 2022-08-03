using RxLightningAPI.Models.PatientServiceAPIModels;

namespace RxLightningAPI.Services.Interfaces
{
    public interface IPatientServiceAPIService
    {
        Task<Patient> GetPatientById(Guid patientId);
        Task<List<Patient>> GetPatients();
    }
}