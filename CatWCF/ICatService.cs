using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;
using CatWCF.DataContract;

namespace CatWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface ICatService
    {

        [OperationContract]
        Task<int> CountCats();

        [OperationContract]
        Task<CatContract> GetCatByName(string name);

        [OperationContract]
        Task<List<CatContract>> GetCatsByGender(string gender);
    }


}
