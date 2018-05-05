using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

using Twilio.TwiML;
using Twilio.AspNet.Mvc;
using System.Configuration;

namespace Online_Car_Rental_System.Controllers
{
    public class SmsNotifirController : TwilioController
    {
        [HttpGet]
        public ActionResult SendSms()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SendSms(string messag,String num)
        {
            var accountSid = "AC96cd1d884e743fb503359f0e0a028583";
            var authToken = "9435e1d47ebcd6242af34a7fbb9df3cc";
            TwilioClient.Init(accountSid, authToken);

            var mss = messag;
            String nu = num;

            var message = MessageResource.Create(
                to: new PhoneNumber(nu),
                from: new PhoneNumber("+15803707182"),
                body: mss);

            return RedirectToAction("Index", "Client");
        }
    }
}