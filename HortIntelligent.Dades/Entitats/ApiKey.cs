using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HortIntelligent.Dades.Entitats
{
    public class ApiKey
    {
        public int ApiKeyId { get; set; }
        public Guid Key { get; set; }
        public string Name { get; set; }
        public DateTime Exipres { get; set; }
    }
}
