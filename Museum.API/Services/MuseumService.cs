using MuseumAPI.Domain.Models;
using MuseumAPI.Domain.Repositories;
using MuseumAPI.Domain.Services;
using MuseumAPI.Domain.Services.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MuseumAPI.Services
{
    public class MuseumService : IMuseumService
    {
        private readonly IMuseumRepository _museumRepository;
        private readonly IUnitOfWork _unitOfWork;

        public MuseumService(IMuseumRepository museumRepository, IUnitOfWork unitOfWork)
        {
            _museumRepository = museumRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Museum>> ListAsync()
        {
            return await _museumRepository.ListAsync();
        }

        public async Task<Museum> ListByIdAsync(int id)
        {
            return await _museumRepository.ListByIdAsync(id);
        }


        
       

        public async Task<MuseumResponse> SaveAsync(Museum museum)
        {
            try
            {
                await _museumRepository.AddAsync(museum);
                await _unitOfWork.SaveChangesCompleteAsync();

                return new MuseumResponse(museum);
            }
            catch (Exception ex)
            {
                // Place for do logging
                return new MuseumResponse($"Exception occurred saving the museum: {ex.Message}");
            }
        }

        public async Task<MuseumResponse> UpdateAsync(int id, Museum museum)
        {
            var existingMuseum = await _museumRepository.ListByIdAsync(id);

            if (existingMuseum == null)
                return new MuseumResponse("Museum not found.");

            existingMuseum.Name = museum.Name;
            existingMuseum.Address = museum.Address;


            try
            {
                _museumRepository.Update(existingMuseum);
                await _unitOfWork.SaveChangesCompleteAsync();

                return new MuseumResponse(existingMuseum);
            }
            catch (Exception ex)
            {
                // Place for do logging
                return new MuseumResponse($"Exception occurred updating the museum: {ex.Message}");
            }
        }
        public Task<MuseumResponse> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

    }
}
