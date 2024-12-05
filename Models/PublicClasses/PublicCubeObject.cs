using Microsoft.EntityFrameworkCore;

namespace ObjectCubeServer.Models.PublicClasses
{
    /// <summary>
    /// Represents an Object in the M^3 datamodel. (Simplified public model)
    /// Has an Id (CubeObjectId) and a FileURI.
    /// </summary>
    [Keyless]
    public class PublicCubeObject
    {
        public int Id { get; set; }
        public string FileURI { get; set; }

        public string ThumbnailURI { get; set; }

        public PublicCubeObject(int id, string fileURI, string thumbnailURI)
        {
            Id = id;
            FileURI = fileURI;
            ThumbnailURI = thumbnailURI;
        }
    }
}
