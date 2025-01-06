using Microsoft.EntityFrameworkCore;

namespace ObjectCubeServer.Models.PublicClasses
{
    [Keyless]
    public class PublicHierarchyInTagset
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TagsetId { get; set; }
        public int? Nodes { get; set; }
        public int RootNodeId { get; set; }

        public PublicHierarchyInTagset(
            int id,
            string name,
            int tagsetId,
            int? nodes,
            int rootNodeId
            )
        {
            Id = id;
            Name = name;
            TagsetId = tagsetId;
            Nodes = nodes;
            RootNodeId = rootNodeId;
        }
    }
}
