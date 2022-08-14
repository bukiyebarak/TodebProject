using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cache
{
    public interface ICacheManager
    {
        T Get<T>(string key);
        object Get(string key);

        //duration ile eklemiş olduğumuz datanın ne kadar geçerli olduğunu belirliyoruz.
        void Add(string key, object data, int duration);

        void Add(string key, object data);

        //eklenip eklenmediğini kontrol ediyor.
        bool IsAdd(string key);
        void Remove(string key);

        //belirli birşeyle başlayan keylerin silinmesi.Örneğin ilk iki harfi 'ar' başlayan userları sil.
        void RemoveByPattern(string pattern);
    }
}
