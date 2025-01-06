using System.Collections.Generic;

namespace ObjectCubeServer.Models.PublicClasses
{
    public class PublicAugmentedTagset
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<PublicTagInTagset> Tags;
        public List<PublicHierarchyInTagset> Hierarchies;

        public PublicAugmentedTagset(int id, string name, List<PublicTagInTagset> tags, List<PublicHierarchyInTagset> hierarchies)
        {
            Id = id;
            Name = name;
            Tags = tags;
            Hierarchies = hierarchies;
        }
    }
}
