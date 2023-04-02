namespace APIBackend.Models.Entities
{
    public class InputModel
    {
        public int Id { get; set; }
        public IList<string> Tags { get; set; }
        public DateTime Time { get; set; }
        public string Selection { get; set; }
        public string Url { get; set; }
        public string Title { get; set; }
        public string MetaDescription { get; set; }
        public bool isShowing { get; set; } = true;
    }
}
