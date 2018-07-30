using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MY7W.Domain
{
    public class BaseEntity<T>
    {
        public T ID { get; set; }
        public DateTime CreateTime { get; set; }
        public bool State { get; set; }
    }
}
