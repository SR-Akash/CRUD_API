using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Web;
using System;
using System.Linq;
using System.Configuration;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;
using Twilio.TwiML;
using Twilio.AspNet.Mvc;
using Twilio.AspNet.Core;
using TwilioController = Twilio.AspNet.Core.TwilioController;

namespace CRUD_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SMSController : TwilioController
    {
        [HttpPost]
        [Route("sendSMS")]
        public ActionResult sendSMS()
        {
            string accountSid = "ACbf6323f068498bcadfbc769892a2d084";
            var authToken = "c04919e21a52eb8bae9861da5fa27afd";

            TwilioClient.Init(accountSid, authToken);

            var to = new PhoneNumber("+8801634860323");
            var from = new PhoneNumber("+12543293709");

            var message = MessageResource.Create(
                to: to,
                from: from,
                body: "Cybersecurity threat: A new malware has been discovered that can steal your personal information, including your passwords and credit card numbers.\r\n\r\nAction: Update your antivirus software and be careful about what websites you visit and what emails you open."
                );

            return Content(message.Sid);
        }
    }
}
