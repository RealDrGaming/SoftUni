namespace P02_FootballBetting.Data.Models
{
    public class Country
    {
        public int CountryId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Town> Towns { get;}
    }
}
