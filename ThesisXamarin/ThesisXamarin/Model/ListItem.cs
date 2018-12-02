using Xamarin.Forms;

namespace ThesisXamarin.Model
{
    public class ListItem
    {
        public string Description { get; }
        public ImageSource Image { get; }

        public ListItem(string description, ImageSource imageSrc)
        {
            this.Description = description;
            this.Image = imageSrc;
        }
    }
}

