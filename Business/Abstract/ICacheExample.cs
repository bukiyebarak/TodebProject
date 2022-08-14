using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICacheExample
    {
        //Distirubed Cache 
        void DistSetString(string key, string value);
        void DistSetList(string key);
        string DistGetValue(string key);

        //Inmemory Cache
        void InMemSetString(string key, string value);
        void InMemSetObject(string key, object value);
        T InMemGetValue<T>(string key);
    }
}
