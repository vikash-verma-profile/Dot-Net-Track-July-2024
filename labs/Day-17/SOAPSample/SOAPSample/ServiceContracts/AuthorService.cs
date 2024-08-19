using System.ServiceModel;
using System.Xml.Linq;

namespace SOAPSample.ServiceContracts
{
    [ServiceContract]
    public interface IAuthorService
    {
        [OperationContract]
        int MySoapMethod(int num1,int num2);
    }
    public class AuthorService : IAuthorService
    {
        public int MySoapMethod(int num1,int num2)
        {
            return (num1 + num2);
        }
    }
}
