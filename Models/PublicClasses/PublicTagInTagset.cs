using Microsoft.EntityFrameworkCore;

namespace ObjectCubeServer.Models.PublicClasses
{
    [Keyless]
    public class PublicTagInTagset
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TagsetIdReplicate { get; set; }
        public int TagTypeId { get; set; }
        public int? TagType { get; set; }
        public int TagsetId { get; set; }
        public int? ObjectTagRelations { get; set; }

        public PublicTagInTagset(
            int id,
            string name,
            int tagsetId,
            int tagTypeId,
            int tagsetIdReplicate,
            int? tagType,
            int? objectTagRelations
            )
        {
            Id = id;
            Name = name;
            TagsetIdReplicate = tagsetIdReplicate;
            TagTypeId = tagTypeId;
            TagType = tagType;
            TagsetId = tagsetId;
            ObjectTagRelations = objectTagRelations;
        }
    }
}
