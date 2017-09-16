using DistanceLearningDomain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DistanceLearningDomain.Repository
{
    public interface IGeneralByStudCatRepository : IRepository<GeneralByStudCat>
    {
        IEnumerable<GeneralByStudCat> GetGeneralByStudCat();
        IEnumerable<GeneralByStudCat> GetGeneralByStudCat(int studCatId);
        IEnumerable<GeneralByStudCat> GetGeneralGeneralByStudCatByAward(int awardId);
        bool ConfirmGeneralByStudCat(int catId, int awardId);
        GeneralByStudCat GetGeneralByStudCatById(int Id);
        GeneralByStudCat GetGeneralByStudCat(int catId, int awardId);
    }
}

