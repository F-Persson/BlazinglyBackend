using APIBackend.Models.Entities;

namespace APIBackend.Models
{
    public class TagItemService
    {
        public TagItem CreateOrUpdate(TagItem tagItem, InputModel inputModel)
        {
            tagItem.Id = inputModel.Id;
            tagItem.Time = inputModel.Time;
            tagItem.Selection = inputModel.Selection;
            tagItem.Url = inputModel.Url;
            tagItem.Title = inputModel.Title;
            tagItem.MetaDescription = inputModel.MetaDescription;
            tagItem.Tags = new List<Tag>();

            if (inputModel.Tags != null)
            {
                tagItem.Tags = inputModel.Tags.Select(tag => new Tag { TagName = tag }).ToList();
            }

            return tagItem;
        }
    }
}
