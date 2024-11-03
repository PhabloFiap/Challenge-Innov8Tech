using Challenge_Innov8Tech.Entities;

namespace Challenge_Innov8Tech.Interfaces
{
    public interface IRamoAplicationService
    {
        IEnumerable<RamoEntity> GetAll();
        RamoEntity GetById(int id);
        RamoEntity Insert(RamoEntity ramo);
        RamoEntity Update(RamoEntity ramo);
        bool Delete(int id);
    }
}