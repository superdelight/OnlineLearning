using DistanceLearningDomain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DistanceLearningDomain.Repository
{
    public interface ISMTPProxyRepository : IRepository<SMTPProxy>
    {
       
        bool ConfirmSMTP(string detail);
        SMTPProxy GetSMTP(string detail);
    }
}

