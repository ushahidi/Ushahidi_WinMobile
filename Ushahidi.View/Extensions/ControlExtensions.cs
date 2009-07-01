using System.Drawing;
using Ushahidi.Common.Controls;
using Ushahidi.Model;
using Ushahidi.Model.Extensions;
using Ushahidi.Model.Models;
using Ushahidi.View.Controls;

namespace Ushahidi.View.Extensions
{
    public static class ControlExtensions
    {
        public static void Add(this ScrollListBox scrollListBox, Media media)
        {
            if (media.MediaType == MediaType.Photo && DataManager.HasImage(media.Link))
            {
                scrollListBox.Add(new PhotoListItem(DataManager.LoadImage(media.Link)));
            }
            else if (media.MediaType == MediaType.News)
            {
                scrollListBox.Add(new LinkListItem("news".Translate(), media.Link));
            }
            else if (media.MediaType == MediaType.Photo)
            {
                scrollListBox.Add(new LinkListItem("photo".Translate(), media.Link));
            }
            else if (media.MediaType == MediaType.Audio)
            {
                scrollListBox.Add(new LinkListItem("audio".Translate(), media.Link));
            }
            else if (media.MediaType == MediaType.Video)
            {
                scrollListBox.Add(new LinkListItem("video".Translate(), media.Link));
            }
        }

        public static void Add(this ScrollListBox scrollListBox, Image image)
        {
            scrollListBox.Add(new PhotoListItem(image));
        }
    }
}
