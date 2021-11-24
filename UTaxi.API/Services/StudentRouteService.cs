using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UTaxi.API.Domain.Models;
using UTaxi.API.Domain.Repository;
using UTaxi.API.Domain.Services;
using UTaxi.API.Domain.Services.Comunications;

namespace UTaxi.API.Services
{
    public class StudentRouteService : IStudentRouteService
    {
        private readonly IStudentRouteRepository _studentRouteRepository;

        public StudentRouteService(IStudentRouteRepository studentRouteRepository)
        {
            _studentRouteRepository = studentRouteRepository;
        }

        public async Task<IEnumerable<StudentRoute>> ListAsync()
        {
            return await _studentRouteRepository.ListAsync();
        }

        public async Task<SaveStudentRouteResponse> SaveAsync(StudentRoute studentRoute)
        {
            try
            {
                await _studentRouteRepository.AddAsync(studentRoute);

                return new SaveStudentRouteResponse(studentRoute);
            }
            catch (Exception e)
            {
                return new SaveStudentRouteResponse($"An error occurred while saving the student-route: {e.Message}");
            }
        }

        public async Task<SaveStudentRouteResponse> UpdateAsync(int id, StudentRoute studentRoute)
        {
            var existingStudentRoute = await _studentRouteRepository.FindByIdAsync(id);

            if (existingStudentRoute == null)
            {
                return new SaveStudentRouteResponse("Student-Route not found");
            }

            existingStudentRoute.Id = studentRoute.Id;
            try
            {
                _studentRouteRepository.Update(existingStudentRoute);

                return new SaveStudentRouteResponse(existingStudentRoute);
            }
            catch (Exception e)
            {
                return new SaveStudentRouteResponse($"An error occurred while updating the Student-Route: {e.Message}");
            }
        }

        public async Task<StudentRouteResponse> DeleteAsync(int id)
        {
            var existingStudentRoute = await _studentRouteRepository.FindByIdAsync(id);

            if (existingStudentRoute == null)
            {
                return new StudentRouteResponse("Student-Route not found");
            }
            
            try
            {
                _studentRouteRepository.Update(existingStudentRoute);

                return new StudentRouteResponse(existingStudentRoute);
            }
            catch (Exception e)
            {
                return new StudentRouteResponse($"An error occurred while deleting the Student-Route: {e.Message}");
            }
        }
    }
}