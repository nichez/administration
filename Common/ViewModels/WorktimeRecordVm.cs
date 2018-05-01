using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Type = Itc.Am.Common.Models.Type;

namespace Itc.Am.Common.ViewModels
{
    public class WorktimeRecordVm
    {
        public int Id { get; set; }
        public int UserId { get; set; }

        [Required(ErrorMessage = "Date is Required:")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Time is Required:")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH-mm-ss}")]
        public DateTime Time { get; set; }

        public string Info { get; set; }

        [Required(ErrorMessage = "Type is Required:")]
        public Type Type { get; set; }
    }
}
