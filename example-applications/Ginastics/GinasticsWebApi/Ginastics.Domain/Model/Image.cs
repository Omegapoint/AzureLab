using System;

namespace Ginastics.Domain.Model
{
    public record Image(
        string FileName,
        byte[] Content,
        GinId GinId,
        ImageId ImageId
    );
}