using System.Collections.Generic;
using Itc.Am.Common.Models;

namespace Itc.Am.BL.Interfaces
{
    public interface IVacationService
    {
        void Add(Vacation request);
        Vacation GetVacationByUserId(int id);
        Vacation GetVacationById(int id);
        IEnumerable<Vacation> GetAllVacations();
        void Update(Vacation request);
        void Delete(int id);
    }
}