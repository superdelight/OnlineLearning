using DistanceLearningDomain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DistanceLearningDomain.UoW
{
   public interface IUoW:IDisposable
    {
        IDesignation DesignationContext { get; }
       // IDepartmentRepository DepartmentContext { get; }
        IPersonRepository PersonContext { get; }
        IStudentRepository StudentContext { get; }
        IApplicantProgress ApplicantProgressContext { get; }
        IApplicantRepository ApplicantContext { get; }
        IStudentLevelRepository StudentLevelContext { get; }
        IStudCatLevelRepository StudentLevelCatContext { get; }
        IProgrammeLevelRepositoy ProgrammeLevelContex { get; }
        ICourseRepository CourseContext { get; }
        IProgrammeRequirementRepository ProgrammeRequirementContext { get; }
        ICurriculumRepository CurriculumContext { get; }
        IApplicantion ApplicationContext { get; }
        IStudentExamination ExaminationContext { get; }
        IExaminationSubject ExamSubjectContext { get; }
        IStudentEmployment EmploymentContext { get; }
        IStudentSchool SchoolAttendedContext { get; }
        IStudentRegistrationRepository StudentRegContext { get; }
        IAdmissionProcessing AdmissionProcessingContext { get; }
        int Complete();
    }
}
