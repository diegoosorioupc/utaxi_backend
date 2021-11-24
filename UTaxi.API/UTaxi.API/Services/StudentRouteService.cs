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
    }
}