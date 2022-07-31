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
            string accountSid = "";
            var authToken = "";

            TwilioClient.Init(accountSid, authToken);

            var to = new PhoneNumber("+8801634860323");
            var from = new PhoneNumber("+15189193142");

            var message = MessageResource.Create(
                to: to,
                from: from,
                body: "This is just a SMS test"
                );

            return Content(message.Sid);
        }
    }
}
