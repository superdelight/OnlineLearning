using AutoMapper;
using DistanceLearningCore.Model.Administration;
using DistanceLearningDomain.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace DistanceLearningCore.Repository
{
    public class AwardRepository : Repository<DistanceLearningDomain.Model.Award,Award>,IAwardRepository
    {
        private ElearningAdminEntities Context;
        public AwardRepository(ElearningAdminEntities Context)
            :base(Context)
        {
            Mapper.CreateMap<DistanceLearningDomain.Model.Award, Award>();
            Mapper.CreateMap<Award, DistanceLearningDomain.Model.Award>();
            this.Context = Context;   
        }
        public IEnumerable<DistanceLearningDomain.Model.Award> GetAllAwardInDepartment(int deptId)
        {
            var rawApplicant = (from c in Context.Awards from d in c.Programmes where d.DeptID == deptId select c).ToList();
            var refinedApplicant = Mapper.Map<List<Award>, List<DistanceLearningDomain.Model.Award>>(rawApplicant);
            return refinedApplicant;
        }


        public bool ConfirmAwardByAcronyms(string acronyms)
        {
            var rawApplicant = (from c in Context.Awards where c.AwardAcronymns.ToLower()==acronyms.ToLower() select c).Any();
            return rawApplicant;
        }

        public bool ConfirmAwardByDescription(string description)
        {
            var rawApplicant = (from c in Context.Awards where c.AwardAcronymns.ToLower() == description.ToLower() select c).Any();
            return rawApplicant;
        }


        public DistanceLearningDomain.Model.Award GetAwardByMatricNo(string MatNo)
        {
      
           // var rawApplicant = ( from c in Context.Awards from d in c.Programmes from m in d.ProgrammeLevels from n in m.StudentCatLevels from k in n.StudentLevels  where k.Student.MatricNo.ToLower()==MatNo.ToLower() select c).FirstOrDefault();

            var rawApplicant = (from c in Context.Students from d in c.StudentLevels where c.MatricNo.ToLower() == MatNo.ToLower() select d.StudentCatLevel.ProgrammeLevel.Programme.Award).FirstOrDefault();
            var refinedApplicant = Mapper.Map<Award, DistanceLearningDomain.Model.Award>(rawApplicant);
            return refinedApplicant;
        
        }


        private string ProcessValue(int?val, string det)
        {
            int ans=(((int)val+1)-int.Parse(det));
            return ans.ToString();
        }
        public DistanceLearningDomain.Model.Award GetAwardByApplicant(string usr)
        {
            var rawApplicant = (from c in Context.Awards  from d in c.Programmes from m in d.ProgrammeLevels from n in m.AdmissionProgrammes from p in n.Applications where p.Applicant.LoginID==usr select c).FirstOrDefault();
            var refinedApplicant = Mapper.Map<Award, DistanceLearningDomain.Model.Award>(rawApplicant);
            return refinedApplicant;
        }


        public string GetAwardApplicantAwardDescription(string usr)
        {
            var rawApplicant = (from c in Context.Awards from d in c.Programmes from m in d.ProgrammeLevels from n in m.AdmissionProgrammes from p in n.Applications where p.Applicant.LoginID == usr select m.ProgLevDescription).FirstOrDefault();
            var programme = (from c in Context.Awards from d in c.Programmes from m in d.ProgrammeLevels from n in m.AdmissionProgrammes from p in n.Applications where p.Applicant.LoginID == usr select d.ProgrammeDescription).FirstOrDefault();
            var award = GetAwardByApplicant(usr);
            string det = string.Format("{0} {1}|{2}", award.AwardAcronymns, programme, ProcessValue(award.Duration, rawApplicant.Substring(0, 1)));
            return det;
        }
    }
}
