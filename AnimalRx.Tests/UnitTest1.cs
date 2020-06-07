using AnimalRx.Services.DataAccess;
using AnimalRx.Services.Models;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace AnimalRx.Tests
{
    public class Tests
    {
        AnimalRxContext _context;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            DbContextOptionsBuilder<AnimalRxContext> dbContextOptions = new DbContextOptionsBuilder<AnimalRxContext>();
            dbContextOptions.UseLazyLoadingProxies()
                .UseNpgsql("User ID =AnimalRx;Password=animalrx;Server=localhost;Port=5432;Database=AnimalRx;Integrated Security=true;Pooling=true;")
                .UseSnakeCaseNamingConvention();
            _context = new AnimalRxContext(dbContextOptions.Options);
        }

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            IPatientRepository repository = new PatientRepository(_context);
            repository.InsertPatient(new Patient()
            {
                Name = "Patient Name 1",
                Description = "Test Description 1",
                Diagnosis = "Test diagnosis 1",
                DateAdmitted = DateTime.Now,
                Vaccines = new List<Vaccine>() { 
                    new Vaccine() { Type = VaccineType.ARV, 
                        Dose1Required = true, 
                        Dose1TargetDate = DateTime.Now.AddDays(5),
                        Dose2Required = true,
                        Dose2TargetDate = DateTime.Now.AddDays(21),
                    } 
                }
            });

            repository.InsertPatient(new Patient()
            {
                Name = "Patient Name 2",
                Description = "Test Description 2",
                Diagnosis = "Test diagnosis 2",
                DateAdmitted = DateTime.Now,
                Vaccines = new List<Vaccine>() {
                    new Vaccine() { Type = VaccineType.ARV,
                        Dose1Required = true,
                        Dose1TargetDate = DateTime.Now.AddDays(1),
                        Dose2Required = true,
                        Dose2TargetDate = DateTime.Now.AddDays(2),
                    },
                    new Vaccine() { Type = VaccineType.FiveInOne,
                    Dose1Required = true,
                    Dose1TargetDate = DateTime.Now.AddDays(1),
                    Dose2Required = true,
                    Dose2TargetDate = DateTime.Now.AddDays(21),
                    }
                }
                                
            });

            repository.InsertPatient(new Patient()
            {
                Name = "Patient Name 3",
                Description = "Test Description 3",
                Diagnosis = "Test diagnosis 3",
                DateAdmitted = DateTime.Now,
                Vaccines = new List<Vaccine>() {
                    new Vaccine() { Type = VaccineType.ARV,
                        Dose1Required = true,
                        Dose1TargetDate = DateTime.Now.AddDays(7),
                        Dose2Required = true,
                        Dose2TargetDate = DateTime.Now.AddDays(21),
                    }
                }
            });

            var dueVaccines = repository.GetAllDueVaccines();
        }
    }
}