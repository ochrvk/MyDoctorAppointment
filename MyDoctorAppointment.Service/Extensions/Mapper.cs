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
                return null;
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
    }
}
