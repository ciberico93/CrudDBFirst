using AppCrudAdo_0209.Context;
using AppCrudAdo_0209.Models;
using AppCrudAdo_0209.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace AppCrudAdo_0209.Repository
{
    public class ContactoRepository : IContactoRepository<Contacto>
    {

        private readonly DbcrudadoContext _dbcontext;
        private readonly DbSet<Contacto> _dbset;


        public ContactoRepository(DbcrudadoContext dbcontext)
        {
            _dbcontext = dbcontext;
            _dbset = dbcontext.Set<Contacto>();
        }

        public async Task<Contacto> Create(Contacto entity)
        {
            Contacto contacto = new Contacto()
            {
                Nombre = entity.Nombre,
                Telefono = entity.Telefono,
                Correo = entity.Correo
            };

           EntityEntry<Contacto> result = await _dbcontext.Contactos.AddAsync(contacto);
            await _dbcontext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<bool> Delete(int id)
        {
            var contacto = await GetbyID(id);
            if (contacto == null)
            {
                return false;
            }

            _dbcontext.Remove(contacto);
            await _dbcontext.SaveChangesAsync();
            return true;
        }

        public async Task<List<Contacto>> GetAll()
        {
            return await _dbset.ToListAsync();  
        }

        public async Task<Contacto> GetbyID(int id)
        {
            return await _dbset.FirstAsync(x => x.IdContacto == id);

         }

        public async Task<Contacto> Update(Contacto entity)
        {
            var contacto = await GetbyID(entity.IdContacto);
            if (contacto == null)
            {
                return null;
            }
            contacto.Nombre = entity.Nombre;
            contacto.Telefono = entity.Telefono;
            contacto.Correo = entity.Correo;

            await _dbcontext.SaveChangesAsync();
            return contacto;


        }
    }
}
