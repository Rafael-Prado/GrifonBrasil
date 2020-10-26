using System;
using System.Collections.Generic;
using System.Text;

namespace cadastrocidades.Repository.Data.Persistencia.Repositories
{
    public class BaseRepository
    {
        protected readonly AppDbContext _context;
        public BaseRepository(AppDbContext context)
        {
            _context = context;
        }
    }
}
