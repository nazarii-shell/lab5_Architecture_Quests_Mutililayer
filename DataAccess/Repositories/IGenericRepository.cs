using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public interface IGenericRepository<TModel> where TModel : class
    {
        public TModel GetById(int id);

        public void Create(TModel model);

        public void Update(TModel model);

        public void Delete(int id);
    }
}
