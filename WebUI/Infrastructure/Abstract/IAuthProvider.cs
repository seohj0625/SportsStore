﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebUI.Infrastructure.Abstract
{
    public interface IAuthProvider
    {
        bool Authentication(string username, string password);
    }
}
