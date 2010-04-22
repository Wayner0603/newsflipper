using System;
using System.Collections.Generic;
using System.Text;

namespace NF.Engine
{
    public class WebPage
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public string ImageName { get; set; }
        public string ThumbImageName { get; set; }
        public string Src { get; set; }
        public string FullThumbnailImagePath {
            get { 
                return string.Format("{2}{0}/{1}", Util.GetRelativeImageFolder(), ThumbImageName, Util.GetBaseURL());
            }
        }
        public string Category { get; set; }
        public string Source{ get; set; }
        public string Section { get; set; }
        public string Country { get; set; }

    }
   
}
