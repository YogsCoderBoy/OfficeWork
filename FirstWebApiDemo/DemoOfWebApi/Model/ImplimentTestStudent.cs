using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoOfWebApi.Inerface;

namespace DemoOfWebApi.Model
{
    public class ImplimentTestStudent : ITestStudent
    {
        public string TestFromService()
        {
            return "I m From  ImplimentTestStudent";
        }
    }
}
