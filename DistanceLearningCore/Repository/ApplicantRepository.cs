using AutoMapper;
using DistanceLearningCore.Model.StudentModel;
using DistanceLearningDomain.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace DistanceLearningCore.Repository
{
    public class ApplicantRepository : Repository<DistanceLearningDomain.Model.Applicant,Applicant>, IApplicantRepository
    {
        private StudentElearningEntities Context;
        public ApplicantRepository(StudentElearningEntities Context)
            : base(Context)
        {
            Mapper.CreateMap<DistanceLearningDomain.Model.Applicant, Applicant>();
            Mapper.CreateMap<Applicant, DistanceLearningDomain.Model.Applicant>();
            this.Context = Context;
           
        }
        public IEnumerable<DistanceLearningDomain.Model.Applicant> GetAllApplicant()
        {
            var rawApplicant = Context.People.OfType<Applicant>().ToList();
            var refinedApplicant = Mapper.Map<List<Applicant>, List<DistanceLearningDomain.Model.Applicant>>(rawApplicant);
            return refinedApplicant;
        }
        public DistanceLearningDomain.Model.Applicant GetApplicantByNumber(string FormNo)
        {
            var rawApplicant = Context.People.OfType<Applicant>().Where(c=>c.ApplicationNo.Trim().ToLower().Equals(FormNo.Trim().ToLower())).FirstOrDefault();
            var refinedApplicant = Mapper.Map<Applicant,DistanceLearningDomain.Model.Applicant>(rawApplicant);
            return refinedApplicant;
        }
        public DistanceLearningDomain.Model.Applicant GetLastApplicant(int AdmissionId)
        {
            var rawApplicant = Context.People.OfType<Applicant>().Where(d=>d.AdmissionId==AdmissionId).OrderByDescending(c=>c.Id).FirstOrDefault();
            var refinedApplicant = Mapper.Map<Applicant, DistanceLearningDomain.Model.Applicant>(rawApplicant);
            return refinedApplicant;
        }
        public DistanceLearningDomain.Model.Applicant GetFirstApplicant(int AdmissionId)
        {
            var rawApplicant = Context.People.OfType<Applicant>().Where(d => d.AdmissionId == AdmissionId).OrderBy(c => c.Id).FirstOrDefault();
            var refinedApplicant = Mapper.Map<Applicant, DistanceLearningDomain.Model.Applicant>(rawApplicant);
            return refinedApplicant;
        }
        public IEnumerable<DistanceLearningDomain.Model.Applicant> GetAdmittedApplicant(int AdmissionId)
        {
            var rawApplicant =(from p in Context.AdmissionProcessings where p.IsActivated==true && p.Application.AdmissionProgramme.AdminId==AdmissionId select p.Application.Applicant).ToList();
            var refinedApplicant = Mapper.Map<List<Applicant>, List<DistanceLearningDomain.Model.Applicant>>(rawApplicant);
            return refinedApplicant;
        }
        public IEnumerable<DistanceLearningDomain.Model.Applicant> GetNonAdmittedApplicant(int AdmissionId)
        {
            var rawApplicant = (from p in Context.AdmissionProcessings where p.IsActivated == false && p.Application.AdmissionProgramme.AdminId == AdmissionId select p.Application.Applicant).ToList();
            var refinedApplicant = Mapper.Map<List<Applicant>, List<DistanceLearningDomain.Model.Applicant>>(rawApplicant);
            return refinedApplicant;
        }
        public IEnumerable<DistanceLearningDomain.Model.Applicant> GetNonAdmittedVerifiedApplicant(int AdmissionId)
        {
            var rawApplicant = (from p in Context.AdmissionProcessings where p.IsActivated == false && p.IsVerified==true && p.Application.AdmissionProgramme.AdminId == AdmissionId select p.Application.Applicant).ToList();
            var refinedApplicant = Mapper.Map<List<Applicant>, List<DistanceLearningDomain.Model.Applicant>>(rawApplicant);
            return refinedApplicant;
        }
        public IEnumerable<DistanceLearningDomain.Model.Applicant> GetUnVerifiedApplicant(int AdmissionId)
        {
            var rawApplicant = (from p in Context.AdmissionProcessings where p.IsVerified == false && p.Application.AdmissionProgramme.AdminId == AdmissionId select p.Application.Applicant).ToList();
            var refinedApplicant = Mapper.Map<List<Applicant>, List<DistanceLearningDomain.Model.Applicant>>(rawApplicant);
            return refinedApplicant;
        }
        public IEnumerable<DistanceLearningDomain.Model.Applicant> GetFinishedApplicant(int AdmissionId)
        {
            var rawApplicant = Context.People.OfType<Applicant>().Where(c => c.IsFinished==true && c.AdmissionId==AdmissionId).ToList();
            var refinedApplicant = Mapper.Map<List<Applicant>, List<DistanceLearningDomain.Model.Applicant>>(rawApplicant);
            return refinedApplicant;
        }
        public IEnumerable<DistanceLearningDomain.Model.Applicant> GetUnFinishedApplicant(int AdmissionId)
        {
            var rawApplicant = Context.People.OfType<Applicant>().Where(c => c.IsFinished == false && c.ApplicationNo!=string.Empty && c.AdmissionId == AdmissionId).ToList();
            var refinedApplicant = Mapper.Map<List<Applicant>, List<DistanceLearningDomain.Model.Applicant>>(rawApplicant);
            return refinedApplicant;
        }
        public IEnumerable<DistanceLearningDomain.Model.Applicant> GetNotifiedApplicant(int AdmissionId)
        {
            var rawApplicant = (from p in Context.AdmissionProcessings where p.IsNotified == true && p.Application.AdmissionProgramme.AdminId == AdmissionId select p.Application.Applicant).ToList();
            var refinedApplicant = Mapper.Map<List<Applicant>, List<DistanceLearningDomain.Model.Applicant>>(rawApplicant);
            return refinedApplicant;
        }
        public IEnumerable<DistanceLearningDomain.Model.Applicant> GetUnNotifiedApplicant(int AdmissionId)
        {
            var rawApplicant = (from p in Context.AdmissionProcessings where p.IsNotified == false && p.IsActivated==true && p.Application.AdmissionProgramme.AdminId == AdmissionId select p.Application.Applicant).ToList();
            var refinedApplicant = Mapper.Map<List<Applicant>, List<DistanceLearningDomain.Model.Applicant>>(rawApplicant);
            return refinedApplicant;
        }
        public IEnumerable<DistanceLearningDomain.Model.Applicant> GetAllApplicant(int AdmissionId)
        {
            var rawApplicant = Context.People.OfType<Applicant>().Where(c => c.AdmissionId == AdmissionId).ToList();
            var refinedApplicant = Mapper.Map<List<Applicant>, List<DistanceLearningDomain.Model.Applicant>>(rawApplicant);
            return refinedApplicant;
        }
        public IEnumerable<DistanceLearningDomain.Model.Applicant> GetNonAdmittedApplicantByProgramme(int AdmProgId)
        {
            var rawApplicant = (from p in Context.AdmissionProcessings where p.IsActivated == false && p.IsVerified == true && p.Application.AdmProgID == AdmProgId select p.Application.Applicant).ToList();
            var refinedApplicant = Mapper.Map<List<Applicant>, List<DistanceLearningDomain.Model.Applicant>>(rawApplicant);
            return refinedApplicant;
        }

        public IEnumerable<DistanceLearningDomain.Model.Applicant> GetAdmittedApplicantByProgramme(int AdmProgId)
        {
            var rawApplicant = (from p in Context.AdmissionProcessings where p.IsActivated == true && p.IsVerified == true && p.Application.AdmProgID == AdmProgId select p.Application.Applicant).ToList();
            var refinedApplicant = Mapper.Map<List<Applicant>, List<DistanceLearningDomain.Model.Applicant>>(rawApplicant);
            return refinedApplicant;
        }

        public IEnumerable<DistanceLearningDomain.Model.Applicant> GetUnVerifiedApplicantByProgramme(int AdmProgId)
        {
            var rawApplicant = (from p in Context.AdmissionProcessings where  p.IsVerified == false && p.Application.AdmProgID == AdmProgId select p.Application.Applicant).ToList();
            var refinedApplicant = Mapper.Map<List<Applicant>, List<DistanceLearningDomain.Model.Applicant>>(rawApplicant);
            return refinedApplicant;
        }

        public IEnumerable<DistanceLearningDomain.Model.Applicant> GetFinishedApplicantByProgramme(int AdmProgId)
        {
            var rawApplicant = (from p in Context.Applications where p.AdmProgID == AdmProgId && p.Applicant.IsFinished == true select p.Applicant).ToList();
            var refinedApplicant = Mapper.Map<List<Applicant>, List<DistanceLearningDomain.Model.Applicant>>(rawApplicant);
            return refinedApplicant;
        }

        public IEnumerable<DistanceLearningDomain.Model.Applicant> GetUnFinishedApplicantByProgramme(int AdmProgId)
        {
            var rawApplicant = (from p in Context.Applications where p.AdmProgID == AdmProgId && p.Applicant.IsFinished == false && p.Applicant.ApplicationNo!=string.Empty select p.Applicant).ToList();
            var refinedApplicant = Mapper.Map<List<Applicant>, List<DistanceLearningDomain.Model.Applicant>>(rawApplicant);
            return refinedApplicant;
        }

        public IEnumerable<DistanceLearningDomain.Model.Applicant> GetUnNotifiedApplicantByProgramme(int AdmProgId)
        {
            var rawApplicant = (from p in Context.AdmissionProcessings where p.IsActivated == true && p.IsNotified == false && p.Application.AdmProgID == AdmProgId select p.Application.Applicant).ToList();
            var refinedApplicant = Mapper.Map<List<Applicant>, List<DistanceLearningDomain.Model.Applicant>>(rawApplicant);
            return refinedApplicant;
        }
        public IEnumerable<DistanceLearningDomain.Model.Applicant> GetNotifiedApplicantByProgramme(int AdmProgId)
        {
            var rawApplicant = (from p in Context.AdmissionProcessings where p.IsNotified == true && p.Application.AdmProgID == AdmProgId select p.Application.Applicant).ToList();
            var refinedApplicant = Mapper.Map<List<Applicant>, List<DistanceLearningDomain.Model.Applicant>>(rawApplicant);
            return refinedApplicant;
        }
        public DistanceLearningDomain.Model.Applicant GetFirstApplicantByAdmissionProgramme(int AdmissionId)
        {
            var rawApplicant = (from p in Context.Applications where p.AdmProgID == AdmissionId select p.Applicant).OrderBy(f=>f.Id).FirstOrDefault();
            var refinedApplicant = Mapper.Map<Applicant, DistanceLearningDomain.Model.Applicant>(rawApplicant);
            return refinedApplicant;
        }
        public DistanceLearningDomain.Model.Applicant GetLastApplicantByAdmissionProgramme(int AdmissionId)
        {
            var rawApplicant = (from p in Context.Applications where p.AdmProgID == AdmissionId select p.Applicant).OrderByDescending(f => f.Id).FirstOrDefault();
            var refinedApplicant = Mapper.Map<Applicant, DistanceLearningDomain.Model.Applicant>(rawApplicant);
            return refinedApplicant;
        }
        public IEnumerable<DistanceLearningDomain.Model.Applicant> GetAllAcceptedApplicants(int AdmissionId)
        {
            var rawApplicant = (from p in Context.AdmissionProcessings where p.IsAccepted == true  && p.Application.AdmissionProgramme.AdminId == AdmissionId select p.Application.Applicant).ToList();
            var refinedApplicant = Mapper.Map<List<Applicant>, List<DistanceLearningDomain.Model.Applicant>>(rawApplicant);
            return refinedApplicant;
        }
        public IEnumerable<DistanceLearningDomain.Model.Applicant> GetAllUnAcceptedApplicants(int AdmissionId)
        {
            var rawApplicant = (from p in Context.AdmissionProcessings where p.IsAccepted == false && p.IsActivated==true && p.Application.AdmissionProgramme.AdminId == AdmissionId select p.Application.Applicant).ToList();
            var refinedApplicant = Mapper.Map<List<Applicant>, List<DistanceLearningDomain.Model.Applicant>>(rawApplicant);
            return refinedApplicant;
        }
        public IEnumerable<DistanceLearningDomain.Model.Applicant> GetAllAcceptedApplicantsByProgramme(int AdmissionId)
        {
            var rawApplicant = (from p in Context.AdmissionProcessings where p.IsAccepted == true && p.Application.AdmProgID == AdmissionId select p.Application.Applicant).ToList();
            var refinedApplicant = Mapper.Map<List<Applicant>, List<DistanceLearningDomain.Model.Applicant>>(rawApplicant);
            return refinedApplicant;
        }
        public IEnumerable<DistanceLearningDomain.Model.Applicant> GetAllUnAcceptedApplicantsByProgramme(int AdmissionId)
        {
            var rawApplicant = (from p in Context.AdmissionProcessings where p.IsAccepted == false && p.IsActivated == true && p.Application.AdmProgID == AdmissionId select p.Application.Applicant).ToList();
            var refinedApplicant = Mapper.Map<List<Applicant>, List<DistanceLearningDomain.Model.Applicant>>(rawApplicant);
            return refinedApplicant;
        }
        public IEnumerable<DistanceLearningDomain.Model.Applicant> GetApplicantsInStep(int AdmProgId, int StepId)
        {
            var rawApplicant = (from p in Context.People.OfType<Applicant>() where p.ApplicantProgresses.OrderByDescending(c=>c.StepId).FirstOrDefault().StepId==StepId && p.AdmissionId == AdmProgId select p).ToList();
            var refinedApplicant = Mapper.Map<List<Applicant>, List<DistanceLearningDomain.Model.Applicant>>(rawApplicant);
            return refinedApplicant;
        }
        public DistanceLearningDomain.Model.Applicant GetApplicantByLogin(string FormNo)
        {
            var rawApplicant = Context.People.OfType<Applicant>().Where(c => c.LoginID.Trim().ToLower().Equals(FormNo.Trim().ToLower())).FirstOrDefault();
            var refinedApplicant = Mapper.Map<Applicant, DistanceLearningDomain.Model.Applicant>(rawApplicant);
            return refinedApplicant;
        }

        public DistanceLearningDomain.Model.Applicant GetApplicantByMatricNo(string matno)
        {
            var rawApplicant = Context.People.OfType<Applicant>().Where(c => c.HealthStatus.Trim().ToLower().Equals(matno.Trim().ToLower())).FirstOrDefault();
            var refinedApplicant = Mapper.Map<Applicant, DistanceLearningDomain.Model.Applicant>(rawApplicant);
            return refinedApplicant;
        }
    }
}
