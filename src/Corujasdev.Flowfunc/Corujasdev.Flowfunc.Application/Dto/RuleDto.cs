using System.Text.Json.Serialization;

namespace Corujasdev.Flowfunc.Application.Dto
{
    public sealed record RuleDto
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? FunctionName { get; set; }
        public string? RuleType { get; set; }
        public bool Active { get; set; }
        public DateTime DateCreated { get; set; }
        [JsonIgnore]
        public DateTime? DateDeleted { get; set; }

        public RuleDto()
        {
            Active = DateDeleted == null;
        }
    }
}
