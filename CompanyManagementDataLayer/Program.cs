//using DataLayerLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompanyManagementBL;

namespace CompanyManagementDataLayer
{
    class Program
    {
       
        static void Main(string[] args)
        {
            
            //Program p1 = new Program();
            DataManager dataManager = new DataManager();
            string status = null;
            /*//All Projects
            IEnumerable<Project> projectList = dataManager.GetAllProjects();
            Console.WriteLine("All Projects-");
            

            foreach (Project project in projectList)
            {
                status = Enum.GetName(typeof(Status), project.StatusId);
                Console.Write("Project ID: {0}, Project Name: {1}, Status: {2}, Department ID: {3}\n", project.ProjectId, project.ProjectName, status, project.DepartmentId);
            }

            //All Technologies
            Console.WriteLine("\nAll Technologies-");
            IEnumerable<TechnologyMaster> technologyList = dataManager.GetAllTechnologies();
            foreach (TechnologyMaster technology in technologyList)
            {
                Console.Write("Technology ID: {0}, Technology Name: {1}\n", technology.TechnologyId, technology.TechnologyName);
            }
            Console.ReadLine();
            */

            /*
            //Employee count for project
            Console.WriteLine("Enter Project ID to check no of Employees:");
            int projectId=int.Parse(Console.ReadLine());
            int employeesCountForProject = dataManager.GetEmployeeCountForProject(projectId);
            Console.WriteLine("Number on Employees in Project Id {0} is {1}",projectId,employeesCountForProject);
            

            //Employee Details for project
            Console.WriteLine("Enter Project ID to check details of Employees:");
            projectId = int.Parse(Console.ReadLine());
            IEnumerable<Employee> employeeListForProject = dataManager.GetAllEmployeesForProject(projectId);
            if(employeeListForProject.ElementAtOrDefault(0)!=null)
            {
                Console.WriteLine("Employee Details For Project ID {0}:", projectId);

                foreach (Employee EmployeeDetails in employeeListForProject)
                {
                    Console.WriteLine(" Employee name:{0}, Designation:{1}, Department Id:{2}",EmployeeDetails.EmployeeName,EmployeeDetails.Designation,EmployeeDetails.DepartmentId);
                }

            }
            else
            {
                Console.WriteLine("No data Found");
            }

            //Delayed Projects
            Console.WriteLine("Delayed Projects-");
            IEnumerable<Project> delayedProjectList = dataManager.GetAllDelayedProjects();
            if(delayedProjectList.ElementAtOrDefault(0)!=null)
            {
                foreach (Project delayProjectDetails in delayedProjectList)
                {
                    Console.WriteLine("Project ID:{0} Project Name:{1}", delayProjectDetails.ProjectId, delayProjectDetails.ProjectName);
                }
            }
            else
            {
                Console.WriteLine("No data Found");
            }

            
            //Get all projects for employee
            Console.WriteLine("Enter Employee ID to check details of Projects assigned:");
            int employeeId = int.Parse(Console.ReadLine());
            IEnumerable<Project> projectListForEmployee = dataManager.GetAllProjectsForEmployee(employeeId);

            if(projectListForEmployee.ElementAtOrDefault(0)!=null)
            {
                foreach (Project projectDetailsForEmployee in projectListForEmployee)
                {
                    Console.WriteLine("Project ID:{0} Project Name:{1}", projectDetailsForEmployee.ProjectId, projectDetailsForEmployee.ProjectName);
                }
            }
            else
            {
                Console.WriteLine("No data Found");
            }

            // all tasks for employee
            Console.WriteLine("Enter Employee ID to check tasks for Employee:");
            employeeId = int.Parse(Console.ReadLine());
            IEnumerable<DataLayerLib.Task> taskListForEmployee = dataManager.GetAllTasksForEmployee(employeeId);

            if(taskListForEmployee.ElementAtOrDefault(0)!=null)
            {
                foreach (DataLayerLib.Task taskForEmployee in taskListForEmployee)
                {
                    Console.WriteLine("Task ID:{0} Task Name:{1}", taskForEmployee.TaskId, taskForEmployee.TaskName);
                }
            }
            else
            {
                Console.WriteLine("No data Found");
            }

            //Task technology for employee
            Console.WriteLine("Enter Employee ID to check tasks by technology for Employee:");
            employeeId = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Technology ID for Employee:");
            int technologyId = int.Parse(Console.ReadLine());
            IEnumerable<DataLayerLib.Task> taskTechnologyListForEmployee = dataManager.GetAllTechnologyTasksForEmployee(technologyId,employeeId);

            if (taskTechnologyListForEmployee.ElementAtOrDefault(0) != null)
            {
                foreach (DataLayerLib.Task tasksTechnologyForEmployee in taskTechnologyListForEmployee)
                {
                    Console.WriteLine("Task ID:{0} Task Name:{1}", tasksTechnologyForEmployee.TaskId, tasksTechnologyForEmployee.TaskName);
                }

            }
            else
            {
                Console.WriteLine("No data Found");
            }

            //project by Technology 
            Console.WriteLine("Enter Technology ID for searching Project:");
            technologyId = int.Parse(Console.ReadLine());
            IEnumerable<Project> projectListByTechnology = dataManager.GetAllTechnologyProjects(technologyId);

            if(projectListByTechnology.ElementAtOrDefault(0)!=null)
            {
                foreach (Project getProjectByTechnology in projectListByTechnology)
                {
                    status = Enum.GetName(typeof(Status), getProjectByTechnology.StatusId);
                    Console.WriteLine("Project ID:{0}, Project Name:{1}, Status: {2}, Department ID: {3}", getProjectByTechnology.ProjectId, getProjectByTechnology.ProjectName, status, getProjectByTechnology.DepartmentId);
                }
            }
            else
            {
                Console.WriteLine("No data Found");
            }

            //active task list for project
            Console.WriteLine("Enter Project ID for checking task status:");
            projectId = int.Parse(Console.ReadLine());
            IEnumerable<DataLayerLib.Task> activeTaskListForProject = dataManager.GetAllActiveTasksForProject(projectId);

            if(activeTaskListForProject.ElementAtOrDefault(0)!=null)
            {
                foreach (DataLayerLib.Task activeTaskForProject in activeTaskListForProject)
                {
                    Console.WriteLine("Task ID:{0} Task Name:{1}", activeTaskForProject.TaskId, activeTaskForProject.TaskName);
                }
            }
            else
            {
                Console.WriteLine("No data Found");
            }
            //get technology for employee
            Console.WriteLine("Enter Employee ID to check technologies used by Employee:");
            employeeId = int.Parse(Console.ReadLine());
            IEnumerable<TechnologyMaster> technologyListByEmployee = dataManager.GetAllTechnologiesForEmployee(employeeId);
            if(technologyListByEmployee.ElementAtOrDefault(0)!=null)
            {
                foreach (TechnologyMaster technologyByEmployee in technologyListByEmployee)
                {
                    Console.WriteLine("Technology ID:{0} Technology Name:{1}", technologyByEmployee.TechnologyId, technologyByEmployee.TechnologyName);
                }

            }
            else
            {
                Console.WriteLine("No data Found");
            }

            //get project count for employee
            Console.WriteLine("Enter Employee ID to check Project by Employee:");
            employeeId = int.Parse(Console.ReadLine());
            int projectCountForEmployee = dataManager.GetProjectCountForEmployee(employeeId);
            Console.WriteLine("Total Projects under Employee ID:{0} are:{1}",employeeId,projectCountForEmployee);

            //get active projects managed by employee
            Console.WriteLine("Enter Employee ID to check active Project Managed by Employee:");
            employeeId = int.Parse(Console.ReadLine());
            IEnumerable<Project> activeProjectListManagedByEmployee = dataManager.GetAllActiveProjectsManagedByEmployee(employeeId);
            if(activeProjectListManagedByEmployee.ElementAtOrDefault(0)!=null)
            {
                foreach (Project activeProjectByEmployee in activeProjectListManagedByEmployee)
                {
                    Console.WriteLine("Project ID:{0}, Project Name:{1}", activeProjectByEmployee.ProjectId, activeProjectByEmployee.ProjectName);
                }

            }
            else
            {
                Console.WriteLine("No data Found");
            }

            //get delayed tasks for employee
            Console.WriteLine("Enter Employee ID to check delayed tasks by Employee:");
            employeeId = int.Parse(Console.ReadLine());
            IEnumerable<DataLayerLib.Task> delayedTaskListForEmployee = dataManager.GetAllDelayedTasksForEmployee(employeeId);
            if(delayedTaskListForEmployee.ElementAtOrDefault(0)!=null)
            {
                foreach (DataLayerLib.Task delayedTaskForEmployee in delayedTaskListForEmployee)
                {
                    Console.WriteLine("Task ID:{0} Task Name:{1}", delayedTaskForEmployee.TaskId, delayedTaskForEmployee.TaskName);
                }

            }
            else
            {
                Console.WriteLine("No data Found");
            }
           */
            //Add Project
            /*  Project newProject = new Project();

              Console.WriteLine("Enter data for new project");
              Console.WriteLine("Enter Project Name:");
              newProject.ProjectName= Console.ReadLine();
              Console.WriteLine("Enter Project Status(1/2/3):\n 1.not started\n 2.active\n 3.delayed");
              newProject.StatusId = int.Parse(Console.ReadLine());

              Console.WriteLine("Enter Department Id:");
              newProject.DepartmentId = int.Parse(Console.ReadLine());
              dataManager.AddProject(newProject);

              //Add Technology
              TechnologyMaster newTechnologyMaster = new TechnologyMaster();
              Console.WriteLine("Enter Technology Name:");
              newTechnologyMaster.TechnologyName=Console.ReadLine();
              dataManager.AddTechnology(newTechnologyMaster);

              //Add employee
              Employee newEmployee = new Employee();
              int departmentHeadId;
              Console.WriteLine("Enter data for new employee");
              Console.WriteLine("Enter Employee Name:");
              newEmployee.EmployeeName = Console.ReadLine();
              Console.WriteLine("Enter Designation:");
              newEmployee.Designation = Console.ReadLine();
              Console.WriteLine("Enter DepartmentID:");
              newEmployee.DepartmentId = int.Parse(Console.ReadLine());
              Console.WriteLine("Enter Department Head Id:");
              //newEmployee.DepartmentHeadId = int.Parse(Console.ReadLine());
              int.TryParse(Console.ReadLine(),out departmentHeadId);
              if (departmentHeadId == 0)
                  newEmployee.DepartmentHeadId = null;
              else
                  newEmployee.DepartmentHeadId = departmentHeadId;
              dataManager.AddEmployee(newEmployee);

            //assign employee to project
            Console.WriteLine("Enter Employee Id:");
            int employeeId = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Project Id:");
            int projectId = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Role Id:");
            int roleId = int.Parse(Console.ReadLine());
            dataManager.AssignEmployeeToProject(employeeId, projectId, roleId);

            //create task in project
            DataLayerLib.Task task = new DataLayerLib.Task();
            Console.WriteLine("Enter Project Id:");
            int projectId = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Task Id:");
            task.TaskId = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter task Status(1/2/3):\n 1.not started\n 2.active\n 3.delayed");
            int statusId = int.Parse(Console.ReadLine());
            dataManager.CreateTaskInProject(task, projectId, statusId);

            //assign technology to task
            Console.WriteLine("Enter Task Id:");
            int taskId = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Technology Id:");
            int technologyId = int.Parse(Console.ReadLine());
            dataManager.AssignTechnologyToTask(technologyId, taskId);

            //update technology for task
            Console.WriteLine("Enter Task Id:");
            int taskId = int.Parse(Console.ReadLine());
            char choice = 'y';
            int technologyId;
            List<int> technologyIDs = new List<int>();
            while (choice == 'y' || choice == 'Y')
            {
                Console.WriteLine("Enter Technology Id:");
                technologyId = int.Parse(Console.ReadLine());
                technologyIDs.Add(technologyId);
                Console.WriteLine("Enter more technologies for the task? (y/n):");
                choice = Console.ReadLine().ElementAt(0);
            }
            dataManager.UpdateTechnologiesForTask(technologyIDs, taskId);*/
            /*
            //delete employee
            Console.WriteLine("Enter Employee Id:");
            int employeeId = int.Parse(Console.ReadLine());
            dataManager.DeleteEmployeeFromSystem(employeeId);
            
            //delete technology
            Console.WriteLine("Enter Technology Id:");
            int technologyId = int.Parse(Console.ReadLine());
            dataManager.DeleteTechnology(technologyId);
            */
            //delete project
            Console.WriteLine("Enter Project Id:");
            int projectId = int.Parse(Console.ReadLine());
            dataManager.DeleteProject(projectId);


            Console.ReadLine();
        }

       

        


    }



}
