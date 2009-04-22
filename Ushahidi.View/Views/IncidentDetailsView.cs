using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using Ushahidi.Common.Controls;
using Ushahidi.Common.Extensions;
using Ushahidi.Model.Models;
using Ushahidi.View.Controllers;
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
            imageListBox.ImageSelected += OnImageSelected;
            imageListBox.ThumbnailSize = ThumbnailSizes.FullWidth;
        }

        public override void Translate()
        {
            base.Translate();
            menuItemIncidentDetailAddPhoto.Translate(this);
            menuItemIncidentDetailViewMap.Translate(this);
        }

        /// <summary>
        /// Incident title
        /// </summary>
        public string Title
        {
            set { labelIncidentDetailTitle.Text = value; }
        }

        /// <summary>
        /// Incident location
        /// </summary>
        public string Locale
        {
            set { labelIncidentDetailLocale.Text = value; }
        }

        /// <summary>
        /// Incident description
        /// </summary>
        public string Description
        {
            set 
            { 
                labelIncidentDetailDescription.Text = value;
                labelIncidentDetailDescription.Height = labelIncidentDetailDescription.GetRequiredHeight(labelIncidentDetailDescription.Font, value);
                imageListBox.Top = labelIncidentDetailDescription.Bottom + labelIncidentDetailDescription.Left;
            }
        }

        /// <summary>
        /// Incident date
        /// </summary>
        public DateTime Date
        {
            set { labelIncidentDetailDate.Text = value.ToString(); }
        }

        public string Latitude { get; set; }

        public string Longitude { get; set; }

        /// <summary>
        /// Incident image
        /// </summary>
        public IEnumerable<Media> MedaItems
        {
            get { return _MedaItems; }
            set
            {
                _MedaItems.Clear();
                if (value != null && value.Count() > 0)
                {
                    _MedaItems.AddRange(value);
                    pictureBoxImage.Image = value.ElementAt(0).Thumbnail;
                    imageListBox.ClearImages();
                    foreach(Media media in value)
                    {
                        imageListBox.AddImage(media.Original);
                    }
                }
                else
                {
                    pictureBoxImage.Image = DefaultImage;
                    imageListBox.Images = null;
                }
            }
        }private readonly List<Media> _MedaItems = new List<Media>();

        /// <summary>
        /// Incident verified?
        /// </summary>
        public bool Verified
        {
            set
            {
                labelIncidentDetailVerified.Text = value ? "verified".Translate() : "notVerified".Translate();
                labelIncidentDetailVerified.ForeColor = value ? Color.Green : Color.Red;
            }
        }

        public bool Active { get; set; }

        private void OnViewMap(object sender, EventArgs e)
        {
            //TODO
        }

        private void OnAddPhoto(object sender, EventArgs e)
        {
            //TODO
        }

        private void OnImageSelected(object sender, Common.Controls.ImageSelectedEventArgs args)
        {
            OnForward(typeof(IncidentPhotoViewController), args.Image);
        }

        protected Image DefaultImage
        {
            get
            {
                if (_DefaultImage == null)
                {
                    foreach (string resource in Assembly.GetExecutingAssembly().GetManifestResourceNames())
                    {
                        if (!resource.EndsWith("no_photo.jpg")) continue;
                        using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resource))
                        {
                            if (stream != null)
                            {
                                _DefaultImage = new Bitmap(stream);
                            }
                            break;
                        }
                    }
                }
                return _DefaultImage;
            }
        }private Image _DefaultImage;
    }
}
