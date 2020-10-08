using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Configuration
{
    public class SendGridSettings : ISendGridSettings
    {
        public string ApiKey { get; set; }
        public string From { get; set; }
    }
}
