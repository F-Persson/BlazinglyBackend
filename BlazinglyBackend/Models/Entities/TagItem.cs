using System;
using System.Collections.Generic;

namespace APIBackend.Models.Entities;

public partial class TagItem
{
    public int Id { get; set; }

    public DateTime Time { get; set; }

    public string Selection { get; set; }

    public string Url { get; set; }

    public string Title { get; set; }

    public string MetaDescription { get; set; }

    public virtual ICollection<Tag> Tags { get; set; } = new List<Tag>();
}
