using baicuoiki2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace baicuoiki2.Controller
{
    internal class Client : IController
    {
        public List<IModel> Items => throw new NotImplementedException();

        public bool Add(IModel model)
        {
            throw new NotImplementedException();
        }

        public bool Delete(IModel model)
        {
            throw new NotImplementedException();
        }

        public bool Delete(object id)
        {
            throw new NotImplementedException();
        }

        public bool IsExist(object id)
        {
            throw new NotImplementedException();
        }

        public bool Load()
        {
            throw new NotImplementedException();
        }

        public IModel Read(object id)
        {
            throw new NotImplementedException();
        }

        public bool Update(IModel model)
        {
            throw new NotImplementedException();
        }
    }
}
