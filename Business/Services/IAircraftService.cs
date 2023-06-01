using Business.Models;
using Data.Entities;

namespace Business.Services
{
    public interface IAircraftService
    {
        Task Add(AircraftDetailModel aircraftDetail);
        Task Delete(int id);
        Task<PagedList<AircraftDetailModel>> GetAll(AircraftParams aircraftParams);
        Task Update(AircraftDetailModel aircraftDetail);
        Task<AircraftDetailModel> GetById(int id);
    }
}