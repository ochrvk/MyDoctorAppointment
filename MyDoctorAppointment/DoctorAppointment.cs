using MyDoctorAppointment.Domain.Entities;
using MyDoctorAppointment.Domain.Enums;
using MyDoctorAppointment.Enums;
using MyDoctorAppointment.Service.Interfaces;
using MyDoctorAppointment.Service.Services;
using MyDoctorAppointment.Service.ViewModels;

namespace MyDoctorAppointment
{
    public class DoctorAppointment
    {
        private readonly IDoctorService _doctorService;
        private readonly IPatientService _petientService;
        private readonly IAppointmentService _appointmentService;
        private AppointmentViewModel _viewModel;

        public DoctorAppointment()
        {
            _appointmentService = new AppointmentService();
            _doctorService = new DoctorService();
            _petientService = new PatientService();
        }

        private void TypeCheck(out Comands value)
        {
            while (true)
            {
                try
                {
                    value = (Comands)Convert.ToInt32(Console.ReadLine());
                    break;
                }
                catch
                {
                    Console.Write("Wrong type, please try again :");
                }
            }
        }

        private void TypeCheck(out int value)
        {
            while (true)
            {
                try
                {
                    value = Convert.ToInt32(Console.ReadLine());
                    break;
                }
                catch
                {
                    Console.Write("Wrong type, please try again :");
                }
            }
        }

        private void ShowInfo()
        {
            int id;
            Console.Write("Enter ID here: ");
            TypeCheck(out id);

            if (_viewModel == null)
            {
                Console.WriteLine($"There is no appointment with that id: {id}.");
            }
            else
            {
                _appointmentService.ShowInfo(_viewModel);
            }
        }

        private void GetAll()
        {
            var allModels = _appointmentService.GetAll();
            foreach (var model in allModels)
            {
                _appointmentService.ShowInfo(model);
            }
        }

        private void Create()
        {
            var doctor = new Doctor();
            var patient = new Patient();
            var appointment = new Appointment();

            Console.WriteLine("---- Doctor info ----");
            Console.Write("Enter Name: ");
            doctor.Name = Console.ReadLine();

            Console.Write("Enter surname: ");
            doctor.Surname = Console.ReadLine();

            Console.Write("Enter phone: ");
            doctor.Phone = Console.ReadLine();

            Console.Write("Enter email: ");
            doctor.Email = Console.ReadLine();

            Console.Write("Enter experience: ");
            while (true)
            {
                try
                {
                    doctor.Experience = Convert.ToByte(Console.ReadLine());
                    break;
                }
                catch
                {
                    Console.Write("Wrong type, please try again :");
                }
            }

            Console.Write("Enter Salary: ");
            while (true)
            {
                try
                {
                    doctor.Salary = Convert.ToDecimal(Console.ReadLine());
                    break;
                }
                catch
                {
                    Console.Write("Wrong type, please try again :");
                }
            }

            Console.Write("Enter doctor type: ");
            while (true)
            {
                try
                {
                    doctor.DoctorType = (DoctorTypes)Convert.ToInt32(Console.ReadLine());
                    break;
                }
                catch
                {
                    Console.Write("Wrong type, please try again :");
                }
            }

            Console.WriteLine("---- End ----");

            _doctorService.Create(doctor);

            Console.WriteLine();

            Console.WriteLine("---- Patient info ----");

            Console.Write("Enter Name: ");
            patient.Name = Console.ReadLine();

            Console.Write("Enter Surname: ");
            patient.Surname = Console.ReadLine();

            Console.Write("Enter phone: ");
            patient.Phone = Console.ReadLine();

            Console.Write("Enter email: ");
            patient.Email = Console.ReadLine();

            Console.Write("Enter Adress: ");
            patient.Address = Console.ReadLine();

            Console.Write("Additional Info: ");
            patient.AdditionalInfo = Console.ReadLine();

            Console.Write("IllnessType: ");
            while (true)
            {
                try
                {
                    patient.IllnessType = (IllnessTypes)Convert.ToInt32(Console.ReadLine());
                    break;
                }
                catch
                {
                    Console.Write("Wrong type, please try again :");
                }
            }

            _petientService.Create(patient);
            Console.WriteLine();

            Console.WriteLine("---- End ----");

            appointment.DateTimeForm = DateTime.Now;

            Console.Write("Enter description: ");
            appointment.Description = Console.ReadLine();

            appointment.Patient = patient;
            appointment.Doctor = doctor;

            _appointmentService.Create(appointment);
        }

        private void Update()
        {
            int id;
            Console.Write("Enter ID here: ");
            TypeCheck(out id);

            var doctor = new Doctor();
            var patient = new Patient();
            var appointment = new Appointment();

            Console.WriteLine("---- Doctor info ----");
            Console.Write("Enter Name: ");
            doctor.Name = Console.ReadLine();

            Console.Write("Enter surname: ");
            doctor.Surname = Console.ReadLine();

            Console.Write("Enter phone: ");
            doctor.Phone = Console.ReadLine();

            Console.Write("Enter email: ");
            doctor.Email = Console.ReadLine();

            Console.Write("Enter experience: ");
            while (true)
            {
                try
                {
                    doctor.Experience = Convert.ToByte(Console.ReadLine());
                    break;
                }
                catch
                {
                    Console.Write("Wrong type, please try again :");
                }
            }

            Console.Write("Enter Salary: ");
            while (true)
            {
                try
                {
                    doctor.Salary = Convert.ToDecimal(Console.ReadLine());
                    break;
                }
                catch
                {
                    Console.Write("Wrong type, please try again :");
                }
            }

            Console.Write("Enter doctor type: ");
            while (true)
            {
                try
                {
                    doctor.DoctorType = (DoctorTypes)Convert.ToInt32(Console.ReadLine());
                    break;
                }
                catch
                {
                    Console.Write("Wrong type, please try again :");
                }
            }

            Console.WriteLine("---- End ----");

            _doctorService.Update(id, doctor);

            Console.WriteLine();

            Console.WriteLine("---- Patient info ----");

            Console.Write("Enter Name: ");
            patient.Name = Console.ReadLine();

            Console.Write("Enter Surname: ");
            patient.Surname = Console.ReadLine();

            Console.Write("Enter phone: ");
            patient.Phone = Console.ReadLine();

            Console.Write("Enter email: ");
            patient.Email = Console.ReadLine();

            Console.Write("Enter Adress: ");
            patient.Address = Console.ReadLine();

            Console.Write("Additional Info: ");
            patient.AdditionalInfo = Console.ReadLine();

            Console.Write("IllnessType: ");
            while (true)
            {
                try
                {
                    patient.IllnessType = (IllnessTypes)Convert.ToInt32(Console.ReadLine());
                    break;
                }
                catch
                {
                    Console.Write("Wrong type, please try again :");
                }
            }


            _petientService.Update(id, patient);
            Console.WriteLine();

            Console.WriteLine("---- End ----");

            appointment.DateTimeForm = DateTime.Now;

            Console.WriteLine("Enter description: ");
            appointment.Description = Console.ReadLine();

            appointment.Patient = patient;
            appointment.Doctor = doctor;

            _doctorService.Update(doctor.Id, doctor);
            _petientService.Update(patient.Id, patient);
            _appointmentService.Update(id, appointment);
        }

        private void Get()
        {
            int id;
            Console.Write("Enter ID here: ");
            TypeCheck(out id);
            _viewModel = _appointmentService.Get(id);

            if (_viewModel == null)
            {
                Console.WriteLine($"There is no appointment with that id: {id}.");
            }
            else
            {

                _appointmentService.ShowInfo(_viewModel);
            }
        }

        private void Delete()
        {
            int id;
            Console.WriteLine("Please choose what do you want to delete: ");
            Console.WriteLine("1 - Appointment");
            Console.WriteLine("2 - Doctor");
            Console.WriteLine("3 - Patient");
            Console.Write(">");
            while (true)
            {
                string key = Console.ReadLine();
                switch (key)
                {
                    case "1":

                        Console.Write("Enter ID here: ");

                        TypeCheck(out id);
                        _appointmentService.Delete(id);
                        return;
                    case "2":
                        Console.Write("Enter ID here: ");
                        TypeCheck(out id);
                        _doctorService.Delete(id);
                        return;
                    case "3":
                        Console.Write("Enter ID here: ");
                        TypeCheck(out id);
                        _petientService.Delete(id);
                        return;
                    default:
                        Console.Write("Wrong type! Please try again: ");
                        break;
                }
            }
        }

        private void SaveType()
        {
            Console.Write("Enter your choise(1 - json, 2 - xml): ");
            string key;

            while (true)
            {
                key = Console.ReadLine();
                switch (key)
                {
                    case "1":
                        _doctorService.dataFormat = Data.Enums.DataFormat.Json;
                        _appointmentService.dataFormat = Data.Enums.DataFormat.Json;
                        _petientService.dataFormat = Data.Enums.DataFormat.Json;
                        return;
                    case "2":
                        _doctorService.dataFormat = Data.Enums.DataFormat.Xml;
                        _petientService.dataFormat = Data.Enums.DataFormat.Xml;
                        _appointmentService.dataFormat = Data.Enums.DataFormat.Xml;
                        return;
                    default:
                        Console.Write("Wrong type, plese try again: ");
                        break;
                }
            }
        }
        public void Menu()
        {
            Comands key;
            while (true)
            {
                Console.WriteLine("------ Doctor Appointment ------");
                Console.WriteLine("(1) Create");
                Console.WriteLine("(2) Get");
                Console.WriteLine("(3) GetAll");
                Console.WriteLine("(4) Update");
                Console.WriteLine("(5) Delete");
                Console.WriteLine("(6) ShowInfo");
                Console.WriteLine("(7) Writing format");
                Console.WriteLine("(8) Exit");
                Console.Write(">");
                TypeCheck(out key);

                switch (key)
                {
                    case Comands.Create:
                        Create();
                        break;
                    case Comands.Get:
                        Get();
                        break;
                    case Comands.GetAll:
                        GetAll();
                        break;
                    case Comands.Update:
                        Update();
                        break;
                    case Comands.Delete:
                        Delete();
                        break;
                    case Comands.ShowInfo:
                        ShowInfo();
                        break;
                    case Comands.SaveType:
                        SaveType();
                        break;
                    case Comands.Exit:
                        return;
                }
            }

        }
    }
}
