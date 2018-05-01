using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Itc.Am.Common.Models;

namespace Itc.Am.Common.ViewModels
{
    public class AllReportsVm
    {
        public WorktimeRecord Record { get; set; }
        public IEnumerable<WorktimeRecord> Records { get; set; }
    }
}
