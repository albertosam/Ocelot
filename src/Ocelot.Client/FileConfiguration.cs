using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ocelot.Client
{
    public class FileConfiguration
    {
        public FileConfiguration()
        {
            ReRoutes = new List<FileReRoute>();
        }

        public List<FileReRoute> ReRoutes { get; set; }        
    }
}
