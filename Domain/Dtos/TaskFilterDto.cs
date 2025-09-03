using Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dtos
{
    public class TaskFilterDto
    {
        public int Take { get; set; }
        public int Skip { get; set; }
        public string Title { get; set; }
        public TaskStatusEnum Status { get; set; }
    }
}
