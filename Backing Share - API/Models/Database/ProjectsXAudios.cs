using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backing_Share___API.Models.Database
{
    public partial class ProjectsXAudios
    {
        public int Id { get; set; }
        public int audioId { get; set; }
        public int projectId { get; set; }
    }
}

