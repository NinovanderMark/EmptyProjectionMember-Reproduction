using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmptyProjectionMember_Reproduction.Entities
{
    public class OldCar
    {
        public int Id { get; set; }
        public string CarBrand { get; set; }
        public Person Driver { get; set; }
    }
}
