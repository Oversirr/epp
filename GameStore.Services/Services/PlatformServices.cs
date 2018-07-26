using System.Collections.Generic;
using AutoMapper;
using GameStore.Core.Entity;
using GameStore.Infrastructure.Data;
using GameStore.Infrastructure.Repository;
using GameStore.Services.DTO;
using GameStore.Services.Interfaces;

namespace GameStore.Services.Services
{
    public class PlatformServices : IPlatformServices
    {
        private UnitOfWork _unitOfWork;

        public PlatformServices()
        {
            _unitOfWork = new UnitOfWork(new GameStoreDbContext());
        }


        public void CreateNewPlatformType(PlatformDTO platform)
        {
            PlatformType entity = new PlatformType();
            Mapper.Map(platform, entity);
            _unitOfWork.PlatformTypeRepository.Create(entity);
        }

        public void EditPlatformType(PlatformDTO platform)
        {
            var platformToEdit = _unitOfWork.PlatformTypeRepository.FindById(platform.Id);
            Mapper.Map(platform, platformToEdit);
            _unitOfWork.PlatformTypeRepository.Update(platformToEdit);
            _unitOfWork.Commit();
        }

        public void DeletePlatformType(PlatformDTO platform)
        {
            var platformToDelete = _unitOfWork.PlatformTypeRepository.FindById(platform.Id);
            _unitOfWork.PlatformTypeRepository.Remove(platformToDelete);
            _unitOfWork.Commit();
        }

        public IEnumerable<PlatformDTO> GetAllPlatformTypes()
        {
            IEnumerable<PlatformType> platforms = _unitOfWork.PlatformTypeRepository.GetAll();
            IEnumerable<PlatformDTO> result = new List<PlatformDTO>();
            Mapper.Map(platforms, result);
            return result;
        }
    }
}
