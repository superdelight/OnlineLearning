using DistanceLearningDomain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DistanceLearningDomain.Repository
{
    public interface IPayCategory : IRepository<PayCategory>
    {
        bool ConfirmPayCategory(string payDescription);
        PayCategory GetPayCategory(string paDescription);
       
    }
}
