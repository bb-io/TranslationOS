using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace Apps.TranslationOS
{
    public class ApplicationConstants
    {
        public const string BridgeServiceUrl = "https://bridge.blackbird.io/api/webhooks/translationOS";

        public const string BlackbirdToken = "d50d2593-bd15-4893-978e-e3d1768b0524"; // bridge validates this token
    }
}
