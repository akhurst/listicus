using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Listicus.Core.Models;

namespace Listicus.Soap
{
    [ServiceContract]
    public interface IListService
    {
        [OperationContract]
        List GetList(long listId);
    }
}
