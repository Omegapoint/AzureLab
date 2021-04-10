using System;
using System.Text.Json.Serialization;

namespace Ginastics.Api
{
    // public record Gin(
    //     [property:JsonPropertyName("ginId")] Guid GinId, 
    //     [property:JsonPropertyName("name")] string Name, 
    //     [property:JsonPropertyName("abv")] string Abv, 
    //     [property:JsonPropertyName("country")] string Country, 
    //     [property:JsonPropertyName("distillery")] string Distillery);

    public class Gin
    {
        [JsonPropertyName("ginId")]  public Guid GinId { get; init; }
        [JsonPropertyName("name")] public string Name { get; init; }
        [JsonPropertyName("abv")]public string Abv { get; init; }
        [JsonPropertyName("country")] public string Country { get; init; }
        [JsonPropertyName("distillery")] public string Distillery { get; init; }

        protected bool Equals(Gin other)
        {
            return GinId.Equals(other.GinId) && 
                   Name == other.Name && 
                   Abv == other.Abv && 
                   Country == other.Country && 
                   Distillery == other.Distillery;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Gin) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(GinId, Name, Abv, Country, Distillery);
        }
    }
}

