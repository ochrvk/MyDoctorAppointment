namespace MyDoctorAppointment.Domain.Entities
{
    public class Appointment
    {
        public Patient? Patient { get; set; }

        public Doctor? Doctor { get; set; }

        public DateTime DateTimeForm { get; set; }

        public string? Description { get; set; }
    }
}
