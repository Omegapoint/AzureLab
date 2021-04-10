using System;
using System.Text.Json.Serialization;

namespace Ginastics.Api
{
    public record GinGetResponse(
        
        [property:JsonPropertyName("ginId")] Guid GinId, 
        [property:JsonPropertyName("name")] string Name, 
        [property:JsonPropertyName("abv")] string Abv, 
        [property:JsonPropertyName("country")] string Country, 
        [property:JsonPropertyName("distillery")] string Distillery);
}