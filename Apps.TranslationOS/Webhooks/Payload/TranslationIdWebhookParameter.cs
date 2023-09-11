using Blackbird.Applications.Sdk.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.TranslationOS.Webhooks.Payload
{
    public class TranslationIdWebhookParameter
    {
        [Display("Translation request ID")]
        public string Id { get; set; }
    }
}
