using System.Text.Json.Serialization;

namespace API.Data.Account
{
    public class UpsertAccountInput
    {
        public UpsertAccountInput(long id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }

        [JsonIgnore]
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
