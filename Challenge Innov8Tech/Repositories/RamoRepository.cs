using Challenge_Innov8Tech.Entities;
using Challenge_Innov8Tech.Infrastructure;
using Challenge_Innov8Tech.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Challenge_Innov8Tech.Repositories
{
    public class RamoRepository: IRamoRepository
    {
        private readonly ApplicationContext _context;

        public RamoRepository(ApplicationContext context)
        {
            _context = context;
        }

        public IEnumerable<RamoEntity> GetAll()
        {
            return _context.Ramos.Include(r=>r.Cliente).ToList();
        }

        public RamoEntity GetById(int id)
        {
            return _context.Ramos.Include(r => r.Cliente).FirstOrDefault(r => r.Id == id);
        }

        public RamoEntity Insert(RamoEntity ramo)
        {
            _context.Ramos.Add(ramo);
            _context.SaveChanges();

            // Carrega o cliente relacionado após a inserção
            ramo.Cliente = _context.Clientes.Find(ramo.ClienteId);
            return ramo;
        }


        public RamoEntity Update(int id, RamoEntity ramo)
        {
            var Ramo = _context.Ramos.Include(x=> x.Cliente).FirstOrDefault(x=> x.Id == id);

            if (Ramo is not null)
            {
                Ramo.Nome = ramo.Nome;
                Ramo.Cliente = ramo.Cliente;
                _context.Update(Ramo);
                _context.SaveChanges();
                return Ramo;
            }
            return ramo;
        }

        public void Delete(int id)
        {
            var ramo = _context.Ramos.Find(id);
            _context.Ramos.Remove(ramo);
            _context.SaveChanges();
        }

        IEnumerable<RamoEntity> IRamoRepository.GetAll()
        {
            return _context.Ramos;
        }

    

        public RamoEntity Update(RamoEntity ramo)
        {
            _context.Ramos.Update(ramo);    
            _context.SaveChanges();
            return ramo;
        }
    }
}
