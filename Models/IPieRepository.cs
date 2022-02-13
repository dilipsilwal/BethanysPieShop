using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BethanysPieShop.Models
{
    public interface IPieRepository
    {
        List<Pie> AllPies { get; }
        List<Pie> PiesOfTheWeek { get; }
        Pie GetById(int pieId);
    }
}
