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
    public class VacationService : IVacationService
    {
        private readonly IVacationRepository vacationRepository;

        public VacationService(IVacationRepository vacationRepository)
        {
            this.vacationRepository = vacationRepository;
        }

        public void Add(Vacation request)
        {
            vacationRepository.VacationAdd(request);
        }

        public Vacation GetVacationByUserId(int id)
        {
            return vacationRepository.VacationGetByUserId(id);
        }

        public Vacation GetVacationById(int id)
        {
            return vacationRepository.VacationGetById(id);
        }

        public IEnumerable<Vacation> GetAllVacations()
        {
            var requests = vacationRepository.GetAll();
            return requests;
        }

        public void Update(Vacation request)
        {
            vacationRepository.UpdateVacation(request);
        }

        public void Delete(int id)
        {
            vacationRepository.Remove(id);
        }

    }
}
