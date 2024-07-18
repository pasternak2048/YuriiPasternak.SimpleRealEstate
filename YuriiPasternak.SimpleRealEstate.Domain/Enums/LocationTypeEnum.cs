using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YuriiPasternak.SimpleRealEstate.Domain.Enums
{
    public enum LocationTypeEnum : int
    {
        None = 0,
        Region = 1,
        District = 2,
        Community = 3,
        City = 4,
        CityDistrict = 5,
        Village = 6,
        SmallTown = 7
    }
}