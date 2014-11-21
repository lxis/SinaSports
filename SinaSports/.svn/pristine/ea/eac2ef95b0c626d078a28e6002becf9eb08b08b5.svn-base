using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Sina.Sports.Common.InversionofControl
{
    /// <summary>
    /// 简单接口注入类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Ioc<T> where T : class
    {
        private static readonly object lockObject = new object();

        private static T instance;

        /// <summary>
        /// 获取类单例
        /// </summary>
        public static T Instance
        {
            get
            {
                if (instance == null)                
                    lock (lockObject)                    
                        if (instance == null)                        
                            instance = CreateInstance();                                                                                    
                return instance;
            }
        }

        /// <summary>
        /// 创建类普通实例
        /// </summary>
        /// <returns></returns>
        public static T Create()
        {
            return CreateInstance();
        }

        private static T CreateInstance()
        {
            var customAttributes = typeof(T).GetTypeInfo().GetCustomAttributes(false);
            ResolveAttribute attribute = customAttributes.SingleOrDefault(c => c is ResolveAttribute) as ResolveAttribute;
            if (attribute == null) throw new ArgumentException(string.Format("Type:{0} Resolve attribute can't find.",typeof(T).Name));
            try
            {
                return (T)Activator.CreateInstance(attribute.Type);
            }
            catch (InvalidCastException e)
            {
                throw new ArgumentException(string.Format("Ioc error: class {0} should Impement interface {1}", attribute.Type.Name, typeof(T).Name), e);
            }
            throw new ArgumentException("Should not be here.");
        }
    }
}
