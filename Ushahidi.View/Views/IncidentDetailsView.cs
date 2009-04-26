using System;
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
            menuItemIncidentDetailAddPhoto.Click += OnAddPhoto;
            menuItemIncidentDetailViewMap.Click += OnViewMap;
            scrollListBoxMediaItems.ItemSelected += OnItemSelected;
        }

        public override void Translate()
        {
            base.Translate();
            menuItemIncidentDetailAddPhoto.Translate(this);
            menuItemIncidentDetailViewMap.Translate(this);
        }

        public override void Render()
        {
            base.Render();
            scrollListBoxMediaItems.Clear();
            scrollListBoxMediaItems.Add(new TextListItem("title".Translate(), Title) {Bold = true}, false);
            scrollListBoxMediaItems.Add(new TextListItem("description".Translate(), Description), false);
            scrollListBoxMediaItems.Add(new TextListItem("category".Translate(), Category), false);
            scrollListBoxMediaItems.Add(new TextListItem("locale".Translate(), string.Format("{0} ({1}, {2})", Locale, Latitude, Longitude)), false);
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
            if (mediaType == MediaType.News) return "news".Translate();
            if (mediaType == MediaType.Audio) return "audio".Translate();
            if (mediaType == MediaType.Video) return "video".Translate();
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

        public Media[] MediaItems { get; set; }
        
        private void OnViewMap(object sender, EventArgs e)
        {
            //TODO
        }

        private void OnAddPhoto(object sender, EventArgs e)
        {
            FileInfo fileInfo = PhotoSelector.ShowDialog(this);
            if (fileInfo != null && fileInfo.Exists)
            {
                using (new WaitCursor())
                {
                    //TODO add photo to incident   
                }
            }
        }

        private void OnItemSelected(ScrollListBoxItem control)
        {
            PhotoListItem mediaPhotoListItem = control as PhotoListItem;
            TextListItem textListItem = control as TextListItem;
            LinkListItem linkListItem = control as LinkListItem;
            if (mediaPhotoListItem != null)
            {
                OnForward(typeof(IncidentPhotoViewController), false, mediaPhotoListItem.Image);
            }
            else if (linkListItem != null)
            {
                OnForward(typeof(WebsiteViewController), false, linkListItem.Link, null);
            }
            else if (textListItem != null)
            {
                Dialog.Help(textListItem.Label, textListItem.Text);
            }
            
        }
    }
}
