using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Itc.Am.BL.Interfaces;
using Itc.Am.Common.Models;
using Itc.Am.DL.Interfaces;

namespace Itc.Am.BL
{
    public class WorktimeService : IWorktimeService
    {
        private readonly IWorktimeRepository worktimeRepository;

        public WorktimeService(IWorktimeRepository worktimeRepository)
        {
            this.worktimeRepository = worktimeRepository;
        }

        public void Add(WorktimeRecord record)
        {
            worktimeRepository.AddWorktime(record);
        }

        public WorktimeRecord GetRecord(int id)
        {
            return worktimeRepository.GetRecordById(id);
        }

        public WorktimeRecord GetRec(int id)
        {
            return worktimeRepository.GetRecById(id);
        }

        public IEnumerable<WorktimeRecord> GetAllRecords()
        {
            var records = worktimeRepository.GetAll();
            return records;
        }
    }
}
