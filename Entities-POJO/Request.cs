using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJO
{
    
    public class Request : BaseEntity
    {
        public int Id { get; set; }
        public string IdUser { get; set; }
        public int IdMedia { get; set; }
        public DateTime ElapsedTime { get; set; }
        public int IdCategory { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
        public string CategoryName { get; set; }

        public Request() { } 
    }
}
