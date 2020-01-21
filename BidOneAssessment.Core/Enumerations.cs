using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace BidOneAssessment.Core
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ContactStatus
    {
        Lead,
        RegisteredMember,
        PastMember
    }
}
