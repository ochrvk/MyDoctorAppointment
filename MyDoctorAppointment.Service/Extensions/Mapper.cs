using MyDoctorAppointment.Domain.Entities;
using MyDoctorAppointment.Service.ViewModels;
using MyDoctorAppointment.Domain.Enums;


namespace MyDoctorAppointment.Service.Extensions
{
    public static class Mapper
    {
        public static DoctorViewModel ConvertTo(this Doctor doctor)
        {
            if (doctor == null)
            {
                return null!;
            }

            string doctorType = string.Empty;

            switch (doctor.DoctorType)
            {
                case DoctorTypes.Dentist:
                    doctorType = "Dentist";
                    break;
                case DoctorTypes.Dermatologist:
                    doctorType = "Dermatologist";
                    break;
                case DoctorTypes.FamilyDoctor:
                    doctorType = "FamilyDoctor";
                    break;
                case DoctorTypes.Paramedic:
                    doctorType = "Paramedic";
                    break;
                default:
                    doctorType = "Unknown";
                    break;
            }

            return new DoctorViewModel()
            {
                Name = doctor.Name,
                Surname = doctor.Surname,
                Email = doctor.Email,
                Phone = doctor.Phone,
                DoctorType = doctorType,
                Experiance = doctor.Experience,
                Salary = doctor.Salary,
            };
        }

        public static PatientViewModel ConvertTo(this Patient patient)
        {
            if (patient == null)
            {
                return null!;
            }

            string illnessType = string.Empty;

            switch (patient.IllnessType)
            {
                case IllnessTypes.EyeDisease:
                    illnessType = "EyeDisease";
                    break;
                case IllnessTypes.Infection:
                    illnessType = "Infection";
                    break;
                case IllnessTypes.DentalDisease:
                    illnessType = "DentalDisease";
                    break;
                case IllnessTypes.SkinDisease:
                    illnessType = "SkinDisease";
                    break;
                case IllnessTypes.Ambulance:
                    illnessType = "Ambulance";
                    break;
                default:
                    illnessType = "Unknown";
                    break;
            }

            return new PatientViewModel()
            {
                Name = patient.Name,
                Surname = patient.Surname,
                Email = patient.Email,
                Phone = patient.Phone,
                AdditionalInfo = patient.AdditionalInfo,
                Address = patient.Address,
                IllnessType = illnessType,
            };
        }

        public static AppointmentViewModel ConvertTo(this Appointment appointment)
        {
            if (appointment == null)
            {
                return null!;
            }

            return new AppointmentViewModel()
            {
                Description = appointment.Description,
                DateTimeForm = appointment.DateTimeForm.ToString(),
                Doctor = appointment.Doctor.ConvertTo(),
                Patient = appointment.Patient.ConvertTo(),
            };
        }
    }
}
