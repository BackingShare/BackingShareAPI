using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backing_Share___API.Models.Database
{
    public partial class Audio
    {
        public int Id { get; set; }
        public string name { get; set; }
        public int userId { get; set; }
    }
}
