using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WEB_API_CORE.Models
{
    public class ClsPersona
    {
        public long id { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string sexo { get; set; }
        public string dni { get; set; }
    }
}
