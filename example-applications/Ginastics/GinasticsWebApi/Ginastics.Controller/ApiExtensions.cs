using System;
using Ginastics.Api;
using Ginastics.Domain.Model;

namespace Ginastics.Controller
{
    public static class ApiExtensions
    {
        public static Gin ToDomain(this GinCreateRequest ginCreateRequest)
        {
            return new Gin(
                Guid.NewGuid(),
                ginCreateRequest.Name,
                ginCreateRequest.Abv,
                ginCreateRequest.Country,
                ginCreateRequest.Distillery
            );
        }

        public static GinGetResponse ToApi(this Gin gin)
        {
            return new GinGetResponse(
                gin.GinId,
                gin.Name,
                gin.Abv,
                gin.Country,
                gin.Distillery
            );
        }
    }
}