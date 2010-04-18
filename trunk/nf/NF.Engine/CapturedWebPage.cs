﻿using System;
using System.Collections.Generic;
using System.Text;

namespace NF.Engine
{
    public class CaptureWebPage
    {
        public string Title { get; set; }
        public string Url { get; set; }
        public string ImageName { get; set; }
        public string ThumbImageName { get; set; }
        public string Src { get; set; }
        public string FullThumbnailImagePath {
            get { 
                return string.Format("{0}/{1}", Util.GetRelativeImageFolder(), ThumbImageName);
            }
        }
        public string Category { get; set; }
        public string ShortCategory {
            get {
                switch (Category) { 
                    case "Top Stories":
                        return "top";
                    case "Business":
                        return "bus";
                    case "Sci/Tech":
                        return "sci";
                    case "Entertainment":
                        return "ent";
                }
                return string.Empty;
            }
        }
        private string _type = "section";
        public string Type {
            get {
                return _type;
            }
            set {
                _type = value;
            }
        }

    }

    public class PageList : List<CaptureWebPage> {
        public CaptureWebPage Get(string imgName) {
            return base.Find(delegate(CaptureWebPage p) { return p.ImageName == imgName; });
        }

        public PageList GetAll(string cat) {
            return GetAll("section", cat);
        }

        public PageList GetAll(string type, string cat) {
            List<CaptureWebPage> list = base.FindAll(delegate(CaptureWebPage p) { return p.Category.ToLower() == cat.ToLower() && p.Type.ToLower() == type.ToLower(); });
            PageList pl = new PageList();
            for (int i = 0; i < list.Count; i++) {
                pl.Add(list[i]);
            }
            return pl;
        }
    }
}