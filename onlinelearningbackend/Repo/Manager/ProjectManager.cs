using Microsoft.EntityFrameworkCore;
using onlinelearningbackend.Data;
using onlinelearningbackend.Models;
using onlinelearningbackend.Repo.IManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace onlinelearningbackend.Repo.Manager
{
    public class ProjectManager:IProjectManager
    {
        ApplicationDbContext DB;
        public ProjectManager(ApplicationDbContext _DB)
        {
            DB = _DB;
        }

        public IEnumerable<ProjectModel>  GetAllProjects()
        {
            var projects = DB.ProjectModels.FromSqlRaw("EXEC dbo.usp_ProjectModels_Select").ToList<ProjectModel>();
            return projects;
        }

        public ProjectModel GetProjectById(int ProjectId)
        {
            var projects= DB.ProjectModels.FromSqlRaw("EXEC dbo.usp_ProjectModel_Select_By_Id {0}", ProjectId).ToList<ProjectModel>().FirstOrDefault();
            return projects;
        }
        public IEnumerable<ProjectModel> GetProjectByTrackId(int TrackId)
        {
            var projects = DB.ProjectModels.FromSqlRaw("EXEC dbo.usp_ProjectModel_Select_By_Track_Id {0}", TrackId).ToList<ProjectModel>();
            return projects;
        }
        public IEnumerable<ProjectModel> GetProjectByStudentId(string StudentId)
        {
            var projects = DB.ProjectModels.FromSqlRaw($"EXEC [E-Learning].usp_ProjectModel_Select_By_Student_Id @StudentId='{StudentId}';").ToList<ProjectModel>();
            return projects;
        }
        public ProjectModel AddProjectByTrackId(ProjectModel NewProject,int TrackId,string StudentId)
        {
            var project = DB.ProjectModels.FromSqlRaw("EXEC dbo.usp_ProjectModel_Insert {0},{1},{2}", 
                                                        NewProject.ProjectName,
                                                        NewProject.ProjectDescription,
                                                        TrackId,
                                                        StudentId).ToList<ProjectModel>().FirstOrDefault();
            return project;
        }
        public ProjectModel EditProject(ProjectModel EditedProject)
        {
            var project = DB.ProjectModels.FromSqlRaw("EXEC dbo.usp_ProjectModel_Update {0},{1},{2}",
                                                        EditedProject.ProjectModelId,
                                                        EditedProject.ProjectName,
                                                        EditedProject.ProjectDescription).ToList<ProjectModel>().FirstOrDefault();
            return project;
        }
        public void DeleteProject(int ProjectId)
        {
            DB.ProjectModels.FromSqlRaw("EXEC dbo.usp_ProjectModel_Delete {0}",ProjectId);
            
        }

       
    }
}
