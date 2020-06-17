using onlinelearningbackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace onlinelearningbackend.Repo.IManager
{
   public interface IProjectManager
    {
        ProjectModel GetProjectById(int ProjectId);
        IEnumerable<ProjectModel> GetAllProjects();
        IEnumerable<ProjectModel> GetProjectByTrackId(int TrackId);
        IEnumerable<ProjectModel> GetProjectByStudentId(string StudentId);
        ProjectModel AddProjectByTrackId(ProjectModel NewProject,int TrackId, string StudentId);
        ProjectModel EditProject(ProjectModel EDitedProject);
        void DeleteProject(int ProjectId);

    }
}
