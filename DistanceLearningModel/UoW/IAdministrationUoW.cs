using DistanceLearningDomain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DistanceLearningDomain.UoW
{
    public interface IAdministrationUoW : IDisposable
    {
        ISchoolRepository SchoolContext { get; }
        IAwardRepository AwardContext { get; }
        IFacultyRepository FacultyContext { get; }
        IDepartmentRepository DepartmentContext { get; }
        
        ISessionRepository SessionContext { get; }
        IProgrammeRepository ProgrammeContext { get; }
        ISubjectRepository SubjectContext { get; }
        ILevelRepository LevelContext { get; }
        IStudentCategoryRepository StudentCategoryContext { get; }
        ISessionSemRepository SessionSemContext { get; }
        IAdmissionRepository AdmissionContext { get; }
        ISemesterRepository SemesterContext { get; }
        IAdmissionProgrammeRepository AdmissionProgrammeContext { get; }
        ISMTPProxyRepository SMTPProxyContext { get; }
        ICourseRoleRepository CourseRoleContext { get; }
       

        IStepRepository StepContext { get; }
        int Complete();
    }
}
