using System;
using System.Text.Json.Serialization;

namespace Ginastics.Api
{
    public class GinCreateRequest
    {
        [JsonPropertyName("name")] public string Name { get; init; }
    
        [JsonPropertyName("abv")] public string Abv { get; init; }

        [JsonPropertyName("country")] public string Country { get; init; }

        [JsonPropertyName("distillery")] public string Distillery { get; init; }

        protected bool Equals(GinCreateRequest other)
        {
            return Name == other.Name && 
                   Abv == other.Abv && 
                   Country == other.Country && 
                   Distillery == other.Distillery;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((GinCreateRequest) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Abv, Country, Distillery);
        }
    }
}