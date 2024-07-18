using Microsoft.AspNetCore.Identity;
using YuriiPasternak.SimpleRealEstate.Domain.Entities;

namespace YuriiPasternak.SimpleRealEstate.Domain.Identity
{
    public class AppUser : IdentityUser<Guid>
    {
        public AppUser() {
            Realties = new HashSet<Realty>();
            RealtyHeatingTypes = new HashSet<RealtyHeatingType>();
            RealtyPlanningTypes = new HashSet<RealtyPlanningType>();
            RealtyWallTypes = new HashSet<RealtyWallType>();
        }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        public virtual ICollection<Realty> Realties { get; set; }
        public virtual ICollection<RealtyHeatingType> RealtyHeatingTypes { get; set; }
        public virtual ICollection<RealtyPlanningType> RealtyPlanningTypes { get; set; }
        public virtual ICollection<RealtyWallType> RealtyWallTypes { get; set; }
    }
}
