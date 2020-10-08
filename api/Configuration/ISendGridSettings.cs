using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Configuration
{
    public interface ISendGridSettings
    {
        string ApiKey { get; set; }
        string From { get; set; }
    }
}
