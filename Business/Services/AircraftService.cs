using AutoMapper;
using AutoMapper.QueryableExtensions;
using Business.Models;
using Data.Entities;
using Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace Business.Services
{
    public class AircraftService : IAircraftService
    {
        private readonly IGenericRepository<AircraftDetail> repository;
        private readonly IFileService fileService;
        private readonly IMapper mapper;

        public AircraftService(IGenericRepository<AircraftDetail> repository,
            IFileService fileService,
            IMapper mapper)
        {
            this.repository = repository;
            this.fileService = fileService;
            this.mapper = mapper;
        }

        public async Task<PagedList<AircraftDetailModel>> GetAll(AircraftParams aircraftParams)
       {
            var search = aircraftParams.Search;
            var aircraftDetails = repository.GetAll();
            if (!string.IsNullOrEmpty(search))
                aircraftDetails = aircraftDetails.Where(x => x.Make.Contains(search) || x.Model.Contains(search) || x.Registration.Contains(search));

                return await PagedList<AircraftDetailModel>.CreateAsync(aircraftDetails.ProjectTo<AircraftDetailModel>(mapper.
                ConfigurationProvider).AsNoTracking(),
                     aircraftParams.Skip, aircraftParams.PageSize);
        }

        public async Task<AircraftDetailModel> GetById(int id)
        {
            var aircraftDetail = await repository.GetAll().FirstOrDefaultAsync(x => x.Id == id);
            return mapper.Map<AircraftDetailModel>(aircraftDetail);
        }

        public async Task Add(AircraftDetailModel model)
        {
            var aircraftDetail = mapper.Map<AircraftDetail>(model);
            if (!string.IsNullOrEmpty(aircraftDetail.FileSource))
            {
                var file = fileService.Base64ToImage(model.FileSource);
                aircraftDetail.FileSource = file;
            }
            await repository.Create(aircraftDetail);
        }

        public async Task Update(AircraftDetailModel model)
        {
            var aircraftDetail = mapper.Map<AircraftDetail>(model);
            if (!string.IsNullOrEmpty(model.FileSource))
            {
                var file = fileService.Base64ToImage(aircraftDetail.FileSource);
                aircraftDetail.FileSource = file;
            }
            await repository.Update(aircraftDetail);
        }

        public async Task Delete(int id)
        {
            await repository.Delete(id);
        }
    }
}
