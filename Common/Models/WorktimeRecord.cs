using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itc.Am.Common.Models
{
    public enum Type
    {
        Arrival,
        Departure,
        PauseOut,
        PauseIn,
        LunchBreakOut,
        LunchBreakIn
    }

    public class WorktimeRecord
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime Date { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH-mm-ss}")]
        public DateTime Time { get; set; }

        public string Info { get; set; }
        public Type Type { get; set; }

        public virtual UserModel Users { get; set; }
    }
}
