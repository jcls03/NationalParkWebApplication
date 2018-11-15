using Capstone.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.DAL
{
    public interface IParkDAL
    {
        // gets all parks
        IList<Park> GetParks();
        Park GetPark(string code);
    }
}
