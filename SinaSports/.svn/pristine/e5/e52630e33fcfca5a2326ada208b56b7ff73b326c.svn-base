using Sina.Sports.Common.Images;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sina.Sports.Common.UI.Images
{
    public class ImageManager//这个Manager的好处就是简化ImageLoader的初始化
    {
        public static ImageLoader Loader
        {
            get
            {
                ImageLoader loader = new ImageLoader();
                loader.Init("", "", new Cache.CacheStrategy());
                return loader;
            }
        }
    }
}
