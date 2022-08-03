using AutoMapper;
using RxLightningAPI.Exceptions;
using RxLightningAPI.Models;
using RxLightningAPI.Models.DTOs;
using RxLightningAPI.Services.Interfaces;

namespace RxLightningAPI.Services
{
    public class PatientService : IPatientService
    {
        private IPatientServiceAPIService _patientServiceAPIService;
        private static List<PatientIdConverter> _patientIdConverters = new List<PatientIdConverter>();
        private readonly IMapper _mapper;

        public PatientService(IPatientServiceAPIService patientServiceAPIService,  IMapper mapper)
        {
            _patientServiceAPIService = patientServiceAPIService;
            _mapper = mapper;
        }

        public async Task<PatientViewDTO> GetPatientById(int patientId)
        {
            var patientIdHolder = _patientIdConverters.FirstOrDefault(p => p.UiId == patientId);

            if (patientIdHolder == null)
            {
                throw new HttpResponseException(404, "Patient was not found");
            }

            var patient = await _patientServiceAPIService.GetPatientById(patientIdHolder.PatientId);

            var patientViewDTO = _mapper.Map<PatientViewDTO>(patient);

            patientViewDTO.UIId = patientIdHolder.UiId;

            return patientViewDTO;
        }

        public async Task<List<PatientViewDTO>> GetPatients()
        {
            List<PatientViewDTO> patientViewDTOs = new List<PatientViewDTO>();
            var patients = await _patientServiceAPIService.GetPatients();

            for (int i = 1; i < patients.Count; i++)
            {
                if (!_patientIdConverters.Any(p => p.PatientId == patients[i].PatientId))
                {
                    _patientIdConverters.Add(new PatientIdConverter { PatientId = patients[i].PatientId, UiId = i });
                }

                var patientViewDTO = _mapper.Map<PatientViewDTO>(patients[i]);
                patientViewDTO.UIId = _patientIdConverters.First(p => p.PatientId == patients[i].PatientId).UiId;

                patientViewDTOs.Add(patientViewDTO);
            }

            return patientViewDTOs;
        }
    }
}
