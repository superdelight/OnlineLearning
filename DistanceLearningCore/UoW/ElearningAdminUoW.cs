using DistanceLearningCore.Model.Administration;
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
    public class ElearningAdminUoW : IAdministrationUoW
    {
        private readonly ElearningAdminEntities _Context;
        public ElearningAdminUoW()
        {
            _Context = new ElearningAdminEntities();
            SchoolContext = new SchoolRepository(_Context);
            AwardContext = new AwardRepository(_Context);
            FacultyContext = new FacultyRepository(_Context);
            
            DepartmentContext = new DepartmentRepository(_Context);
            ProgrammeContext = new ProgrammeRepository(_Context);
            SubjectContext = new SubjectRepository(_Context);
            SessionContext = new SessionRepository(_Context);
            LevelContext = new LevelRepository(_Context);
            StudentCategoryContext = new StudentCategoryRepository(_Context);
            CourseRoleContext = new CourseRoleRepository(_Context);
            StepContext = new StepRepository(_Context);
            AdmissionContext = new AdmissionRepository(_Context);
            SessionSemContext = new SessionSemRepository(_Context);
            SMTPProxyContext = new SMTPProxyRepository(_Context);
            AdmissionProgrammeContext = new AdmissionProgrammeRepository(_Context);
            SemesterContext = new SemesterRepository(_Context);
           
            


        }
        public int Complete()
        {
            return _Context.SaveChanges();
        }
        public void Dispose()
        {
            _Context.Dispose();
        }

        public ISchoolRepository SchoolContext { get; private set; }
        public IAwardRepository AwardContext { get; private set; }
        public IFacultyRepository FacultyContext { get; private set; }
        public IDepartmentRepository DepartmentContext { get; private set; }
        public IProgrammeRepository ProgrammeContext { get; private set; }
        public ISubjectRepository SubjectContext { get; private set; }
        public ISessionRepository SessionContext { get; private set; }
        public ILevelRepository LevelContext { get; private set; }
        public IStudentCategoryRepository StudentCategoryContext { get; private set; }
        public ICourseRoleRepository CourseRoleContext { get; private set; }
        public IStepRepository StepContext { get; private set; }
        public ISessionSemRepository SessionSemContext { get; private set; }
        public IAdmissionRepository AdmissionContext { get; private set; }
        public IAdmissionProgrammeRepository AdmissionProgrammeContext { get; private set; }
        public ISMTPProxyRepository SMTPProxyContext { get; private set; }
        public ISemesterRepository SemesterContext { get; private set; }
        
     
    }
}