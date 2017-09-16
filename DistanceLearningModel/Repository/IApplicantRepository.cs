using DistanceLearningDomain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DistanceLearningDomain.Repository
{
    public interface IApplicantRepository : IRepository<Applicant>
    {
       IEnumerable<Applicant> GetAllApplicant();
       Applicant GetApplicantByMatricNo(string matno);
       Applicant GetApplicantByNumber(string FormNo);
       Applicant GetApplicantByLogin(string FormNo);
       Applicant GetLastApplicant(int AdmissionId);
       Applicant GetFirstApplicantByAdmissionProgramme(int AdmissionId);
       Applicant GetLastApplicantByAdmissionProgramme(int AdmissionId);
       Applicant GetFirstApplicant(int AdmissionId);
       IEnumerable<Applicant> GetAdmittedApplicant(int AdmissionId);
       IEnumerable<Applicant> GetNonAdmittedApplicant(int AdmissionId);
       IEnumerable<Applicant> GetNonAdmittedVerifiedApplicant(int AdmissionId);
       IEnumerable<Applicant> GetUnVerifiedApplicant(int AdmissionId);
       IEnumerable<Applicant> GetFinishedApplicant(int AdmissionId);
       IEnumerable<Applicant> GetUnFinishedApplicant(int AdmissionId);
       IEnumerable<Applicant> GetNotifiedApplicant(int AdmissionId);
       IEnumerable<Applicant> GetUnNotifiedApplicant(int AdmissionId);
       IEnumerable<Applicant> GetAllAcceptedApplicants(int AdmissionId);
       IEnumerable<Applicant> GetAllUnAcceptedApplicants(int AdmissionId);
       IEnumerable<Applicant> GetAllAcceptedApplicantsByProgramme(int AdmissionId);
       IEnumerable<Applicant> GetAllUnAcceptedApplicantsByProgramme(int AdmissionId);
       IEnumerable<Applicant> GetAllApplicant(int AdmissionId);
       IEnumerable<Applicant> GetNonAdmittedApplicantByProgramme(int AdmProgId);
       IEnumerable<Applicant> GetAdmittedApplicantByProgramme(int AdmProgId);
       IEnumerable<Applicant> GetUnVerifiedApplicantByProgramme(int AdmProgId);
       IEnumerable<Applicant> GetFinishedApplicantByProgramme(int AdmProgId);
       IEnumerable<Applicant> GetUnFinishedApplicantByProgramme(int AdmProgId);
       IEnumerable<Applicant> GetUnNotifiedApplicantByProgramme(int AdmProgId);
       IEnumerable<Applicant> GetNotifiedApplicantByProgramme(int AdmProgId);
       IEnumerable<Applicant> GetApplicantsInStep(int AdmProgId,int StepId);

      


    }
}

