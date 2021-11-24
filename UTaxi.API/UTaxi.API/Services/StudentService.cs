using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UTaxi.API.Domain.Models;
using UTaxi.API.Domain.Repository;
using UTaxi.API.Domain.Services;
using UTaxi.API.Domain.Services.Comunications;

namespace UTaxi.API.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;


        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<IEnumerable<Student>> ListAsync()
        {
            return await _studentRepository.ListAsync();
        }

        public async Task<SaveStudentResponse> SaveAsync(Student student)
        {
            try
            {
                await _studentRepository.AddAsync(student);

                return new SaveStudentResponse(student);
            }
            catch (Exception e)
            {
                return new SaveStudentResponse($"An error occurred while saving the student: {e.Message}");
            }
        }
    }
}