using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.IEmailSender
{
    public class VerificationCodeGenerator : IVerificationCodeGenerator
    {
        public string Generate()
        {
            return new Random().Next(100000, 999999).ToString();
        }
    }

}
