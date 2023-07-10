namespace InterviewWebAPI.Models
{
    public class Responses
    {
        public class PatientRegResponse
        {
            public int code { get; set; }
            public string message { get; set; }
            public int AffectedRows { get; set; }
        }

        public class VitalsRegResponse
        {
            public int code { get; set; }
            public string message { get; set; }
            public int AffectedRows { get; set; }
        }

        public class VitalsDatum
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public DateTime DOB { get; set; }
            public string Status { get; set; }
        }
        public class GetVItalsDetailsResponse
        {
            public int code { get; set; }
            public string message { get; set; }
            public VitalsDatum data { get; set; }

        }
    }

}
