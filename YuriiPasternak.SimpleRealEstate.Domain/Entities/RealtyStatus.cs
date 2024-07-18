using YuriiPasternak.SimpleRealEstate.Domain.Enums;

namespace YuriiPasternak.SimpleRealEstate.Domain.Entities
{
    public class RealtyStatus
    {
        public RealtyStatus()
        {
            Realties = new HashSet<Realty>();
        }

        public RealtyStatusEnum Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public virtual ICollection<Realty> Realties { get; set; }
    }
}
