using YuriiPasternak.SimpleRealEstate.Domain.Enums;

namespace YuriiPasternak.SimpleRealEstate.Domain.Entities
{
    public class RealtyType
    {
        public RealtyType()
        {
            Realties = new HashSet<Realty>();
        }

        public RealtyTypeEnum Id { get; set; }
        public string? Name { get; set; }

        public virtual ICollection<Realty> Realties { get; set; }
    }
}
