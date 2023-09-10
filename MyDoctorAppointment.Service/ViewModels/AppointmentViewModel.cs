namespace MyDoctorAppointment.Service.ViewModels
{
    public class AppointmentViewModel
    {
        public PatientViewModel? Patient { get; set; }

        public DoctorViewModel? Doctor { get; set; }

        public string? DateTimeForm { get; set; }

        public string? Description { get; set; }
    }
}
