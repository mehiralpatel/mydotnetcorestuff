using System;
using System.Collections.Generic;

namespace WebApplication1.Models.DB
{
    public partial class Model
    {
        public Model()
        {
            Project = new HashSet<Project>();
        }

        public int ModelId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public short Status { get; set; }

        public ICollection<Project> Project { get; set; }
    }
}
