
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BethanysPieShop.Models
{
    public class PieRepository : IPieRepository
    {
        private readonly AppDbContext _appDbContext;

        public PieRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public List<Pie> AllPies => _appDbContext.Pies.Include(c => c.Category).ToList();


        public List<Pie> PiesOfTheWeek => _appDbContext.Pies.Include(c => c.Category).Where(p => p.IsPieOfTheWeek).ToList();

        public Pie GetById(int pieId) => _appDbContext.Pies.FirstOrDefault(x => x.PieId == pieId);

    }
}
