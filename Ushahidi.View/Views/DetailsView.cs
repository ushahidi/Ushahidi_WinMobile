using System;
using System.Linq;
using Ushahidi.Common.Controls;
using Ushahidi.Model;
using Ushahidi.Model.Models;
using Ushahidi.View.Controllers;
using Ushahidi.View.Controls;
using Ushahidi.Model.Extensions;

namespace Ushahidi.View.Views
{
    /// <summary>
    /// Incident details view
    /// </summary>
    public partial class DetailsView : BaseView
    {
        public DetailsView()
        {
            InitializeComponent();    
        }

        public override void Translate()
        {
            base.Translate();
            this.Translate("incidentDetails");
            menuItemAddPhoto.Translate("addPhoto");
            menuItemAddNews.Translate("addNewsLink");
            menuItemAddVideo.Translate("addVideoLink");
        }

        public override void Render()
        {
            base.Render();
            listBoxDetails.Clear();
            listBoxDetails.Add(new TextListItem("title".Translate(), Incident.Title, true));
            listBoxDetails.Add(new TextListItem("description".Translate(), Incident.Description));
            listBoxDetails.Add(new TextListItem("category".Translate(), Incident.CategoryTitle));
            listBoxDetails.Add(new TextListItem("date".Translate(), Incident.Date.ToString("MMMM d, yyyy h:mm tt")));
            string verified = Incident.Verified ? "verified".Translate() : "notVerified".Translate();
            string active = Incident.Active ? "active".Translate() : "notActive".Translate();
            listBoxDetails.Add(new TextListItem("verifiedAndActive".Translate(), string.Format("{0} - {1}", verified, active)));
            listBoxDetails.Add(new LocaleListItem(Incident.Locale));
            foreach (Media media in Incident.MediaItems.Where(m => m.MediaType != MediaType.Photo))
            {
                listBoxDetails.Add(new LinkListItem(GetMediaTypeLabel(media.MediaType), media.Link));
            }
            foreach (Media media in Incident.MediaItems.Where(m => m.MediaType == MediaType.Photo))
            {
                listBoxDetails.Add(new PhotoListItem(DataManager.LoadImage(media.Link)));
            }
            if (DataManager.HasMap(Incident.ID))
            {
                listBoxDetails.Add(new PhotoListItem(DataManager.LoadMap(Incident.ID)));
            }
        }

        private static string GetMediaTypeLabel(MediaType mediaType)
        {
            if (mediaType == MediaType.News)  return "news".Translate();
            if (mediaType == MediaType.Audio) return "audio".Translate();
            if (mediaType == MediaType.Video) return "video".Translate();
            if (mediaType == MediaType.Photo) return "photo".Translate();
            return string.Empty;
        }

        public Incident Incident { get; set; }
        
        private void OnAddPhoto(object sender, EventArgs e)
        {
            Media media = DataManager.ImportPhoto(PhotoSelector.ShowDialog(this));
            if (media != null)
            {
                Incident.AddPhoto(media);
                listBoxDetails.Add(new PhotoListItem(DataManager.LoadImage(media.Link)));
                listBoxDetails.AdjustHeight();
            }
        }

        private void OnAddNews(object sender, EventArgs e)
        {
            OnForward<WebsiteViewController>(false, menuItemAddNews.Text);
        }

        private void OnAddVideo(object sender, EventArgs e)
        {
            OnForward<WebsiteViewController>(false, menuItemAddVideo.Text);
        }

        private void OnItemSelected(object sender, ScrollEventArgs args)
        {
            PhotoListItem mediaPhotoListItem = args.Item as PhotoListItem;
            TextListItem textListItem = args.Item as TextListItem;
            LinkListItem linkListItem = args.Item as LinkListItem;
            LocaleListItem mapListItem = args.Item as LocaleListItem;
            if (textListItem != null)
            {
                Dialog.Help(textListItem.Label, textListItem.Text);
            }
            else if (mediaPhotoListItem != null)
            {
                OnForward<PhotoViewController>(false, mediaPhotoListItem.Image);
            }
            else if (linkListItem != null)
            {
                OnForward<WebsiteViewController>(false, linkListItem.Link);
            }
            else if (mapListItem != null)
            {
                Dialog.Help(mapListItem.Item.Name, string.Format("({0},{1})", mapListItem.Item.Latitude, mapListItem.Item.Longitude));
                //OnForward<MapViewController>(false, Incident.LocaleName, Incident.LocaleLatitude, Incident.LocaleLongitude);
            }
        }
    }
}
