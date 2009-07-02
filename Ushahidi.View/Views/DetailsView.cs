using System;
using System.Drawing;
using System.Linq;
using Ushahidi.Common.Controls;
using Ushahidi.Model;
using Ushahidi.Model.Models;
using Ushahidi.View.Controllers;
using Ushahidi.View.Controls;
using Ushahidi.Model.Extensions;
using Ushahidi.View.Extensions;

namespace Ushahidi.View.Views
{
    /// <summary>
    /// Incident Details View
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
            scrollListBox.BackColor = Color.White;
            scrollListBox.BackColorEven = Color.Gainsboro;
            scrollListBox.BackColorOdd = Color.WhiteSmoke;
            scrollListBox.BackSelectedColor = Color.Black;
            scrollListBox.ForeSelectedColor = Color.White;
        }

        public override void Translate()
        {
            base.Translate();
            this.Translate("incidentDetails");
            menuItemAddPhoto.Translate("addPhotoLink");
            menuItemAddNews.Translate("addNewsLink");
            menuItemAddVideo.Translate("addVideoLink");
        }

        public override void Render()
        {
            base.Render();
            scrollListBox.Clear();
            if (Incident != null)
            {
                scrollListBox.Add(new TextListItem("title".Translate(), Incident.Title, true));
                scrollListBox.Add(new TextListItem("description".Translate(), Incident.Description));
                scrollListBox.Add(new TextListItem("category".Translate(), Incident.CategoryTitle));
                scrollListBox.Add(new TextListItem("date".Translate(), Incident.Date.ToString("MMMM d, yyyy h:mm tt")));
                string verified = Incident.Verified ? "verified".Translate() : "notVerified".Translate();
                string active = Incident.Active ? "active".Translate() : "notActive".Translate();
                scrollListBox.Add(new TextListItem("verifiedAndActive".Translate(),
                                                   string.Format("{0} - {1}", verified, active)));
                scrollListBox.Add(new LocaleListItem(Incident.Locale));
                foreach (Media media in Incident.MediaItems.Where(m => m.MediaType != MediaType.Photo))
                {
                    scrollListBox.Add(media);
                }
                foreach (Media media in Incident.MediaItems.Where(m => m.MediaType == MediaType.Photo))
                {
                    scrollListBox.Add(media);
                }
                if (DataManager.HasMap(Incident.ID))
                {
                    scrollListBox.Add(DataManager.LoadMap(Incident.ID));
                }
            }
        }

        public Incident Incident { get; set; }

        public void AddMedia(Media media)
        {
            Incident.AddMedia(media);
        }

        private void OnAddPhoto(object sender, EventArgs e)
        {
            OnForward<MediaViewController>(false, MediaType.Photo);
        }

        private void OnAddNews(object sender, EventArgs e)
        {
            OnForward<MediaViewController>(false, MediaType.News);
        }

        private void OnAddVideo(object sender, EventArgs e)
        {
            OnForward<MediaViewController>(false, MediaType.Video);
        }

        private void OnItemSelected(object sender, ScrollEventArgs args)
        {
            if (args.Item is TextListItem)
            {
                TextListItem textListItem = args.Item as TextListItem;
                Dialog.Help(textListItem.Label, textListItem.Text);
            }
            else if (args.Item is PhotoListItem)
            {
                PhotoListItem mediaPhotoListItem = args.Item as PhotoListItem;
                OnForward<PhotoViewController>(false, mediaPhotoListItem.Image);
            }
            else if (args.Item is LinkListItem)
            {
                LinkListItem linkListItem = args.Item as LinkListItem;
                OnForward<WebsiteViewController>(false, linkListItem.Link);
            }
            else if (args.Item is LocaleListItem)
            {
                LocaleListItem mapListItem = args.Item as LocaleListItem;
                Dialog.Help(mapListItem.Item.Name, string.Format("({0},{1})", mapListItem.Item.Latitude, mapListItem.Item.Longitude));
            }
        }
    }
}
