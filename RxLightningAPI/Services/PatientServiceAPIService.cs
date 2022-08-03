
using RxLightningAPI.Exceptions;
using RxLightningAPI.Models.PatientServiceAPIModels;
using RxLightningAPI.Services.Interfaces;
using System.Net.Http.Headers;

namespace RxLightningAPI.Services
{
    public class PatientServiceAPIService : IPatientServiceAPIService
    {
        private readonly string _baseUrl;

        public PatientServiceAPIService(IConfiguration configuration)
        {
            _baseUrl = configuration["PatientServiceAPIUrl"].ToString();
        }

        public async Task<Patient> GetPatientById(Guid patientId)
        {
            var url = _baseUrl + $"patient/{patientId}";

            var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(url);

            httpClient.DefaultRequestHeaders.Accept.Add(
           new MediaTypeWithQualityHeaderValue("application/json"));

            var response = await httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode) 
            {
                var patient = await response.Content.ReadFromJsonAsync(typeof(Patient));

                if (patient != null)
                    return (Patient)patient;
            }

            throw new HttpResponseException(404, "Patient not found");

        }

        public async Task<List<Patient>> GetPatients()
        {
            var url = _baseUrl + "patients/";

            var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(url);

            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = await httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var patients = await response.Content.ReadFromJsonAsync(typeof(List<Patient>));

                if (patients != null) 
                    return (List<Patient>)patients; 
            }

            throw new HttpResponseException(404, "Patients not found");
        }
    }
}
