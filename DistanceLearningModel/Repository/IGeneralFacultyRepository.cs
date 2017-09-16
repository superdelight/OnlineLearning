using DistanceLearningDomain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DistanceLearningDomain.Repository
{
    public interface IGeneralFacultyRepository : IRepository<GeneralByFaculty>
    {
        IEnumerable<GeneralByFaculty> GetGeneralByFaculty();
        IEnumerable<GeneralByFaculty> GetAllGeneralByPayment(int payId);
        IEnumerable<GeneralByFaculty> GetAllGeneralAll(int awardId);
        IEnumerable<GeneralByFaculty> GetAllGeneralAll(int awardId,int sessId);
        bool ConfirmGenralAll(int Id);
        bool ConfirmGenralAll(int awardId,int PayId,int FacId);
        GeneralByFaculty GetGeneralByFacultyUsingId(int Id);
        GeneralByFaculty GetGeneralByFacultyByDescription(string paymentDescription);
        GeneralByFaculty GetGeneralByFaculty(int awardId, int PayId,int facId);
        GeneralByFaculty GetGeneralByFaculty(int awardId, int facId,bool? IsFull);
        GeneralByFaculty GetGeneralByFaculty(int awardId, int facId, bool? IsFull,int sessId);
    }
}

