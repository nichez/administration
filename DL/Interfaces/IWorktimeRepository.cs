using System.Collections.Generic;
using Itc.Am.Common.Models;

namespace Itc.Am.DL.Interfaces
{
    public interface IWorktimeRepository
    {
        void AddWorktime(WorktimeRecord record);
        WorktimeRecord GetRecordById(int id);
        WorktimeRecord GetRecById(int id);
        IEnumerable<WorktimeRecord> GetAll();
    }
}