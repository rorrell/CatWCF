using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Data.Entity;
using System.Threading.Tasks;
using CatWCF.DataContract;

namespace CatWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class CatService : ICatService
    {
        [WebInvoke(Method = "GET",
           UriTemplate = "/cats/count")]
        public async Task<int> CountCats()
        {
            using(var db = new CatsContext())
            {
                return await db.Cats.CountAsync();
            }
        }

        [WebInvoke(Method = "GET",
           UriTemplate = "/cats/name/{name}")]
        public async Task<CatContract> GetCatByName(string name)
        {
            using(var db = new CatsContext())
            {
                return await db.Cats.FirstOrDefaultAsync(c => c.Name.ToLower().Equals(name.ToLower())).ContinueWith(t =>
                {
                    if (t.IsFaulted)
                    {
                        throw t.Exception;
                    }
                    return new CatContract(t.Result);
                }, TaskContinuationOptions.OnlyOnRanToCompletion);
            }
        }

        [WebInvoke(Method = "GET",
           UriTemplate = "/cats/gender/{gender}")]
        public async Task<List<CatContract>> GetCatsByGender(string gender)
        {
            using(var db = new CatsContext())
            {
                return await db.Genders.FirstOrDefaultAsync(g => g.Description.Equals(gender, StringComparison.CurrentCultureIgnoreCase))?.ContinueWith(t =>
                {
                    if (t.IsFaulted)
                    {
                        throw t.Exception;
                    }
                    return t.Result?.Cats?.Select(c => new CatContract(c)).ToList();
                }, TaskContinuationOptions.OnlyOnRanToCompletion);
            }
        }
    }
}
