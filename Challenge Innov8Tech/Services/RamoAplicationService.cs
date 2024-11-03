using Challenge_Innov8Tech.Entities;
using Challenge_Innov8Tech.Interfaces;

namespace Challenge_Innov8Tech.Services
{
    public class RamoAplicationService: IRamoAplicationService
    {
        private readonly IRamoRepository _ramoRepository;

        public RamoAplicationService(IRamoRepository ramoRepository)
        {
            _ramoRepository = ramoRepository;
        }

        public RamoEntity GetById(int id)
        {
            return _ramoRepository.GetById(id);
        }

        public IEnumerable<RamoEntity> GetAll()
        {
            return _ramoRepository.GetAll();
        }

        public RamoEntity Insert(RamoEntity ramo)
        {
            return _ramoRepository.Insert(ramo);
        }
        public RamoEntity Update(RamoEntity ramo)
        {
            return _ramoRepository.Update(ramo);
        }
        public void Delete(int id)
        {
            _ramoRepository.Delete(id);
        }

        bool IRamoAplicationService.Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
