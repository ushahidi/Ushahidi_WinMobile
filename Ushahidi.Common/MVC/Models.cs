﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Xml;
using Ushahidi.Common.Extensions;
using Ushahidi.Common.Logging;
using Ushahidi.Common.Net;

namespace Ushahidi.Common.MVC
{
    /// <summary>
    /// Generic collection of models
    /// </summary>
    /// <typeparam name="TModel">model</typeparam>
    public class Models<TModel> : BindingList<TModel>, IDisposable where TModel : Model
    {
        /// <summary>
        /// Add range of models
        /// </summary>
        /// <param name="models">range of models</param>
        public void Add(IEnumerable<TModel> models)
        {
            foreach (TModel model in models)
            {
                Add(model);
            }    
        }

        /// <summary>
        /// Load collection of models
        /// </summary>
        /// <typeparam name="TModels">models</typeparam>
        /// <param name="directory">source directory</param>
        /// <returns>collection of models</returns>
        protected static TModels Load<TModels>(string directory) where TModels : Models<TModel>, new()
        {
            TModels models = new TModels();
            foreach (string filePath in directory.GetFiles("*.xml", "*.uploaded"))
            {
                TModel model = Model.Load<TModel>(filePath);
                if (model != null)
                {
                    model.FilePath = filePath;
                    models.Add(model);
                }
            }
            return models;
        }

        /// <summary>
        /// Download TModels
        /// </summary>
        /// <typeparam name="TModels"></typeparam>
        /// <param name="url">download url</param>
        /// <param name="directory">destination directory</param>
        /// <param name="identifier">model identifier</param>
        /// <returns>Collection of TModels</returns>
        protected static TModels Download<TModels>(string url, string directory, string identifier) where TModels : Models<TModel>, new()
        {
            try
            {
                List<TModel> uploaded = new List<TModel>();
                foreach (string filePath in directory.GetFiles("*.uploaded"))
                {
                    TModel model = Model.Load<TModel>(filePath);
                    if (model != null)
                    {
                        model.FilePath = filePath;
                        uploaded.Add(model);
                    }
                }
                TModels models = new TModels();
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                ServicePointManager.CertificatePolicy = Internet.AcceptAllCertificatePolicy();
                request.KeepAlive = false;
                request.Credentials = CredentialCache.DefaultCredentials;
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    using (Stream dataStream = response.GetResponseStream())
                    {
                        XmlDocument document = new XmlDocument();
                        document.Load(dataStream);
                        foreach (XmlNode node in document.GetElementsByTagName(identifier))
                        {
                            try
                            {
                                string modelXML = node.OuterXml;
                                TModel model = Model.Parse<TModel>(modelXML);
                                if (model != null)
                                {
                                    model.FilePath = Path.Combine(directory, string.Format("{0}.xml", model.ID));
                                    if (File.Exists(model.FilePath))
                                    {
                                        File.Delete(model.FilePath);
                                    }
                                    using (TextWriter writer = new StreamWriter(model.FilePath))
                                    {
                                        writer.WriteLine(modelXML);
                                    }
                                    TModel duplicateModel = uploaded.FirstOrDefault(p => p.Equals(model));
                                    if (duplicateModel != null && duplicateModel.ID < 0)
                                    {
                                        if (duplicateModel.Delete())
                                        {
                                            uploaded.Remove(duplicateModel);
                                            Log.Info("Models.Download", "Duplicate model deleted: {0}", duplicateModel.ID);
                                        }
                                    }
                                    models.Add(model);
                                }
                            }
                            catch (Exception ex)
                            {
                                Log.Exception("DataManager.Download", "Exception: {0}", ex.Message);
                            }
                        }
                    }
                }
                if (uploaded.Count > 0)
                {
                    models.Add(uploaded);
                }
                return models;
            }
            catch (Exception ex)
            {
                Log.Exception("DataManager.Download", "{0} {1}", ex.Message, url);
            }
            return null;

        }

        protected void Sort(IComparer<TModel> comparer)
        {
            Sort(comparer, null);
        }
        
        protected void Sort(Comparison<TModel> comparison)
        {
           Sort(null, comparison);
        }

        private void Sort(IComparer<TModel> comparer, Comparison<TModel> comparison)
        {
            List<TModel> sortList = new List<TModel>();
            sortList.AddRange(this);
            if (comparer != null)
            {
                sortList.Sort(comparer);
            }
            else if (comparison != null)
            {
                sortList.Sort(comparison);
            }
            bool oldRaise = RaiseListChangedEvents;
            RaiseListChangedEvents = false;
            try
            {
                ClearItems();
                Add(sortList);
            }
            finally
            {
                RaiseListChangedEvents = oldRaise;
                ResetBindings();
            }
        }

        public void Dispose()
        {
            foreach(TModel model in this.Reverse())
            {
                model.Dispose();
            }
        }
    }
}
