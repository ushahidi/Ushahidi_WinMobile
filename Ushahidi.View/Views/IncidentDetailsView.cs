using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
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
            scrollListBoxMediaItems.Add(new TextListItem("title".Translate(), Title) {Bold = true}, false);
            scrollListBoxMediaItems.Add(new TextListItem("description".Translate(), Description), false);
            scrollListBoxMediaItems.Add(new TextListItem("category".Translate(), Category), false);
            scrollListBoxMediaItems.Add(new LocaleListItem(Locale, Latitude, Longitude));
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

        public string Title { get; set; }

        public string Category { get; set; }

        public string Locale { get; set; }

        public string Description { get; set; }

        public DateTime Date { get; set; }

        public string Latitude { get; set; }

        public string Longitude { get; set; }
        
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
            FileInfo fileInfo = PhotoSelector.ShowDialog(this);
            if (fileInfo != null && fileInfo.Exists)
            {
                using (new WaitCursor())
                {
                    string fileName = string.Format("{0}.jpg", DateTime.Now.ToString("yyyy_MM_dd_hh_mm_ss"));
                    string filePath = Path.Combine(DataManager.DataDirectory, fileName);
                    fileInfo.CopyTo(filePath, true);
                    _MediaItems.Add(Media.NewPhoto(fileName));
                    scrollListBoxMediaItems.Add(new PhotoListItem(new Bitmap(filePath)));
                    scrollListBoxMediaItems.AdjustHeight();
                }
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

        private void OnItemSelected(ScrollListBoxItem control)
        {
            PhotoListItem mediaPhotoListItem = control as PhotoListItem;
            TextListItem textListItem = control as TextListItem;
            LinkListItem linkListItem = control as LinkListItem;
            LocaleListItem mapListItem = control as LocaleListItem;
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
                OnForward<IncidentMapViewController>(false);
            }
        }
    }
}
