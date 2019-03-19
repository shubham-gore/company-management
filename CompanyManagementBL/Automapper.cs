using AutoMapper;
using CompanyManagementBL.Entities;
using DataLayerLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagementBL
{
    public class Automapper
    {
        public static void AutomapperConfig()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Client, BOClient>();
                cfg.CreateMap<Company, BOCompany>().ForMember(boCompany => boCompany.Departments, company => company.MapFrom(companyObj => companyObj.DepartmentMasters));
                cfg.CreateMap<DepartmentMaster, BODepartment>();
                cfg.CreateMap<Employee, BOEmployee>().ForMember(boEmployee =>boEmployee.Department, employee => employee.MapFrom(employeeObj => employeeObj.DepartmentMaster));
                cfg.CreateMap<BOEmployee,Employee>();
                //cfg.CreateMap<EmployeeProject, BOEmployeeProject>();
               // cfg.CreateMap<EmployeeTask, BOEmployeeTask>();
                cfg.CreateMap<Project, BOProject>().ForMember(boProject => boProject.Department, project => project.MapFrom(projectObj => projectObj.DepartmentMaster));
                cfg.CreateMap<BOProject, Project>();//.ForMember(project => project.DepartmentMaster, bOProject => bOProject.MapFrom(bOProjectObj => bOProjectObj.Department))
                //cfg.CreateMap<ProjectTask, BOProjectTask>();
                //cfg.CreateMap<ProjectTechnology, BOProjectTechnology>();
                cfg.CreateMap<Roletype, BORoletype>();
                cfg.CreateMap<StatusMaster, BOStatus>();
                cfg.CreateMap<DataLayerLib.Task, BOTask>();
                cfg.CreateMap<BOTask, DataLayerLib.Task>();
                //cfg.CreateMap<TaskTechnology, BOTaskTechnology>();
                cfg.CreateMap<TechnologyMaster, BOTechnology>().ReverseMap();


            });
        }
        public BOCompany MapCompanyToBOCompany(Company company)
        {
            //MapperConfiguration config = new MapperConfiguration(cfg => { cfg.CreateMap<Company, BOCompany>(); });
            //Mapper.Initialize(cfg =>
            //{
            //    cfg.CreateMap<Company, BOCompany>()
            //    //.ForMember(o => o.CompanyId, b => b.MapFrom(z => z.CompanyId))
            //    //.ForMember(o => o.CompanyName, b => b.MapFrom(z => z.CompanyName))
            //    ;
            //});
            //IMapper mapper = config.CreateMapper();
            //DataManager dataManager = new DataManager();
            //Company company = dataManager.GetCompany();
            BOCompany bloCompany = Mapper.Map<Company, BOCompany>(company);

            //Mapper.CreateMap<Company, BOCompany>();

            //   global::AutoMapper.Mapper.CreateMap<Company, BOCompany>()
            //   .ForMember(o => o.companyId, b => b.MapFrom(z => z._CompanyId))
            //.ForMember(o => o.companyName, b => b.MapFrom(z => z._CompanyName));
            return bloCompany;
        }

        public List<BOProject> MapProjectListToBOProjectList(IEnumerable<Project> projectList)
        {
            //Mapper.Initialize(cfg => cfg.CreateMap<Project,BOProject>());
            //DataManager dataManager = new DataManager();
            //IEnumerable<Project> projectList = dataManager.GetAllProjects();
            //IEnumerable<DataLayerLib.Task> taskList = new List<DataLayerLib.Task>(); //dataManager.GetAllActiveTasksForProject();
            
            List<BOProject> bloProjectList = Mapper.Map<IEnumerable<Project>, List<BOProject>>(projectList);
            //Mapper.Map<IEnumerable<ProjectTask>, List<BOProject>>(projectList,bloProjectList);
            //List <DataLayerLib.Task> taskTemp= new List<DataLayerLib.Task>();
            foreach (BOProject bloProject in bloProjectList)
            {
                bloProject.StatusName = Enum.GetName(typeof(Status),bloProject.StatusId);
            //    tasktemp = (datamanager.getallactivetasksforproject(bloproject.projectid)).tolist();
            //    if (tasktemp.any())
            //    {
            //        bloproject.tasklist.addrange(tasktemp);
            //    }
                
            }


            return bloProjectList;
        }

        public List<BOTechnology> MapTechnologyListToBOTechnologyList(IEnumerable<TechnologyMaster> technologyList)
        {
            //DataManager dataManager = new DataManager();
            //IEnumerable<TechnologyMaster> technologyList = dataManager.GetAllTechnologies();
            List<BOTechnology> bloTechnologyList = Mapper.Map<IEnumerable<TechnologyMaster>, List<BOTechnology>>(technologyList);
            return bloTechnologyList;
        }
        public List<BOEmployee> MapEmployeeListToBOEmployeeList(IEnumerable<Employee> employeeList)
        {
            List<BOEmployee> bloEmployeeList = Mapper.Map<IEnumerable<Employee>, List<BOEmployee>>(employeeList);
            return bloEmployeeList;
        }
        
        public List<BOTask> MapTaskListToBOTaskList(IEnumerable<DataLayerLib.Task> taskList)
        {
            List<BOTask> bloTaskList = Mapper.Map<IEnumerable<DataLayerLib.Task>,List<BOTask>>(taskList);
            return bloTaskList;
        }

        public Project MapBOProjectToProject(BOProject bOProject)
        {
            Project project = Mapper.Map<BOProject,Project>(bOProject);
            return project;
        }

        public TechnologyMaster MapBOTechnologytoTechnologyMaster(BOTechnology bOTechnology)
        {
            TechnologyMaster technology = Mapper.Map<BOTechnology,TechnologyMaster>(bOTechnology);
            return technology;
        }
        public Employee MapBOEmployeeToEmployee(BOEmployee bOEmployee)
        {
            Employee employee = Mapper.Map<BOEmployee,Employee>(bOEmployee);
            return employee;
        }

        public DataLayerLib.Task MapBOTaskToTask(BOTask bOTask)
        {
            DataLayerLib.Task task = Mapper.Map<BOTask, DataLayerLib.Task>(bOTask);
            return task;
        }
    }


}
