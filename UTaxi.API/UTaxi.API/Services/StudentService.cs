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

        public async Task<SaveStudentResponse> UpdateAsync(int id, Student student)
        {
            var existingStudent = await _studentRepository.FindByIdAsync(id);

            if (existingStudent == null)
            {
                return new SaveStudentResponse("Student not found");
            }

            existingStudent.Name = student.Name;
            try
            {
                _studentRepository.Update(existingStudent);

                return new SaveStudentResponse(existingStudent);
            }
            catch (Exception e)
            {
                return new SaveStudentResponse($"An error occurred while updating the student: {e.Message}");
            }
        }

        public async Task<StudentResponse> DeleteAsync(int id)
        {
            var existingStudent = await _studentRepository.FindByIdAsync(id);

            if (existingStudent == null)
            {
                return new StudentResponse("Student not found");
            }
            
            try
            {
                _studentRepository.Remove(existingStudent);

                return new StudentResponse(existingStudent);
            }
            catch (Exception e)
            {
                return new StudentResponse($"An error occurred while deleting the student: {e.Message}");
            }
        }
    }
}