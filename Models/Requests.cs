namespace InterviewWebAPI.Models
{
    public class Requests
    {
        public class PatientRegRequest
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string DOB { get; set; }
        }

        public class VitalsRegRequest
        {
            public int PatientID { get; set; }
            public string Date { get; set; }
            public int Height { get; set; }
            public int Weight { get; set; }
            public int BMI { get; set; }
            public string General_Health { get; set; }
            public int OnDrugs { get; set; }
            public int OnDiet { get; set; }
            public string Comments { get; set; }
            public string Status { get; set; }
        }

    }
}
