using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayerLib
{
    class ValidationHelper
    {
        public static Project CheckProjectNameExists(string projectName)
        {
            CDDataContext db = new CDDataContext();
            Project projectObj = (from projects in db.Projects
                                  where projects.ProjectName.Equals(projectName)
                                  select projects).FirstOrDefault();
            return projectObj;
        }

        public static StatusMaster CheckStatusExists(int statusId)
        {
            CDDataContext db = new CDDataContext();
            StatusMaster statusObj = (from status in db.StatusMasters
                                      where status.StatusId == statusId
                                      select status).FirstOrDefault();
            return statusObj;
        }


        public static TechnologyMaster CheckTechnologyNameExists(string technologyName)
        {
            CDDataContext db = new CDDataContext();
            TechnologyMaster technologyObj = (from technology in db.TechnologyMasters
                                              where technology.TechnologyName.Equals(technologyName)
                                              select technology).FirstOrDefault();
            return technologyObj;
        }

        public static DepartmentMaster CheckDepartmentIdExists(int departmentId)
        {
            CDDataContext db = new CDDataContext();
            DepartmentMaster departmentObj = (from department in db.DepartmentMasters
                                              where departmentId == department.DepartmentId
                                              select department).FirstOrDefault();
            return departmentObj;
        }

        public static Employee CheckEmployeeIdExists(int employeeId)
        {
            CDDataContext db = new CDDataContext();
            Employee employeeObj = (from employee in db.Employees
                                    where employee.EmployeeId == employeeId
                                    select employee).FirstOrDefault();
            return employeeObj;
        }

        public static Project CheckProjectIdExists(int? projectId)
        {
            CDDataContext db = new CDDataContext();
            Project projectObj = (from project in db.Projects
                                  where project.ProjectId == projectId
                                  select project).FirstOrDefault();
            return projectObj;
        }

        public static Roletype CheckRoleIdExists(int? roleId)
        {
            CDDataContext db = new CDDataContext();
            Roletype roleTypeObj = (from roleType in db.Roletypes
                                    where roleType.RoleId == roleId
                                    select roleType).FirstOrDefault();
            return roleTypeObj;
        }

        public static Task CheckTaskExists(int taskId)
        {
            CDDataContext db = new CDDataContext();
            Task taskIdObj = (from task in db.Tasks
                              where task.TaskId == taskId
                              select task).FirstOrDefault();
            return taskIdObj;
        }

        public static TechnologyMaster CheckTechnologyIdExists(int technologyId)
        {
            CDDataContext db = new CDDataContext();
            TechnologyMaster technologyObj = (from technology in db.TechnologyMasters
                                              where technology.TechnologyId == technologyId
                                              select technology).FirstOrDefault();
            return technologyObj;
        }
        public static string CheckCompulsoryProjectColumns(Project project)
        {
            if (string.IsNullOrEmpty(project.ProjectName))
            {
                return Resource.ProjectNameMissing;
            }
            else
            {
                if (CheckProjectNameExists(project.ProjectName) != null)
                {
                    return Resource.ProjectNameExists;
                }
                else
                {
                    if (CheckStatusExists(project.StatusId) == null)
                    {
                        return Resource.StatusIdMissing;
                    }
                    else
                    {
                        if (CheckDepartmentIdExists(project.DepartmentId) == null)
                        {
                            return Resource.DepartmentIDMissing;
                        }
                        else
                        {
                            return Resource.AllFieldsPresent;
                        }
                    }
                }
            }
        }

        public static string CheckCompulsoryTechnologyMasterColumns(TechnologyMaster technologyMaster)
        {
            if (string.IsNullOrEmpty(technologyMaster.TechnologyName))
            {
                return Resource.TechnologyNameMissing;
            }
            else
            {
                if (CheckTechnologyNameExists(technologyMaster.TechnologyName) != null)
                {
                    return Resource.TechnologyNameExists;
                }
                else
                {
                    return Resource.AllFieldsPresent;
                }
            }
        }

        public static string CheckCompulsoryEmployeeColumns(Employee employee)
        {
            if (string.IsNullOrEmpty(employee.EmployeeName))
            {
                return Resource.EmployeeNameMissing;
            }
            else
            {
                if (string.IsNullOrEmpty(employee.Designation))
                {
                    return Resource.DesignationMissing;
                }
                else
                {
                    if (CheckDepartmentIdExists(employee.DepartmentId) == null)
                    {
                        return Resource.DepartmentIDMissing;
                    }
                    else
                    {
                        return Resource.AllFieldsPresent;
                    }
                }
            }
        }

        public static string CheckCompulsoryEmployeeProjectColumns(EmployeeProject employeeProject)
        {

            if (employeeProject.EmployeeId == 0)
            {
                return Resource.EmployeeIdMissing;
            }
            else
            {
                if (CheckEmployeeIdExists(employeeProject.EmployeeId) == null)
                {
                    return Resource.EmployeeIdMissing;
                }
                else
                {
                    if (CheckProjectIdExists(employeeProject.ProjectId) == null)
                    {
                        return Resource.ProjectIdMissing;
                    }
                    else
                    {
                        if (CheckRoleIdExists(employeeProject.RoleId) == null)
                        {
                            return Resource.RoleIDMissing;
                        }
                        else
                        {
                            return Resource.AllFieldsPresent;
                        }
                    }
                }
            }
        }
        public static string CheckCompulsoryTaskProjectColumns(ProjectTask projectTask)
        {
            if (projectTask.ProjectId == 0)
            {
                return Resource.ProjectIdMissing;
            }
            else
            {
                if (projectTask.TaskId == 0)
                {
                    return Resource.TaskIdMissing;
                }
                else
                {
                    if (CheckProjectIdExists(projectTask.ProjectId) == null)
                    {
                        return Resource.ProjectIdMissing;
                    }
                    else
                    {
                        if (CheckTaskExists(projectTask.TaskId) == null)
                        {
                            return Resource.TaskIdMissing;
                        }
                        else
                        {
                            if (CheckProjectIdExists(projectTask.ProjectId) == null)
                            {
                                return Resource.ProjectIdMissing;
                            }
                            else
                            {
                                if (CheckStatusExists(projectTask.StatusId) == null)
                                {
                                    return Resource.StatusIdMissing;
                                }
                                else
                                {
                                    return Resource.AllFieldsPresent;
                                }
                            }
                        }
                    }
                }
            }
        }

        public static string CheckCompulsoryTaskTechnologyColumns(TaskTechnology taskTechnology)
        {
            if (taskTechnology.TaskId == 0)
            {
                return Resource.TaskIdMissing;
            }
            else
            {
                if (taskTechnology.TechnologyId == 0)
                {
                    return Resource.TaskIdMissing;
                }
                else
                {
                    if (CheckTechnologyIdExists(taskTechnology.TechnologyId) == null)
                    {
                        return Resource.TechnologyIdMissing;
                    }
                    else
                    {
                        if (CheckTaskExists(taskTechnology.TaskId) == null)
                        {
                            return Resource.TaskIdMissing;
                        }
                        else
                        {
                            return Resource.AllFieldsPresent;
                        }
                    }
                }
            }
        }

        public static string CheckEmployeeIdValidity(int employeeId)
        {
            if (employeeId == 0)
            {
                return Resource.EmployeeIdMissing;
            }
            else
            {
                if (CheckEmployeeIdExists(employeeId) == null)
                {
                    return Resource.EmployeeIdMissing;
                }
                else
                {
                    return Resource.EmployeeIdFound;
                }
            }
        }

        public static string CheckTechnologyIdValidity(int technologyId)
        {
            if (technologyId == 0)
            {
                return Resource.TechnologyIdMissing;
            }
            else
            {
                if (CheckTechnologyIdExists(technologyId) == null)
                {
                    return Resource.TechnologyIdMissing;
                }
                else
                {
                    return Resource.TechnologyIdFound;
                }
            }
        }

        public static string CheckTaskIdValidity(int taskId)
        {
            if (taskId == 0)
            {
                return Resource.TaskIdMissing;
            }
            else
            {
                if (CheckTaskExists(taskId) == null)
                {
                    return Resource.TaskIdMissing;
                }
                else
                {
                    return Resource.TaskIdFound;
                }
            }
        }

        public static string CheckProjectIdValidity(int projectId)
        {
            if (projectId == 0)
            {
                return Resource.ProjectIdMissing;
            }
            else
            {
                if (CheckProjectIdExists(projectId) == null)
                {
                    return Resource.ProjectIdMissing;
                }
                else
                {
                    return Resource.ProjectIdFound;
                }
            }
        }
    }
}
