using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTanec.eCom.DataRepository
{
    public class BaseRepository<T>
    {
        private static T _repository = default(T);
        public static T GetInstance()
        {
            if (_repository == null)
                _repository = Activator.CreateInstance<T>();
            return _repository;
        }
    }
}
