using DistanceLearningDomain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DistanceLearningDomain.Repository
{
    public interface IPayConfigRepository : IRepository<PayCategory>
    {
        IEnumerable<GeneralPayment> GetAllGeneralPayment();
        bool ConfirmSchoolFee(string payDescription);
        bool ConfirmSchoolFee(int Id);
        SchoolPayment GetSchoolFee(string paDescription);
        SchoolPayment GetSchoolFee(int Id);
    }
}

