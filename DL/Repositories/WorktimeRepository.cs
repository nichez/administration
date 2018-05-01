using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Itc.Am.Common.Models;
using Itc.Am.DL.Infrastructure;
using Itc.Am.DL.Interfaces;

namespace Itc.Am.DL.Repositories
{
    public class WorktimeRepository : RepositoryBase<WorktimeRecord>, IWorktimeRepository
    {
        public WorktimeRepository(IDbFactory dbFactory) : base(dbFactory) { }

        public void AddWorktime(WorktimeRecord record)
        {
            DbContext.WorktimeRecords.Add(record);
            DbContext.Commit();
        }

        public WorktimeRecord GetRecordById(int id)
        {
            var record = DbContext.WorktimeRecords.Where(c => c.UserId == id).FirstOrDefault();

            return record;
        }

        public WorktimeRecord GetRecById(int id)
        {
            var record = DbContext.WorktimeRecords.Where(c => c.Id == id).FirstOrDefault();

            return record;
        }

        public new IEnumerable<WorktimeRecord> GetAll()
        {
            var records = DbContext.WorktimeRecords.ToList();
            return records;
        }
    }
}
