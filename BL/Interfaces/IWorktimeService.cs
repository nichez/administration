using System.Collections.Generic;
using Itc.Am.Common.Models;

namespace Itc.Am.BL.Interfaces
{
    public interface IWorktimeService
    {
        void Add(WorktimeRecord record);
        WorktimeRecord GetRecord(int id);
        WorktimeRecord GetRec(int id);
        IEnumerable<WorktimeRecord> GetAllRecords();
    }
}