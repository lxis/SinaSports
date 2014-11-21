
using Sina.Sports.Common.InversionofControl;
using Sina.Sports.Server.Common.CustomExceptions.Imp;
namespace Sina.Sports.Server.Common.CustomExceptions
{
   [Resolve(typeof(VerifyerBase))]
    public interface IJsonVerifyer
    {
        /// <summary>
        /// 检验json结果是否正确
        /// </summary>
        /// <param name="code"></param>
        /// <param name="errorMsg"></param>
        void Verify(int code, string errorMsg = null);
    }
}
