using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeAPI.Domain.Entities
{


    public enum ProjectStatus
    {
        Closed,
        InProgress,
        Hold
    }
    public class Project
    {

        public int Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

        public int Duration { get; set; }

        public ProjectStatus Status { get; set; }

        public List<Employee> Employees { get; set; }


    }
}
