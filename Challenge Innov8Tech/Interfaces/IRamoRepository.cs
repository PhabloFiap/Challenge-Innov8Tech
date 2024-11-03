using Challenge_Innov8Tech.Entities;

namespace Challenge_Innov8Tech.Interfaces
{
    public interface IRamoRepository
    {
        IEnumerable<RamoEntity> GetAll();
        RamoEntity GetById(int id);
        RamoEntity Insert(RamoEntity ramo);
        RamoEntity Update(RamoEntity ramo);
        void Delete(int id);
    }
}
