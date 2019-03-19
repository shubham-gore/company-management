using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayerLib;
using AutoMapper;
using CompanyManagementBL.Entities;

namespace CompanyManagementBL
{
    public class BusinessLayer
    {
        public BusinessLayer()
        {
            Automapper.AutomapperConfig();
        }

        public void GetCompany()
        {
            //Automapper.AutomapperConfig();
            Automapper mapper = new Automapper();
            DataManager dataManager = new DataManager();
            Company company = dataManager.GetCompany();

            BOCompany bOCompany = new BOCompany();
            bOCompany = mapper.MapCompanyToBOCompany(company);
        }

        public List<BOProject> GetAllProjects()
        {
            Automapper mapper = new Automapper();
            DataManager dataManager = new DataManager();
            IEnumerable<Project> projectList = dataManager.GetAllProjects();
            List<BOProject> bOProjectList = new List<BOProject>();
            bOProjectList = mapper.MapProjectListToBOProjectList(projectList);
            return bOProjectList;
        }

        public List<BOTechnology> GetAllTechnologies()
        {
            Automapper mapper = new Automapper();
            DataManager dataManager = new DataManager();
            IEnumerable<TechnologyMaster> technologyList = dataManager.GetAllTechnologies();
            List<BOTechnology> bOProjectList = new List<BOTechnology>();
            bOProjectList = mapper.MapTechnologyListToBOTechnologyList(technologyList);
            return bOProjectList;

        }

        public int GetEmployeeCountForProject(int projectID)
        {
            DataManager dataManager = new DataManager();
            int employeeCountForProject = dataManager.GetEmployeeCountForProject(projectID);
            return employeeCountForProject;

        }

        public List<BOEmployee> GetAllEmployeesForProject(int projectID)
        {
            DataManager dataManager = new DataManager();
            IEnumerable<Employee> employeeList = dataManager.GetAllEmployeesForProject(projectID);
            Automapper mapper = new Automapper();
            List<BOEmployee> bOEmployeeList = new List<BOEmployee>();
            bOEmployeeList = mapper.MapEmployeeListToBOEmployeeList(employeeList);
            return bOEmployeeList;
        }

        public List<BOProject> GetAllDelayedProjects()
        {
            Automapper mapper = new Automapper();
            DataManager dataManager = new DataManager();
            IEnumerable<Project> delayedProjectList = dataManager.GetAllDelayedProjects();
            List<BOProject> bODelayedProjectList = mapper.MapProjectListToBOProjectList(delayedProjectList);
            return bODelayedProjectList;
        }

        public List<BOProject> GetAllProjectsForEmployee(int employeeID)
        {
            Automapper mapper = new Automapper();
            DataManager dataManager = new DataManager();
            IEnumerable<Project> projectListForEmployee = dataManager.GetAllProjectsForEmployee(employeeID);
            List<BOProject> bOProjectListForEmployee = mapper.MapProjectListToBOProjectList(projectListForEmployee);
            return bOProjectListForEmployee;

        }

        public List<BOTask> GetAllTasksForEmployee(int employeeID)
        {
            Automapper mapper = new Automapper();
            DataManager dataManager = new DataManager();
            IEnumerable<DataLayerLib.Task> taskListForEmployee = dataManager.GetAllTasksForEmployee(employeeID);
            List<BOTask> bOTaskListForEmployee = mapper.MapTaskListToBOTaskList(taskListForEmployee);
            return bOTaskListForEmployee;
        }

        public List<BOTask> GetAllTechnologyTasksForEmployee(int technologyID, int employeeID)
        {
            Automapper mapper = new Automapper();
            DataManager dataManager = new DataManager();
            IEnumerable<DataLayerLib.Task> taskTechnologyListForEmployee = dataManager.GetAllTechnologyTasksForEmployee(technologyID, employeeID);
            List<BOTask> bOTaskTechnologyListForEmployee = mapper.MapTaskListToBOTaskList(taskTechnologyListForEmployee);
            return bOTaskTechnologyListForEmployee;
        }

        public List<BOProject> GetAllTechnologyProjects(int technologyID)
        {
            Automapper mapper = new Automapper();
            DataManager dataManager = new DataManager();
            IEnumerable<Project> projectListForTechnologies = dataManager.GetAllTechnologyProjects(technologyID);
            List<BOProject> bOProjectListForTechnologies = mapper.MapProjectListToBOProjectList(projectListForTechnologies);
            return bOProjectListForTechnologies;
        }
        public List<BOTask> GetAllActiveTasksForProject(int projectID)
        {
            Automapper mapper = new Automapper();
            DataManager dataManager = new DataManager();
            IEnumerable<DataLayerLib.Task> activeTaskListForProject = dataManager.GetAllActiveTasksForProject(projectID);
            List<BOTask> bOActiveTaskListForProject = mapper.MapTaskListToBOTaskList(activeTaskListForProject);
            return bOActiveTaskListForProject;
        }

        public List<BOTechnology> GetAllTechnologiesForEmployee(int employeeID)
        {
            Automapper mapper = new Automapper();
            DataManager dataManager = new DataManager();
            IEnumerable<TechnologyMaster> technologyListForEmployee = dataManager.GetAllTechnologiesForEmployee(employeeID);
            List<BOTechnology> bOTechnologyListForEmployee = mapper.MapTechnologyListToBOTechnologyList(technologyListForEmployee);
            return bOTechnologyListForEmployee;
        }

        public int GetProjectCountForEmployee(int employeeID)
        {
            DataManager dataManager = new DataManager();
            int projectCountForEmployee = dataManager.GetProjectCountForEmployee(employeeID);
            return projectCountForEmployee;
        }

        public List<BOProject> GetAllActiveProjectsManagedByEmployee(int employeeID)
        {
            Automapper mapper = new Automapper();
            DataManager dataManager = new DataManager();
            IEnumerable<Project> activeProjectListManagedByEmployee = dataManager.GetAllActiveProjectsManagedByEmployee(employeeID);
            List<BOProject> bOActiveProjectListManagedByEmployee = mapper.MapProjectListToBOProjectList(activeProjectListManagedByEmployee);
            return bOActiveProjectListManagedByEmployee;
        }

        public List<BOTask> GetAllDelayedTasksForEmployee(int employeeID)
        {
            Automapper mapper = new Automapper();
            DataManager dataManager = new DataManager();
            IEnumerable<DataLayerLib.Task> delayedTaskListForEmployee = dataManager.GetAllDelayedTasksForEmployee(employeeID);
            List<BOTask> bODelayedTaskListForEmployee = mapper.MapTaskListToBOTaskList(delayedTaskListForEmployee);
            return bODelayedTaskListForEmployee;
        }

        public void AddProject(BOProject bOProject)
        {
            Automapper mapper = new Automapper();
            DataManager dataManager = new DataManager();
            Project project = mapper.MapBOProjectToProject(bOProject);
            dataManager.AddProject(project);

        }

        public void AddTechnology(BOTechnology bOTechnology)
        {
            Automapper mapper = new Automapper();
            DataManager dataManager = new DataManager();
            TechnologyMaster technology = mapper.MapBOTechnologytoTechnologyMaster(bOTechnology);
            dataManager.AddTechnology(technology);
        }

        public void AddEmployee(BOEmployee bOEmployee)
        {
            Automapper mapper = new Automapper();
            DataManager dataManager = new DataManager();
            Employee employee = mapper.MapBOEmployeeToEmployee(bOEmployee);
            dataManager.AddEmployee(employee);
        }

        public void AssignEmployeeToProject(int employeeID, int projectID, int roleId)
        {
            DataManager dataManager = new DataManager();
            dataManager.AssignEmployeeToProject(employeeID,projectID,roleId);
        }

        public void CreateTaskInProject(BOTask bOTask, int projectID, int statusId)
        {
            Automapper mapper = new Automapper();
            DataManager dataManager = new DataManager();
            DataLayerLib.Task task = mapper.MapBOTaskToTask(bOTask);
            dataManager.CreateTaskInProject(task,projectID,statusId);
        }

        public void AssignTechnologyToTask(int technologyID, int taskID)
        {
            DataManager dataManager = new DataManager();
            dataManager.AssignTechnologyToTask(technologyID,taskID);
        }

        public void UpdateTechnologiesForTask(List<int> technologyIDs, int taskID)
        {
            DataManager dataManager = new DataManager();
            dataManager.UpdateTechnologiesForTask(technologyIDs,taskID);
        }

        public void DeleteEmployeeFromSystem(int employeeID)
        {
            DataManager dataManager = new DataManager();
            dataManager.DeleteEmployeeFromSystem(employeeID);
        }

        public void DeleteTechnology(int technologyId)
        {
            //int maxProjectsForDeleteTechnology = 2;
            DataManager dataManager = new DataManager();
            dataManager.DeleteTechnology(technologyId);
        }

        public void DeleteTask(int taskID)
        {
            DataManager dataManager = new DataManager();
            dataManager.DeleteTask(taskID);
        }
        public void DeleteProject(int projectID)
        {
            DataManager dataManager = new DataManager();
            dataManager.DeleteProject(projectID);
        }


    }
}
