using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cadastrocidades.Domain.Models;
using cadastrocidades.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace cadastrocidades.Repository.Data.Persistencia.Repositories
{
    public class CidadeRepository : BaseRepository, ICidadeRepository
    {
        public CidadeRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Cidade>> ListAsyncCidades()
        {
            var result = await _context.Cidades
                .AsNoTracking()
                .AsQueryable()
                .Include(m => m.CidadesFronteira).ToListAsync();

            return result;
        }

        public int AddAsync(Cidade cidade)
        {
            var cidaderesult = _context.Cidades.AddAsync(cidade);
            _context.SaveChanges();
            return cidaderesult.Result.Entity.Id;
        }

        public Cidade FindByIdAsync(int id)
        {
            return _context.Cidades.Find(id);
        }

        public void Remove(Cidade cidade)
        {
            _context.Cidades.Remove(cidade);
        }

        public bool ExisteCidade(string nomeCidade)
        {
           return _context.Cidades.Any(p => p.NomeCidade == nomeCidade);

        }

        public Cidade GetCidadeNome(string nomeCidade)
        {
            var result = _context.Cidades
                .AsNoTracking()
                .AsQueryable()
                .Include(m => m.CidadesFronteira)
                .Where(p => p.NomeCidade == nomeCidade)
                .FirstOrDefault();

            return result;
        }

        public int UpdateCidade(Cidade cidadeUpdate)
        {
            _context.Entry(cidadeUpdate).State = EntityState.Modified;
            var cidaderesult = _context.Cidades.Update(cidadeUpdate);
            _context.SaveChanges();
            return cidaderesult.Entity.Id;
        }
    }
}
