using System;

namespace Ginastics.Domain.Model
{
    public record Gin(
        Guid GinId,
        string Name,
        string Abv,
        string Country,
        string Distillery);
}