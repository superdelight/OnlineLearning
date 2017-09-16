using DistanceLearningDomain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DistanceLearningDomain.Repository
{
    public interface IApplicantPayment : IRepository<ApplicantPayment>
    {
        IEnumerable<ApplicantPayment> GetAllApplicantPayment();
        bool ConfirmApplicant(string payDescription);
        bool ConfirmApplicantPayment(int Id);
        ApplicantPayment GetApplicantPayment(string paDescription);
        ApplicantPayment GetApplicantPayment(int Id);

    }
}

