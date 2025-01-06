using ObjectCubeServer.Models.DomainClasses;
using System.Collections.Generic;
using ObjectCubeServer.Models.PublicClasses;
using Microsoft.EntityFrameworkCore;

namespace ObjectCubeServer.Models.DomainClasses
{
    [Keyless]
    public class TagInTagset
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TagsetIdReplicate { get; set; }
        public int TagTypeId { get; set; }
        public int? TagType { get; set; }
        public int TagsetId { get; set; }
        public int? ObjectTagRelations { get; set; }

        public TagInTagset(
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

        public PublicTagInTagset GetPublicTagInTagset()
        {
            return new PublicTagInTagset(
                this.Id,
                this.Name,
                this.TagsetId,
                this.TagTypeId,
                this.TagsetIdReplicate,
                this.TagType,
                this.ObjectTagRelations);
        }
    }
}
