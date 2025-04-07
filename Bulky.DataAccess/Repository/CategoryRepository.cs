using Bulky.DataAccess.Data;
using Bulky.DataAccess.Repository.IRepository;
using Bulky.Models.Models;

namespace Bulky.DataAccess.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private ApplicationDbContext _db;

        /*
         el repositorio de categoría es un componente especializado que se encarga de todas las operaciones relacionadas con la entidad "Categoría". Actúa como un intermediario entre la aplicación y la fuente de datos, proporcionando una interfaz clara y encapsulando la lógica de acceso a datos. Esto ayuda a mantener el código organizado, modular y fácil de mantener.
         */

        public CategoryRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }


        public void Update(Category obj)
        {
            _db.Categories.Update(obj);
        }
    }
}
