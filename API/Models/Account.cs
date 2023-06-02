namespace API.Models
{
    public class Account : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public Account(long id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }
        public Account(string name, string description)
        {
            Name = name;
            Description = description;
        }

    }
}
