using ObjectCubeServer.Models.DomainClasses;
using System.Collections.Generic;
using ObjectCubeServer.Models.PublicClasses;
using Microsoft.EntityFrameworkCore;

namespace ObjectCubeServer.Models.DomainClasses
{
    [Keyless]
    public class HierarchyInTagset
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TagsetId { get; set; }
        public int? Nodes { get; set; }
        public int RootNodeId { get; set; }

        public HierarchyInTagset(
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

        public PublicHierarchyInTagset GetPublicHierarchyInTagset()
        {
            return new PublicHierarchyInTagset(
                this.Id,
                this.Name,
                this.TagsetId,
                this.Nodes,
                this.RootNodeId);
        }
    }
}
