using Entities_POJO;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreAPI
{
    public class EmailManager
    {
        private readonly string apiKey = "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";

        public async Task Send(Email email)
        {
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("ACME@ucenfotec.org", "ACME Application");
            var to = new EmailAddress(email.Mail, email.Name_1 + " " + email.Last_Name_1);
            var subject = "Confirmación de cuenta";
            var content = email.Name_1 + " " + email.Last_Name_1 + " " + "Este su codigo de verificacion:" + email.Code + " " + "Link de la aplicación" + " " + "http://localhost:52014/";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, content, null);
            var response = await client.SendEmailAsync(msg);
            var ll = response.StatusCode.ToString();
            Console.WriteLine("enviado");
        }

        //public async Task Send(SellerStore seller)
        //{
        //    var client = new SendGridClient(apiKey);
        //    var from = new EmailAddress("ACME@ucenfotec.org", "ACME Application");
        //    var to = new EmailAddress(seller.Email);
        //    var subject = "Confirmación de cuenta";
        //    var content = seller.Name_1 + " " + seller.Last_Name_1 + " " + "Link para iniciar sesión: http://localhost:52014/";
        //    var msg = MailHelper.CreateSingleEmail(from, to, subject, content, null);
        //    var response = await client.SendEmailAsync(msg);
        //    var ll = response.StatusCode.ToString();
        //}

    }
}
