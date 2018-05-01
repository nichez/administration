using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Itc.Am.Common.Models;
using Itc.Am.DL.Infrastructure;
using Itc.Am.DL.Interfaces;

namespace Itc.Am.DL.Repositories
{
    public class VacationRepository : RepositoryBase<Vacation>, IVacationRepository
    {
        public VacationRepository(IDbFactory dbFactory) : base(dbFactory) { }

        public void VacationAdd(Vacation request)
        {
            DbContext.Vacations.Add(request);
            DbContext.Commit();
        }

        public Vacation VacationGetByUserId(int id)
        {
            var request = DbContext.Vacations.Where(c => c.UserId == id).FirstOrDefault();

            return request;
        }

        public Vacation VacationGetById(int id)
        {
            var request = DbContext.Vacations.Where(c => c.Id == id).FirstOrDefault();

            return request;
        }

        public new IEnumerable<Vacation> GetAll()
        {
            var requests = DbContext.Vacations.ToList();
            return requests;
        }

        public void UpdateVacation(Vacation request)
        {
            DbContext.Entry(request).State = EntityState.Modified;
            request.DateUpdated = DateTime.Now;
            Update(request);
            DbContext.Commit();
        }

        public void Remove(int id)
        {
            var request = DbContext.Vacations.Where(c => c.Id == id).FirstOrDefault();
            DbContext.Vacations.Remove(request);
            DbContext.Commit();
        }

    }
}
