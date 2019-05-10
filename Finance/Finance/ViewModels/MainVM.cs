﻿using Finance.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Text;
using System.Xml.Serialization;

namespace Finance.ViewModels
{
    public class MainVM : INotifyPropertyChanged
    {
        public Posts Blog
        {
            get;
            set;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public MainVM()
        {
            ReadRSS();
        }

        public void ReadRSS()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Posts));

            using (WebClient client = new WebClient())
            {
                string xml = Encoding.Default.GetString(client.DownloadData("https://www.finzen.mx/blog-feed.xml"));
                using (Stream reader = new MemoryStream(Encoding.UTF8.GetBytes(xml)))
                {
                    Blog = (Posts)serializer.Deserialize(reader);
                }
            }
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
