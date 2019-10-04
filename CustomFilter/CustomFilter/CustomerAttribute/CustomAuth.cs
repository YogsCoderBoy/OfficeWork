using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomFilter.CustomerAttribute
{
    public class CustomAuth:AuthorizeAttribute
    {
        private bool localAllowed;
        public CustomAuth(bool allowParam)
        {
            localAllowed = allowParam;
        }
    }
}
