using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rema1000RestAPI
{
    public class NotFoundExeption : Exception
    {
        public NotFoundExeption(string name, int id)
            : base($"NO {name} with id: {id} was located")
        {
        }
    }
}
