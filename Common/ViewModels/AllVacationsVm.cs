using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Itc.Am.Common.Models;

namespace Itc.Am.Common.ViewModels
{
    public class AllVacations
    {
        public Vacation Vac { get; set; }
        public IEnumerable<Vacation> Vacations { get; set; }
    }
}
