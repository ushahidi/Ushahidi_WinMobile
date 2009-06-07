using System;
using System.Linq;
using Ushahidi.Common.Controls;
using Ushahidi.Model;
using Ushahidi.Model.Models;
using Ushahidi.View.Controllers;
using Ushahidi.View.Controls;
using Ushahidi.View.Languages;

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

        public override void Initialize()
        {
            base.Initialize();
            menuItemIncidentDetailsAddPhoto.Click += OnAddPhoto;
            menuItemIncidentDetailsAddNews.Click += OnAddNews;
            menuItemIncidentDetailsAddVideo.Click += OnAddVideo;
            scrollListBox.ItemSelected += OnItemSelected;
        }

        public override void Translate()
        {
            base.Translate();
            menuItemIncidentDetailsAddPhoto.Translate(this);
            menuItemIncidentDetailsAddNews.Translate(this);
            menuItemIncidentDetailsAddVideo.Translate(this);
        }

        public override void Render()
        {
            base.Render();
            scrollListBox.Clear();
            scrollListBox.Add(new TextListItem("title".Translate(), Incident.Title, true));
            scrollListBox.Add(new TextListItem("description".Translate(), Incident.Description));
            scrollListBox.Add(new TextListItem("category".Translate(), Incident.CategoryTitle));
            scrollListBox.Add(new LocaleListItem(Incident.Locale));
            scrollListBox.Add(new TextListItem("date".Translate(), Incident.Date.ToString("MMMM d, yyyy h:mm tt")));
            string verified = Incident.Verified ? "verified".Translate() : "notVerified".Translate();
            string active = Incident.Active ? "active".Translate() : "notActive".Translate();
            scrollListBox.Add(new TextListItem("verifiedAndActive".Translate(), string.Format("{0} - {1}", verified, active)));
            foreach (Media media in Incident.MediaItems.Where(m => m.MediaType != MediaType.Photo))
            {
                scrollListBox.Add(new LinkListItem(GetMediaTypeLabel(media.MediaType), media.Link));
            }
            foreach (Media media in Incident.MediaItems.Where(m => m.MediaType == MediaType.Photo))
            {
                scrollListBox.Add(new PhotoListItem(DataManager.LoadImage(media.Link)));
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
                scrollListBox.Add(new PhotoListItem(DataManager.LoadImage(media.Link)));
                scrollListBox.AdjustHeight();
            }
        }

        private void OnAddNews(object sender, EventArgs e)
        {
            OnForward<WebsiteViewController>(false, menuItemIncidentDetailsAddNews.Text);
        }

        private void OnAddVideo(object sender, EventArgs e)
        {
            OnForward<WebsiteViewController>(false, menuItemIncidentDetailsAddVideo.Text);
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
                OnForward<MapViewController>(false, Incident.LocaleName, Incident.LocaleLatitude, Incident.LocaleLongitude);
            }
        }
    }
}
