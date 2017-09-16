using DistanceLearningDomain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DistanceLearningDomain.Repository
{
    public interface IGeneralByLevelRepository : IRepository<GeneralByLevel>
    {
        IEnumerable<GeneralByLevel> GetGeneralByLevel();
        IEnumerable<GeneralByLevel> GetGeneralByLevel(int levId);
        IEnumerable<GeneralByLevel> GetGeneralByLevelByAward(int awardId);
        bool ConfirmGeneralByLevel(int levId,int awardId);
        GeneralByLevel GetGeneralByLevelById(int Id);
        GeneralByLevel GetGeneralByLevel(int levId,int awardId);
    }
}