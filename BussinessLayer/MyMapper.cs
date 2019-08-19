using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer
{
    public class MyMapper<T,S>
    {
        public T castTo(S obj)
        {
            T model;

            string serializedEntity = JsonConvert.SerializeObject(obj, new JsonSerializerSettings()
            {
                ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            });

            model = JsonConvert.DeserializeObject<T>(serializedEntity);
            return model;
        }

    }
}
