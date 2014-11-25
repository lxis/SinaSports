using Sina.Sports.Common.Cache;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Controls;
using Sina.Sports.Server.Common.CustomExceptions;
using Sina.Sports.Server.Common.Imp;
using Sina.Sports.Server.Common.RequestModel;
using Sina.Sports.Server.Common.Cache;

namespace Sina.Sports.Common.Images
{
    /// <summary>
    /// 使用方法，在需要图片的页面上new一个ImageLoader，设置一下加载图片，错误图片地址，设一下缓存策略(这几步可以另建一个Manager来做，每个项目换不一样的Manager)
    /// </summary>
    public class ImageLoader
    {
        ImageSource failedImage { get; set; }

        ImageSource waitingImage { get; set; }

        CacheStrategy CacheStrategy { get; set; }        

        public async Task Bind(Image image,Func<Task<ImageSource>> imageSourceGetter)
        {            
            image.Source = waitingImage;
            try
            {
                image.Source = await imageSourceGetter();
            }
            catch (Exception)//这个异常是下载图片失败的，现在考虑的应该还不全
            {
                image.Source = failedImage;
                throw;
            }
        }

        public async Task Load(Image image,RestRequest request)
        {
            await Bind(image, ()=> new ImageDownloader().Download(request));
        }

        public void Init(string failedImagePath,string waitingImagePath,CacheStrategy cacheStrategy)
        {
            //failedImage = 
        }

        //////////////////////////////////////////////////////////




    }
}
