using static InterviewWebAPI.Models.Requests;
using static InterviewWebAPI.Models.Responses;

namespace InterviewWebAPI.Interfaces
{
    public interface IPatientRegistration
    {
        public Task<PatientRegResponse> Sp_AddPatientRegistrationData(PatientRegRequest param);

        public Task<VitalsRegResponse> Sp_RegisterVitals(VitalsRegRequest param);

        public Task<GetVItalsDetailsResponse> Sp_GetVitals();
    }
}
