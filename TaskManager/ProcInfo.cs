using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager
{
    public class ProcInfo
    {
        public int Id { get; set; }
        public string ProcessName { get; set; }
        public string Resp { get; set; }
        public long MemorySize { get; set; }
    }
}
