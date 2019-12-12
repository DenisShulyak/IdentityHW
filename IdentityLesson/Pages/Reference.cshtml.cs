using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using IdentityLesson.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace IdentityLesson.Pages
{
    [Authorize]
    public class ReferenceModel : PageModel
    {
        public ReferenceModel(ApplicationDbContext context)
        {
            this.context = context;
        }

        public ApplicationDbContext context { get; }
        public SignInManager<IdentityUser> SignInManager { get; }

        public void OnGet()
        {
            
        }
        public void OnPost(string person, string disease)
        {
            context.References.AddRange(new Models.Reference { FullName = person, Disease = disease });

            
            MailAddress from = new MailAddress("denshufly@mail.ru", "Reference");
            // кому отправляем
            MailAddress to = new MailAddress(User.Identity.Name);
            // создаем объект сообщения
            MailMessage m = new MailMessage(from, to);
            // тема письма
            m.Subject = "Справка";
            // текст письма
            m.Body = "<h2>Здраствуйте "+person+", вот ваша медецинская справка по болезне - "+disease+"</h2>";
            // письмо представляет код html
            m.IsBodyHtml = true;
            // адрес smtp-сервера и порт, с которого будем отправлять письмо
            SmtpClient smtp = new SmtpClient("smtp.mail.ru", 587);
            // логин и пароль
            smtp.Credentials = new NetworkCredential("denshufly@mail.ru", "DeNiS300402");
            smtp.EnableSsl = true;
            smtp.Send(m);

            context.SaveChanges();
        }
    }
}