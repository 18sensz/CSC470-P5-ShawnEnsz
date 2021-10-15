using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P3_Code
{
    public class FakeProjectRepository : IProjectRepository
    {
        public const string NO_ERROR = "";
        public const string MODIFIED_PROJECT_ID_ERROR = "Can not modify the project id.";
        public const string DUPLICATE_PROJECT_NAME_ERROR = "Project name already exists.";
        public const string NO_PROJECT_FOUND_ERROR = "No project found.";
        public const string EMPTY_PROJECT_NAME_ERROR = "Project name is empty or blank.";

        public static List<Project> projects;
        private int idIncrement = projects.Count();

        public string Add(Project project, out int id)
        {
            if (project.Name != string.Empty && !isDuplicateName(project.Name))
            {
                id = GetNextid();
                projects.Add(project);
                return NO_ERROR;
            }
            else if (isDuplicateName(project.Name))
            {
                id = -1;
                return DUPLICATE_PROJECT_NAME_ERROR;
            }
            else
            {
                id = -1;
                return EMPTY_PROJECT_NAME_ERROR;
            }
        }
        public string Remove(int projectId)
        {
            var index = projects.FindIndex(p => p.Id == projectId);
            if (index >= 0)
            {
                projects.RemoveAt(index);
                return NO_ERROR;
            }
            else
            {
                return NO_PROJECT_FOUND_ERROR;
            }
        }
        public string Modify(int projectId, Project project)
        {
            if (isDuplicateName(project.Name))
            {
                return DUPLICATE_PROJECT_NAME_ERROR;
            }
            var index = projects.FindIndex(p => p.Id == projectId);
            if (index >= 0)
            {
                projects[index] = project;
                return NO_ERROR;
            }
            else
            {
                return MODIFIED_PROJECT_ID_ERROR;
            }
        }
        public List<Project> GetAll()
        {
            List<Project> p = new List<Project>();
            foreach (Project project in projects)
            {
                p.Add(project);
            }
            return p;
        }
        public bool isDuplicateName(string projectName)
        {
            if (!projects.Any(r => r.Name == projectName))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        int GetNextid()
        {
            return ++idIncrement;
        }
    }
}

