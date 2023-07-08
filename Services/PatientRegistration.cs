using DbDataReaderMapper;
using InterviewWebAPI.Interfaces;
using InterviewWebAPI.Models;
using MySqlConnector;
using System.Collections.Generic;
using System.Data;
using static InterviewWebAPI.Models.Requests;
using static InterviewWebAPI.Models.Responses;

namespace InterviewWebAPI.Services
{
    public class PatientRegistration : IPatientRegistration
    {
        private readonly IConfiguration _configuration;

        public PatientRegistration(IConfiguration configuration)
        {
                _configuration = configuration;
        }

        public async Task<PatientRegResponse> Sp_AddPatientRegistrationData(PatientRegRequest param)
        {
            using MySqlConnection connection = new(_configuration.GetSection("ConnectionStrings")["Default"]);

            try
            {

                var insertQuery = string.Format("INSERT INTO `patient`(`FirstName`, `LastName`, `DOB`) VALUES ('{0}','{1}','{2}')",param.FirstName, param.LastName, param.DOB);


                //create command object to pass the connection and other information
                MySqlCommand command = new()
                {
                    Connection = connection,

                    //set command type as text
                    CommandType = CommandType.Text,

                    //pass the stored procedure name
                    CommandText = insertQuery
                };

                //open connection
                connection.Open();

                //execute and get data in data reader
                int affectedRows = await command.ExecuteNonQueryAsync();

                if (affectedRows > 0)
                {
                    PatientRegResponse response = new()
                    {
                        code = 200,
                        AffectedRows = affectedRows,
                    };

                    return response;
                }
                else
                {
                    PatientRegResponse response = new()
                    {
                        code = 500,
                        message = "operation failed"
                    };

                    return response;
                }
            }
            catch (Exception ex)
            {
                PatientRegResponse regException = new()
                {
                    code = 500,
                    message = ex.Message,
                };

                return regException;
            }finally { await connection.CloseAsync(); } 
        }

        public async Task<GetVItalsDetailsResponse> Sp_GetVitals()
        {
            using MySqlConnection connection = new(_configuration.GetSection("ConnectionStrings")["Default"]);

            try
            {

                var insertQuery = "SELECT `FirstName`, `LastName`, `DOB`, `Status` FROM `vitalsperpatient` v INNER JOIN patient p ON v.PatientID = p.PatientID";


                //create command object to pass the connection and other information
                MySqlCommand command = new()
                {
                    Connection = connection,

                    //set command type as text
                    CommandType = CommandType.Text,

                    //pass the stored procedure name
                    CommandText = insertQuery
                };

                //open connection
                connection.Open();

                //execute and get data in data reader
                MySqlDataReader reader = await command.ExecuteReaderAsync();


                List<VitalsDatum> result = new();

                while (reader.Read())
                {
                    result = reader.MapToObject<List<VitalsDatum>>();
                }

                GetVItalsDetailsResponse response = new()
                {
                    code = 200,
                    data = result
                };

                return response;

            }
            catch (Exception ex)
            {
                GetVItalsDetailsResponse regException = new()
                {
                    code = 500,
                    message = ex.Message,
                };

                return regException;
            }
            finally { await connection.CloseAsync(); }
        }

        public async Task<VitalsRegResponse> Sp_RegisterVitals(VitalsRegRequest param)
        {
            using MySqlConnection connection = new(_configuration.GetSection("ConnectionStrings")["Default"]);

            try
            {

                var insertQuery = string.Format("INSERT INTO `vitalsperpatient`(`PatientID`, `Date`, `Height`, `Weight`, `BMI`, `General_Health`, `OnDiet`, `OnDrugs`, `Comments`, `Status`) VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}')", param.PatientID, param.Date, param.Height, param.Weight, param.BMI, param.General_Health, param.OnDiet, param.OnDrugs, param.Comments, param.Status);


                //create command object to pass the connection and other information
                MySqlCommand command = new()
                {
                    Connection = connection,

                    //set command type as text
                    CommandType = CommandType.Text,

                    //pass the stored procedure name
                    CommandText = insertQuery
                };

                //open connection
                connection.Open();

                //execute and get data in data reader
                int affectedRows = await command.ExecuteNonQueryAsync();

                if (affectedRows > 0)
                {
                    VitalsRegResponse response = new()
                    {
                        code = 200,
                        message = "Success",
                        AffectedRows = affectedRows,
                    };

                    return response;
                }
                else
                {
                    VitalsRegResponse response = new()
                    {
                        code = 500,
                        message = "operation failed"
                    };

                    return response;
                }
            }
            catch (Exception ex)
            {
                VitalsRegResponse regException = new()
                {
                    code = 500,
                    message = ex.Message,
                };

                return regException;
            }
            finally { await connection.CloseAsync(); }
        }

    }
}
