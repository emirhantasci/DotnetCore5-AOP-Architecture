using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmirApi.Core.Entities;

namespace EmirApi.Entities.Dtos
{
    public class TestDto:IDto
    {
        public int TestDtoId { get; set; }
        public string TestDtoDesc { get; set; }
    }
}
