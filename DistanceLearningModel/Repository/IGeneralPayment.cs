using DistanceLearningDomain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DistanceLearningDomain.Repository
{
    public interface IGeneralPayment : IRepository<GeneralPayment>
    {
        IEnumerable<GeneralPayment> GetAllGeneralPayment();
        bool ConfirmGeneralPayment(string payDescription);
        bool ConfirmSchoolFee(int Id);
        GeneralPayment GetGeneralPayment(string paDescription);
        GeneralPayment GetGeneralPayment(int Id);
    }
}

