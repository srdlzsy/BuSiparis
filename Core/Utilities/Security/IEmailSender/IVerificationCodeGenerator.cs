﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.IEmailSender
{
    public interface IVerificationCodeGenerator
    {
        string Generate();
    }
}
