using System;
using System.Net.Mime;
using Ginastics.Api;
using Ginastics.Domain.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Gin = Ginastics.Api.Gin;

namespace Ginastics.Controller
{
    public static class ApiExtensions
    {
        public static Domain.Model.Gin ToDomain(this GinCreateRequest ginCreateRequest)
        {
            return new(
                Guid.NewGuid(),
                ginCreateRequest.Name,
                ginCreateRequest.Abv,
                ginCreateRequest.Country,
                ginCreateRequest.Distillery
            );
        }

        public static Gin ToApi(this Domain.Model.Gin gin)
        {
            return new()
            {
                GinId = gin.GinId,
                Name = gin.Name,
                Abv = gin.Abv,
                Country = gin.Country,
                Distillery = gin.Distillery
            };
        }

        public static GinId ToGinId(this Guid guid)
        {
            return new(guid);
        }

        public static ImageId AsImageId(this Guid guid)
        {
            return new(guid);
        }

        public static FileContentResult AsFileContentResult(this Image image)
        {
            return new(image.Content, MediaTypeNames.Image.Jpeg)
            {
                FileDownloadName = image.FileName
            };
        }
    }
}