using DistanceLearningCore.Model.StudentModel;
using DistanceLearningCore.Repository;
using DistanceLearningDomain.Repository;
using DistanceLearningDomain.UoW;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace DistanceLearningCore.UoW
{
  public  class BoundedContextUoW : IUoW
    {
        private readonly StudentElearningEntities _Context;
        public BoundedContextUoW()
        {
            _Context = new StudentElearningEntities();
            DesignationContext = new DesignationRepository(_Context);
            CourseContext = new CourseRepository(_Context);
            PersonContext = new PersonRepository(_Context);
            ApplicantContext = new ApplicantRepository(_Context);
            StudentContext = new StudentRepository( _Context);
            StudentLevelContext = new StudentLevelRepository(_Context);
            ProgrammeLevelContex = new ProgrammeLevelRepository(_Context);
            StudentLevelCatContext = new StudentCatLevelRepository(_Context);
            ProgrammeRequirementContext = new ProgrammeReqRepository(_Context);
            CurriculumContext = new CurriculumRepositoy(_Context);
            ApplicantProgressContext = new ApplicantProgessRepository(_Context);
            ApplicationContext = new ApplicationRepository(_Context);
            ExaminationContext = new StudentExaminationRepository(_Context);
            ExamSubjectContext = new ExamSubjectRepository(_Context);
            EmploymentContext = new StudentEmploymentRepository(_Context);
            SchoolAttendedContext = new StudentSchoolRepository(_Context);
            StudentRegContext = new StudentRegistrationRepository(_Context);
            AdmissionProcessingContext = new AdmissionProcessingRepository(_Context);

        }
        public IDesignation DesignationContext { get; private set; }
       
        public IPersonRepository PersonContext { get; private set; }
        public int Complete()
        {
            try
            {
                return _Context.SaveChanges();
            }
            catch
            {
                return -1;
            }
        }
        public void Dispose()
        {
            _Context.Dispose();
        }
        public IApplicantRepository ApplicantContext { get; private set; }
        public IStudentRepository StudentContext { get; private set; }
        public IStudentLevelRepository StudentLevelContext { get; private set;}
        public IStudCatLevelRepository StudentLevelCatContext  { get; private set;}
        public IProgrammeLevelRepositoy ProgrammeLevelContex { get; private set;}
        public ICourseRepository CourseContext { get; private set;}
        public IProgrammeRequirementRepository ProgrammeRequirementContext { get; private set;}
        public ICurriculumRepository CurriculumContext { get; private set;}
        public IApplicantProgress ApplicantProgressContext { get; private set; }
        public IApplicantion ApplicationContext { get; private set; }
        public IStudentExamination ExaminationContext { get; private set; }
        public IExaminationSubject ExamSubjectContext{ get; private set; }
        public IStudentEmployment EmploymentContext{ get; private set; }
        public IStudentSchool SchoolAttendedContext { get; private set; }
        public IStudentRegistrationRepository StudentRegContext { get; private set; }
        public IAdmissionProcessing AdmissionProcessingContext { get; private set; }
     
    }
}
