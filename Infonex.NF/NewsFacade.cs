using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Infonex.NF.Core;

namespace Infonex.NF.Facade {
    public class NewsFacade {

        public static List<Source> GetNewsSources(string country) {
            if (!CacheManager.IsValid(Constants.CACHE_SOURCE)) {
                List<Source> sourceCollection = SourceManager.GetSources(country);
                CacheManager.Add(Constants.CACHE_SOURCE, sourceCollection);
            }
            return (List<Source>)CacheManager.Get(Constants.CACHE_SOURCE);
        }

        public List<SourceLinkImage> GetNewsImages(int sourceId, string dateref) {
            string key = string.Format("{0}_{1}",Constants.CACHE_SOURCE_LINK_IMAGES_SRC, sourceId.ToString());
            if (!CacheManager.IsValid(key)) {
                List<SourceLinkImage> sourceCollection = SourceManager.GetSourceLinkImages(sourceId, dateref );
                CacheManager.Add(key, sourceCollection);
            }
            return (List<SourceLinkImage>)CacheManager.Get(key);
        }

        public List<SourceLinkImage> GetNewsImagesByCategory(int catId, string dateref) {
            string key = string.Format("{0}_{1}", Constants.CACHE_SOURCE_LINK_IMAGES_CAT, catId.ToString());
            if (!CacheManager.IsValid(key)) {
                List<SourceLinkImage> sourceCollection = SourceManager.GetSourceLinkImagesByCategory(catId, dateref);
                CacheManager.Add(key, sourceCollection);
            }
            return (List<SourceLinkImage>)CacheManager.Get(key);
        }

        
//function getdata(what) {
//    jQuery.get("mytime.aspx?type=" + what, function(response) {
//        count = 0;
//        carousel1.reset();
//    });

//    return false;
//}



//function mycarousel_itemLoadCallback(carousel, state) {
//    carousel1 = carousel;
//    // Only load items if they don't already exist
//    if (carousel.has(carousel.first, carousel.last)) {
//        return;
//    }

//    jQuery.get("GetServerTime.aspx?count=" + count, function(response) {
//        carousel.add(response.split(';')[0], response.split(';')[1]);
//    });
//    count++;
    }
}
