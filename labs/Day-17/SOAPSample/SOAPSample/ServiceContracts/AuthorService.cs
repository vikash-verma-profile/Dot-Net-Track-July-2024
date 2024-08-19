using System.ServiceModel;
using System.Xml.Linq;

namespace SOAPSample.ServiceContracts
{
    [ServiceContract]
    public interface IAuthorService
    {
        [OperationContract]
        void MySoapMethod(XElement xml);
    }
    public class AuthorService : IAuthorService
    {
        public void MySoapMethod(XElement xml)
        {
            Console.WriteLine(xml.ToString());
        }
    }
}
