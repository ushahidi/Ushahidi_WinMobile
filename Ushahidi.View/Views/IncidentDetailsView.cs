using System;
using System.Collections.Generic;
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
    partial class IncidentDetailsView
    {
        public override void Initialize()
        {
            base.Initialize();
            menuItemIncidentDetailsAddPhoto.Click += OnAddPhoto;
            menuItemIncidentDetailsAddNews.Click += OnAddNews;
            menuItemIncidentDetailsAddVideo.Click += OnAddVideo;
            menuItemIncidentDetailsViewMap.Click += OnViewMap;
            scrollListBoxMediaItems.ItemSelected += OnItemSelected;
        }

        public override void Translate()
        {
            base.Translate();
            menuItemIncidentDetailsAddPhoto.Translate(this);
            menuItemIncidentDetailsViewMap.Translate(this);
        }

        public override void Render()
        {
            base.Render();
            scrollListBoxMediaItems.Clear();
            scrollListBoxMediaItems.Add(new TextListItem("title".Translate(), Title, true), false);
            scrollListBoxMediaItems.Add(new TextListItem("description".Translate(), Description), false);
            scrollListBoxMediaItems.Add(new TextListItem("category".Translate(), Category), false);
            scrollListBoxMediaItems.Add(new LocaleListItem(Locale));
            scrollListBoxMediaItems.Add(new TextListItem("date".Translate(), Date.ToString("MMMM d, yyyy h:mm tt")), false);
            string verified = Verified ? "verified".Translate() : "notVerified".Translate();
            string active = Active ? "active".Translate() : "notActive".Translate();
            scrollListBoxMediaItems.Add(new TextListItem("verifiedAndActive".Translate(), string.Format("{0} - {1}", verified, active)), false);
            foreach (Media media in MediaItems.Where(m => m.MediaType != MediaType.Photo))
            {
                scrollListBoxMediaItems.Add(new LinkListItem(GetMediaTypeLabel(media.MediaType), media.Link), false);
            }
            foreach (Media media in MediaItems.Where(m => m.MediaType == MediaType.Photo))
            {
                scrollListBoxMediaItems.Add(new PhotoListItem(DataManager.LoadImage(media.Link)), false);
            }
            scrollListBoxMediaItems.Refresh();
        }

        private static string GetMediaTypeLabel(MediaType mediaType)
        {
            if (mediaType == MediaType.News)  return "news".Translate();
            if (mediaType == MediaType.Audio) return "audio".Translate();
            if (mediaType == MediaType.Video) return "video".Translate();
            if (mediaType == MediaType.Photo) return "photo".Translate();
            return string.Empty;
        }

        public int ID { get; set; }

        public string Title { get; set; }

        public string Category { get; set; }

        public string Description { get; set; }

        public DateTime Date { get; set; }

        public Locale Locale { get; set; }
 
        public bool Verified { get; set; }

        public bool Active { get; set; }

        public Media[] MediaItems
        {
            get { return _MediaItems.ToArray(); }
            set
            {
                _MediaItems.Clear();
                if (value != null)
                {
                    _MediaItems.AddRange(value);
                }
            }
        }private readonly List<Media> _MediaItems = new List<Media>();
        
        private void OnViewMap(object sender, EventArgs e)
        {
            OnForward<IncidentMapViewController>(false);
        }

        private void OnAddPhoto(object sender, EventArgs e)
        {
            Media media = DataManager.ImportPhoto(PhotoSelector.ShowDialog(this));
            if (media != null)
            {
                _MediaItems.Add(media);
                DataManager.AddMedia(ID, media);
                scrollListBoxMediaItems.Add(new PhotoListItem(DataManager.LoadImage(media.Link)));
                scrollListBoxMediaItems.AdjustHeight();
            }
        }

        private void OnAddNews(object sender, EventArgs e)
        {
            OnForward<WebsiteViewController>(false, string.Empty, menuItemIncidentDetailsAddNews.Text);
        }

        private void OnAddVideo(object sender, EventArgs e)
        {
            OnForward<WebsiteViewController>(false, string.Empty, menuItemIncidentDetailsAddVideo.Text);
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
                OnForward<IncidentPhotoViewController>(false, mediaPhotoListItem.Image);
            }
            else if (linkListItem != null)
            {
                OnForward<WebsiteViewController>(false, linkListItem.Link);
            }
            else if (mapListItem != null)
            {
                OnForward<IncidentMapViewController>(false, Locale.Latitude, Locale.Longitude);
            }
        }
    }
}
