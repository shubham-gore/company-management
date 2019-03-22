
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayerLib
{
    public class DataManager
    {
        public Company GetCompany()
        {
            CDDataContext db = new CDDataContext();
            Company firstCompany = (from company in db.Companies
                                    select company).First();
            return firstCompany;
        }

        public IEnumerable<Project> GetAllProjects()
        {
            CDDataContext db = new CDDataContext();
            IEnumerable<Project> projectList = from project in db.Projects
                                               select project;



            return projectList;
        }

        public IEnumerable<TechnologyMaster> GetAllTechnologies()
        {
            CDDataContext db = new CDDataContext();
            IEnumerable<TechnologyMaster> technologyList = from technology in db.TechnologyMasters
                                                           select technology;

            return technologyList;



        }
        public int GetEmployeeCountForProject(int projectID)
        {
            int employeesForProject = 0;
            CDDataContext db = new CDDataContext();
            employeesForProject = (from employeeCountForProject in db.EmployeeProjects
                                   where employeeCountForProject.ProjectId == projectID
                                   select employeeCountForProject).Count();
            //totalEmployees = employeeProjectList.Count();

            return employeesForProject;
        }

        public IEnumerable<Employee> GetAllEmployeesForProject(int projectID)
        {
            CDDataContext db = new CDDataContext();

            IEnumerable<Employee> employeesListForProject = from employeeListForProject in db.EmployeeProjects
                                                            where employeeListForProject.ProjectId == projectID
                                                            select employeeListForProject.Employee;



            return employeesListForProject;

        }

        public IEnumerable<Project> GetAllDelayedProjects()
        {
            CDDataContext db = new CDDataContext();

            IEnumerable<Project> delayedProjectList = from delayProjectList in db.Projects
                                                      where delayProjectList.StatusId == (int)Status.Delayed
                                                      select delayProjectList;

            return delayedProjectList;
        }

        public IEnumerable<Project> GetAllProjectsForEmployee(int employeeID)
        {
            CDDataContext db = new CDDataContext();
            IEnumerable<Project> projectsListForEmployee = from projectListForEmployee in db.EmployeeProjects
                                                           where projectListForEmployee.EmployeeId == employeeID
                                                           select projectListForEmployee.Project;
            return projectsListForEmployee;

        }

        public IEnumerable<Task> GetAllTasksForEmployee(int employeeID)
        {
            CDDataContext db = new CDDataContext();
            IEnumerable<Task> taskListForEmployee = from tasksForEmployee in db.EmployeeTasks
                                                    where tasksForEmployee.EmployeeId == employeeID
                                                    select tasksForEmployee.Task;
            return taskListForEmployee;
        }

        public IEnumerable<Task> GetAllTechnologyTasksForEmployee(int technologyID, int employeeID)
        {
            CDDataContext db = new CDDataContext();
            /*IEnumerable<Task> taskListForEmployee = from tasksForEmployee in db.EmployeeTasks
                                                    where tasksForEmployee.EmployeeId == employeeID
                                                   
                                                    select tasksForEmployee.Task;

            IEnumerable<Task> taskListByTechnology = from tasksByTechnology in db.TaskTechnologies
                                                  where tasksByTechnology.TechnologyId == technologyID
                                                  select tasksByTechnology.Task;

            IEnumerable<Task> taskTechnologyListForEmployee = taskListForEmployee.Intersect(taskListByTechnology);*/

            IEnumerable<Task> taskTechnologyListForEmployee = from taskForEmployee in db.EmployeeTasks
                                                              where taskForEmployee.EmployeeId == employeeID
                                                              select taskForEmployee.Task;
            //List<Task> tasksTechnologyListForEmployee = taskTechnologyListForEmployee.ToList();

            List<Task> tasks = new List<Task>();
            //Task t = new Task();

            //tasks.AddRange(taskTechnologyListForEmployee.Where(t=>t.TaskTechnologies));

            foreach (Task tasktechnologyForEmployee in taskTechnologyListForEmployee)
            {
                foreach (TaskTechnology taskTechnology in db.TaskTechnologies)
                {
                    if ((taskTechnology.TechnologyId == technologyID) && (tasktechnologyForEmployee.TaskId == taskTechnology.TaskId))
                    {
                        tasks.Add(tasktechnologyForEmployee);
                    }
                }
            }
            return tasks;
            //return taskTechnologyListForEmployee;
        }

        public IEnumerable<Project> GetAllTechnologyProjects(int technologyID)
        {
            CDDataContext db = new CDDataContext();
            IEnumerable<Project> technologyListByProject = from technologyByProjects in db.ProjectTechnologies
                                                           where technologyByProjects.TechnologyId == technologyID
                                                           select technologyByProjects.Project;

            return technologyListByProject;
        }

        public IEnumerable<Task> GetAllActiveTasksForProject(int projectID)
        {
            CDDataContext db = new CDDataContext();
            IEnumerable<Task> activeTaskListForProject = from activeTaskByProjects in db.ProjectTasks
                                                         where activeTaskByProjects.StatusId == (int)Status.Active &&
                                                               activeTaskByProjects.ProjectId == projectID
                                                         select activeTaskByProjects.Task;

            return activeTaskListForProject;
        }

        public IEnumerable<TechnologyMaster> GetAllTechnologiesForEmployee(int employeeID)
        {
            CDDataContext db = new CDDataContext();
            IEnumerable<EmployeeTask> tasksListForEmployee = from employeeList in db.EmployeeTasks
                                                             where employeeList.EmployeeId == employeeID
                                                             select employeeList;




            List<TechnologyMaster> technologyForEmployee = new List<TechnologyMaster>();

            foreach (EmployeeTask taskForEmployee in tasksListForEmployee)
            {
                foreach (TaskTechnology technologyForTask in db.TaskTechnologies)
                {
                    if (technologyForTask.TaskId == taskForEmployee.TaskId)
                    {
                        technologyForEmployee.Add(technologyForTask.TechnologyMaster);
                    }
                }

            }
            return technologyForEmployee;
        }

        public int GetProjectCountForEmployee(int employeeID)
        {
            CDDataContext db = new CDDataContext();
            int projectCountForEmployee = 0;
            projectCountForEmployee = (from projectListForEmployee in db.EmployeeProjects
                                       where projectListForEmployee.EmployeeId == employeeID
                                       select projectListForEmployee).Count();

            return projectCountForEmployee;
        }

        public IEnumerable<Project> GetAllActiveProjectsManagedByEmployee(int employeeID)
        {
            CDDataContext db = new CDDataContext();
            IEnumerable<Project> activeProjectListManagedByEmployee = from projectByEmployee in db.EmployeeProjects
                                                                      where ((projectByEmployee.EmployeeId == employeeID) &&
                                                                            (projectByEmployee.RoleId == (int)Role.Manager) &&
                                                                            (projectByEmployee.Project.StatusId == (int)Status.Active))
                                                                      select projectByEmployee.Project;
            /*         List<Project> activeProjectListByEmployee = new List<Project>();
                        foreach(Project projectByEmployee in projectListManagedByEmployee)
                        {
                            foreach(Project projects in db.Projects)
                            {
                                if((projects.StatusId== (int)Status.Active)&&(projectByEmployee.ProjectId==projects.ProjectId))
                                {
                                    activeProjectListByEmployee.Add(projects);
                                }
                            }
                        }
                        return activeProjectListByEmployee;*/
            return activeProjectListManagedByEmployee;
        }

        public IEnumerable<Task> GetAllDelayedTasksForEmployee(int employeeID)
        {
            CDDataContext db = new CDDataContext();
            IEnumerable<Task> delayedTaskListForEmployee = from delayTaskForEmployee in db.EmployeeTasks
                                                           where delayTaskForEmployee.EmployeeId == employeeID &&
                                                           delayTaskForEmployee.StatusId == (int)Status.Delayed
                                                           select delayTaskForEmployee.Task;
            return delayedTaskListForEmployee;
        }



        public void AddProject(Project project)
        {
            CDDataContext db = new CDDataContext();
            string checkCompulsoryFields = ValidationHelper.CheckCompulsoryProjectColumns(project);
            if (checkCompulsoryFields != Resource.AllFieldsPresent)
            {
                throw new Exception(checkCompulsoryFields);
            }
            db.Projects.InsertOnSubmit(project);
            db.SubmitChanges();
        }

        public void AddTechnology(TechnologyMaster technologyMaster)
        {
            CDDataContext db = new CDDataContext();
            string checkCompulsoryFields = ValidationHelper.CheckCompulsoryTechnologyMasterColumns(technologyMaster);
            if (checkCompulsoryFields != Resource.AllFieldsPresent)
            {
                throw new Exception(checkCompulsoryFields);
            }
            db.TechnologyMasters.InsertOnSubmit(technologyMaster);
            db.SubmitChanges();
        }

        public void AddEmployee(Employee employee)
        {
            CDDataContext db = new CDDataContext();
            string checkCompulsoryFields = ValidationHelper.CheckCompulsoryEmployeeColumns(employee);
            if (checkCompulsoryFields != Resource.AllFieldsPresent)
            {
                throw new Exception(checkCompulsoryFields);
            }
            db.Employees.InsertOnSubmit(employee);
            db.SubmitChanges();
        }

        public void AssignEmployeeToProject(int employeeID, int projectID, int roleId, int maxProjectCountManagedByEmployee, int maxProjectCountByEmployee)
        {
            CDDataContext db = new CDDataContext();
            EmployeeProject employeeProjectObj = new EmployeeProject();
            employeeProjectObj.EmployeeId = employeeID;
            employeeProjectObj.ProjectId = projectID;
            employeeProjectObj.RoleId = roleId;
            string checkCompulsoryFields = ValidationHelper.CheckCompulsoryEmployeeProjectColumns(employeeProjectObj);
            if (checkCompulsoryFields != Resource.AllFieldsPresent)
            {
                throw new Exception(checkCompulsoryFields);
            }

            if (roleId == (int)Role.Manager)
            {
                int projectCountManagedByEmployee = (from employeeProject in db.EmployeeProjects
                                                     where ((employeeProject.EmployeeId == employeeID) &&
                                                     (employeeProject.RoleId == (int)Role.Manager))
                                                     select employeeProject).Count();
                if (projectCountManagedByEmployee < maxProjectCountManagedByEmployee)
                {
                    db.EmployeeProjects.InsertOnSubmit(employeeProjectObj);
                }
                else
                {
                    throw new Exception(Resource.MaxProjectsManagedByEmployee);
                }
            }
            else
            {
                int projectCountByEmployee = (from employeeProject in db.EmployeeProjects
                                              where ((employeeProject.EmployeeId == employeeID) &&
                                              (employeeProject.RoleId != (int)Role.Manager))
                                              select employeeProject).Count();
                if (projectCountByEmployee < maxProjectCountByEmployee)
                {
                    db.EmployeeProjects.InsertOnSubmit(employeeProjectObj);
                }
                else
                {
                    throw new Exception(Resource.MaxProjectsByEmployee);
                }
            }

            db.SubmitChanges();
        }

        public void CreateTaskInProject(Task task, int projectID, int statusId)
        {
            CDDataContext db = new CDDataContext();
            ProjectTask projectTaskObj = new ProjectTask();
            projectTaskObj.ProjectId = projectID;
            projectTaskObj.TaskId = task.TaskId;
            projectTaskObj.StatusId = statusId;
            string checkCompulsoryFields = ValidationHelper.CheckCompulsoryTaskProjectColumns(projectTaskObj);
            if (checkCompulsoryFields != Resource.AllFieldsPresent)
            {
                throw new Exception(checkCompulsoryFields);
            }

            Project projectObj = (from project in db.Projects
                                  where project.ProjectId == projectID
                                  select project).First();

            if (projectObj.StatusId == (int)Status.Completed)
            {
                throw new Exception(Resource.ProjectCompleted);
            }

            db.ProjectTasks.InsertOnSubmit(projectTaskObj);
            db.SubmitChanges();
        }

        public void AssignTechnologyToTask(int technologyID, int taskID, int maxTechnologyForTask)
        {
            CDDataContext db = new CDDataContext();
            TaskTechnology taskTechnologyObj = new TaskTechnology();
            taskTechnologyObj.TechnologyId = technologyID;
            taskTechnologyObj.TaskId = taskID;
            bool projectTechnologyFound = false;
            string checkCompulsoryFields = ValidationHelper.CheckCompulsoryTaskTechnologyColumns(taskTechnologyObj);
            if (checkCompulsoryFields != Resource.AllFieldsPresent)
            {
                throw new Exception(checkCompulsoryFields);
            }

            int technologyCountForTask = (from taskTechnology in db.TaskTechnologies
                                          where taskTechnology.TaskId == taskID
                                          select taskTechnology).Count();
            if (technologyCountForTask > maxTechnologyForTask)
            {
                throw new Exception(Resource.MaxTechnologyAssigned);
            }

            IEnumerable<ProjectTask> projectTaskList = from projectTask in db.ProjectTasks
                                                       where projectTask.TaskId == taskID
                                                       select projectTask;


            foreach (ProjectTask projectTask in projectTaskList)
            {
                foreach (ProjectTechnology projectTechnology in db.ProjectTechnologies)
                {
                    if ((projectTask.ProjectId == projectTechnology.ProjectId) && (projectTechnology.TechnologyId == technologyID))
                    {
                        projectTechnologyFound = true;
                    }
                }

            }


            if (projectTechnologyFound == true)
            {
                db.TaskTechnologies.InsertOnSubmit(taskTechnologyObj);
                db.SubmitChanges();
            }
            else
            {
                throw new Exception(Resource.TechnologyMissingInProject);
            }

        }

        public void UpdateTechnologiesForTask(List<int> technologyIDs, int taskID, int maxTechnologyForTask)
        {
            CDDataContext db = new CDDataContext();

            string checkTaskIdValidity = ValidationHelper.CheckTaskIdValidity(taskID);
            if (checkTaskIdValidity != Resource.TaskIdFound)
            {
                throw new Exception(checkTaskIdValidity);
            }
            IEnumerable<TaskTechnology> technologyListForTask = from technologyTask in db.TaskTechnologies
                                                                where technologyTask.TaskId == taskID
                                                                select technologyTask;
            if (technologyListForTask != null)
            {
                db.TaskTechnologies.DeleteAllOnSubmit(technologyListForTask);
                db.SubmitChanges();
            }
            foreach (int technologyId in technologyIDs)
            {
                AssignTechnologyToTask(technologyId, taskID, maxTechnologyForTask);
            }
        }
        public void DeleteEmployeeFromSystem(int employeeID)
        {
            CDDataContext db = new CDDataContext();
            string checkEmployeeIdValidity = ValidationHelper.CheckEmployeeIdValidity(employeeID);
            if (checkEmployeeIdValidity != Resource.EmployeeIdFound)
            {
                throw new Exception(checkEmployeeIdValidity);
            }

            IEnumerable<EmployeeTask> taskListForEmployee = from employeeTask in db.EmployeeTasks
                                                            where employeeTask.EmployeeId == employeeID
                                                            select employeeTask;
            if (taskListForEmployee != null)
            {
                db.EmployeeTasks.DeleteAllOnSubmit(taskListForEmployee);
            }

            IEnumerable<EmployeeProject> projectListForEmployee = from employeeProject in db.EmployeeProjects
                                                                  where employeeProject.EmployeeId == employeeID
                                                                  select employeeProject;
            if (projectListForEmployee != null)
            {
                db.EmployeeProjects.DeleteAllOnSubmit(projectListForEmployee);
            }

            Employee employeeObj = (from employee in db.Employees
                                    where employee.EmployeeId == employeeID
                                    select employee).First();
            db.Employees.DeleteOnSubmit(employeeObj);
            db.SubmitChanges();

        }

        public void DeleteTechnology(int technologyId, int maxProjectsForDeleteTechnology)
        {
            CDDataContext db = new CDDataContext();
            string checkTechnologyIdValidity = ValidationHelper.CheckTechnologyIdValidity(technologyId);
            if (checkTechnologyIdValidity != Resource.TechnologyIdFound)
            {
                throw new Exception(checkTechnologyIdValidity);
            }

            IEnumerable<ProjectTechnology> projectListForTechnology = from projectTechnology in db.ProjectTechnologies
                                                                      where projectTechnology.TechnologyId == technologyId
                                                                      select projectTechnology;
            int projectCountForTechnology = projectListForTechnology.Count();
            if (projectCountForTechnology > 2)
            {
                throw new Exception(Resource.ProjectCountExceeded);
            }

            if (projectListForTechnology != null)
            {
                db.ProjectTechnologies.DeleteAllOnSubmit(projectListForTechnology);
            }
            IEnumerable<TaskTechnology> taskListForTechnology = from taskTechnology in db.TaskTechnologies
                                                                where taskTechnology.TechnologyId == technologyId
                                                                select taskTechnology;
            if (taskListForTechnology != null)
            {
                db.TaskTechnologies.DeleteAllOnSubmit(taskListForTechnology);
            }
            TechnologyMaster technologyObj = (from technology in db.TechnologyMasters
                                              where technology.TechnologyId == technologyId
                                              select technology).First();
            db.TechnologyMasters.DeleteOnSubmit(technologyObj);
            db.SubmitChanges();

        }

        public void DeleteTask(int taskID)
        {
            CDDataContext db = new CDDataContext();
            string checkTaskIdValidity = ValidationHelper.CheckTaskIdValidity(taskID);
            if (checkTaskIdValidity != Resource.TaskIdFound)
            {
                throw new Exception(checkTaskIdValidity);
            }
            IEnumerable<EmployeeTask> employeeListForTask = from employeeTask in db.EmployeeTasks
                                                            where employeeTask.TaskId == taskID
                                                            select employeeTask;

            foreach (EmployeeTask employeeTaskObj in employeeListForTask)
            {
                if (employeeTaskObj.StatusId == (int)Status.Active)
                {
                    throw new Exception(Resource.TaskActive);
                }
            }

            if (employeeListForTask != null)
            {
                db.EmployeeTasks.DeleteAllOnSubmit(employeeListForTask);
            }
            IEnumerable<ProjectTask> projectListForTask = from projectTask in db.ProjectTasks
                                                          where projectTask.TaskId == taskID
                                                          select projectTask;

            foreach (ProjectTask projectTaskObj in projectListForTask)
            {
                if (projectTaskObj.StatusId == (int)Status.Active)
                {
                    throw new Exception(Resource.TaskActive);
                }
            }

            if (projectListForTask != null)
            {
                db.ProjectTasks.DeleteAllOnSubmit(projectListForTask);
            }
            IEnumerable<TaskTechnology> technologyListForTask = from taskTechnology in db.TaskTechnologies
                                                                where taskTechnology.TaskId == taskID
                                                                select taskTechnology;

            if (technologyListForTask != null)
            {
                db.TaskTechnologies.DeleteAllOnSubmit(technologyListForTask);
            }
            Task taskObj = (from task in db.Tasks
                            where task.TaskId == taskID
                            select task).First();
            db.Tasks.DeleteOnSubmit(taskObj);
            db.SubmitChanges();
        }

        public void DeleteProject(int projectID)
        {
            CDDataContext db = new CDDataContext();
            string checkProjectIdValidity = ValidationHelper.CheckProjectIdValidity(projectID);
            if (checkProjectIdValidity != Resource.ProjectIdFound)
            {
                throw new Exception(checkProjectIdValidity);
            }
            IEnumerable<ProjectTask> taskListForProject = from projectTask in db.ProjectTasks
                                                          where projectTask.ProjectId == projectID
                                                          select projectTask;

            foreach (ProjectTask projectTaskObj in taskListForProject)
            {
                if (projectTaskObj.StatusId == (int)Status.Active)
                {
                    throw new Exception(Resource.ProjectActive);
                }
            }

            if (taskListForProject != null)
            {
                db.ProjectTasks.DeleteAllOnSubmit(taskListForProject);
            }
            IEnumerable<ProjectTechnology> technologyListForProject = from projectTechnology in db.ProjectTechnologies
                                                                      where projectTechnology.ProjectId == projectID
                                                                      select projectTechnology;

            if (technologyListForProject != null)
            {
                db.ProjectTechnologies.DeleteAllOnSubmit(technologyListForProject);
            }
            IEnumerable<EmployeeProject> employeeListForProject = from employeeProject in db.EmployeeProjects
                                                                  where employeeProject.ProjectId == projectID
                                                                  select employeeProject;
            if (employeeListForProject != null)
            {
                db.EmployeeProjects.DeleteAllOnSubmit(employeeListForProject);
            }
            Client clientObj = (from client in db.Clients
                                where client.ProjectId == projectID
                                select client).FirstOrDefault();
            if (clientObj != null)
            {
                db.Clients.DeleteOnSubmit(clientObj);
            }
            Project projectObj = (from project in db.Projects
                                  where project.ProjectId == projectID
                                  select project).First();

            if (projectObj.StatusId == (int)Status.Active)
            {
                throw new Exception(Resource.ProjectActive);
            }

            db.Projects.DeleteOnSubmit(projectObj);
            db.SubmitChanges();
        }

    }
}
