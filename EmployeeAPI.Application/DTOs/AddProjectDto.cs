using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeAPI.Domain.Entities;

namespace EmployeeAPI.Application.DTOs
{
    public class AddProjectDto
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public int Duration { get; set; }

        public ProjectStatus Status { get; set; }
    }
}
