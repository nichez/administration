using System.Collections.Generic;
using Itc.Am.Common.Models;

namespace Itc.Am.DL.Interfaces
{
    public interface IVacationRepository
    {
        void VacationAdd(Vacation request);
        Vacation VacationGetByUserId(int id);
        Vacation VacationGetById(int id);
        IEnumerable<Vacation> GetAll();
        void UpdateVacation(Vacation request);
        void Remove(int id);
    }
}