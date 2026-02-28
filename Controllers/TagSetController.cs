using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ObjectCubeServer.Models.Contexts;
using ObjectCubeServer.Models.DomainClasses;
using ObjectCubeServer.Models.PublicClasses;
using ObjectCubeServer.Services;

namespace ObjectCubeServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagsetController : ControllerBase
    {
        private readonly ObjectContext coContext;

        public TagsetController(ObjectContext coContext)
        {
            this.coContext = coContext;
        }

        // GET: api/tagset
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PublicTagset>>> Get()
        {
            List<PublicTagset> allTagsets = await coContext.Tagsets
                .Select(t => new PublicTagset(t.Id, t.Name))
                .ToListAsync();
            Console.WriteLine("LOG: Finished api/tagset");
            return Ok(allTagsets); //implicit Ignore self referencing loops
        }

        // GET: api/tagset/5
        [HttpGet("{id:int}", Name = "GetTagset")]
        public async Task<ActionResult<Tagset>> Get(int id)
        {
            //List<SingleObjectCell> singlecells = await
            //    coContext.SingleObjectCells.FromSqlRaw(queryGenerationService.generateSQLQueryForState(axisX.Type, axisX.Id, axisY.Type, axisY.Id, axisZ.Type, axisZ.Id, filtersList)).ToListAsync();
            //result = singlecells.Select(c =>
            //    new PublicCell(axisX.Ids[c.x], axisY.Ids[c.y], axisZ.Ids[c.z], c.count, c.id, c.fileURI, c.thumbnailURI)).ToList();

            Tagset tagsetWithId = await coContext.Tagsets
                    .Where(ts => ts.Id == id)
                    .FirstOrDefaultAsync();
            String _id = id.ToString();
            String SQLquery;

            SQLquery = "select id, name, tagsetId, tagTypeId, tagsetIdReplicate, tagType, objectTagRelations from tagset_tags where tagsetId = " + _id + ";";
            List<PublicTagInTagset> resulttags;
            List<TagInTagset> tags = await
                coContext.TagsInTagset.FromSqlRaw(SQLquery).ToListAsync();
            resulttags = tags.Select(c => c.GetPublicTagInTagset()).ToList();
            Console.WriteLine(SQLquery);

            SQLquery = "select id, name, tagsetId, nodes, rootNodeId from tagset_hierarchies where tagsetId = " + _id + ";";
            List<PublicHierarchyInTagset> resulthierarchies;
            List<HierarchyInTagset> hierarchies = await
                coContext.HierarchiesInTagset.FromSqlRaw(SQLquery).ToListAsync();
            resulthierarchies = hierarchies.Select(c => c.GetPublicHierarchyInTagset()).ToList();
            Console.WriteLine(SQLquery);

            PublicAugmentedTagset result = new PublicAugmentedTagset(tagsetWithId.Id, tagsetWithId.Name, resulttags, resulthierarchies);
            return Ok(result);
        }

        // GET: api/tagset/name=Year
        /// <summary>
        /// Returns all tags in a tagset as a list, where Tagset.name == tagsetName.
        /// </summary>
        /// <param tagsetName="tagsetName"></param>
        [HttpGet("name={tagsetName}")]
        public async Task<ActionResult<IEnumerable<PublicTag>>> GetAllTagsByTagsetName(string tagsetName)
        {
            var tagset = await coContext.Tagsets
                .Include(ts => ts.Tags)
                .FirstOrDefaultAsync(ts => ts.Name.ToLower() == tagsetName.ToLower());
            List<Tag>  tagsFound = tagset?.Tags;

            if (tagsFound == null) return NotFound();
            
            var result = tagsFound.Select(tag => new PublicTag(tag.Id, tag.GetTagName())).ToList();
            
            return Ok(result);
        }
    }
}
