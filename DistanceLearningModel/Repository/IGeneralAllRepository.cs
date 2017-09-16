using DistanceLearningDomain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DistanceLearningDomain.Repository
{
    public interface IGeneralAllRepository : IRepository<GenralAll>
    {
        IEnumerable<GenralAll> GetGenralAll();
        IEnumerable<GenralAll> GetAllGenralAllByPayment(int payId);
        IEnumerable<GenralAll> GetAllGenralAll(int awardId);
        bool ConfirmGenralAll(int Id);
        bool ConfirmGenralAll(int awardId,int PayId);
        GenralAll GetGenralAllById(int Id);
        GenralAll GetGenralAllById(int awardId, int PayId);
    }
}

