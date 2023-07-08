using InterviewWebAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Emit;
using static InterviewWebAPI.Models.Requests;
using static InterviewWebAPI.Models.Responses;

namespace InterviewWebAPI.Controllers.Registration
{
    public class RegistrationController : Controller
    {
        private readonly IPatientRegistration _spconn;

        public RegistrationController(IPatientRegistration spconn)
        {
            _spconn = spconn;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost(nameof(RegisterPatient))]
        public async Task<PatientRegResponse> RegisterPatient(PatientRegRequest param)
        {
            try
            {
                if (param == null)
                {
                    PatientRegResponse rtn = new()
                    {
                        code = 501,
                        message = "Invalid Request"
                    };
                    return rtn;
                }
                else
                {
                    var results = await _spconn.Sp_AddPatientRegistrationData(param);
                    return results;
                }
            }
            catch (Exception ex)
            {
                PatientRegResponse exp = new()
                {
                    code = 500,
                    message = ex.Message
                };
                
                return exp;
            }
        }

        [HttpPost(nameof(RegisterPatientVitals))]
        public async Task<VitalsRegResponse> RegisterPatientVitals(VitalsRegRequest param)
        {
            try
            {
                if (param == null)
                {
                    VitalsRegResponse rtn = new()
                    {
                        code = 501,
                        message = "Invalid Request"
                    };
                    return rtn;
                }
                else
                {
                    var results = await _spconn.Sp_RegisterVitals(param);
                    return results;
                }
            }
            catch (Exception ex)
            {
                VitalsRegResponse exp = new()
                {
                    code = 500,
                    message = ex.Message
                };

                return exp;
            }
        }


        [HttpGet(nameof(GetReport))]
        public async Task<GetVItalsDetailsResponse> GetReport()
        {
            try
            {
                    var results = await _spconn.Sp_GetVitals();
                        return results;
            }
            catch (Exception ex)
            {
                GetVItalsDetailsResponse exp = new()
                {
                    code = 500,
                    message = ex.Message
                };

                return exp;
            }
        }
    }
}
