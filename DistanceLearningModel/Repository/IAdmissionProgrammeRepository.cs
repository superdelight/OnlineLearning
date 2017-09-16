using DistanceLearningDomain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DistanceLearningDomain.Repository
{
    public interface IAdmissionProgrammeRepository : IRepository<AdmissionProgramme>
    {
        bool ConfirmAdmissionProgramme(int progId, int SessId);
        AdmissionProgramme GetProgramme(int progId, int SessId);
        IEnumerable<AdmissionProgramme> GetAllAdmissioProgrammenByAdmission(int admissionId);
        IEnumerable<AdmissionProgramme> GetAllAdmissioProgrammenByAward(int admissionId,int AwardId);
        IEnumerable<AdmissionProgramme> GetAllAdmissioProgrammenByAdmission(int admissionId,int deptId);
        IEnumerable<AdmissionProgramme> GetAllAdmissioProgrammenInSession(int sessId);
        IEnumerable<AdmissionProgramme> GetAllAdmissioProgrammenByProgramme(int ProgId);
        IEnumerable<AdmissionProgramme> GetAllAdmissioProgrammenByProgrammeLevId(int ProgId);
        IEnumerable<AdmissionProgramme> GetAllAdmissioProgrammenByDept(int deptId);
        IEnumerable<AdmissionProgramme> GetAllAdmissioProgrammenByFaculty(int facId);
        IEnumerable<AdmissionProgramme> GetAllAdmissioProgrammenByFaculty(int facId,int sessId);
        IEnumerable<AdmissionProgramme> GetAllAdmissioProgrammenByDept(int deptId,int sessId);
      
    }
}

