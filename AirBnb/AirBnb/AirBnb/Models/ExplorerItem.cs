namespace AirBnb.Models
{
    public class ExplorerItem
    {
        public string ImageURL { get; set; }
        public string Title { get; set; }
        public ExplorerItem(string url,string title)
        {
            this.ImageURL       = url;
            this.Title          = title;

        }
    }
   
}
