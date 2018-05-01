using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Itc.Am.Common.Models;

namespace Itc.Am.Common.ViewModels
{
    public class MyReportVm
    {
        public int UserId { get; set; }
        public WorktimeRecord MyReport { get; set; }
        public IEnumerable<WorktimeRecord> MyReports { get; set; }
    }
}
