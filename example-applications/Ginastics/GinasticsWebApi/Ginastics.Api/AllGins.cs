using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Ginastics.Api
{
    public class AllGins
    {
        [JsonPropertyName("gins")] public List<Gin> Gins { get; init; }

        protected bool Equals(AllGins other)
        {
            return Equals(Gins, other.Gins);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((AllGins) obj);
        }

        public override int GetHashCode()
        {
            return (Gins != null ? Gins.GetHashCode() : 0);
        }
    }
}