﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using WebProgramlamaProje.Models;

namespace WebProgramlamaProje.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHtmlLocalizer<HomeController> _localizer;
        public HomeController(ILogger<HomeController> logger, IHtmlLocalizer<HomeController> localizer)
        {
            _logger = logger;
            _localizer = localizer;
        }

        
        public IActionResult Index()
        {
            var test = _localizer["Hoşgeldiniz"];
            ViewData["Hoşgeldiniz"] = test;
            return View();
        }

        [HttpPost]
        public IActionResult CultureManagment(string culture, string returnUrl)
        {
            Response.Cookies.Append(CookieRequestCultureProvider.DefaultCookieName, CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.Now.AddDays(30) });

            return LocalRedirect(returnUrl);
        }

        public IActionResult Email()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult Email(Email model)
        {
            MailMessage mailim = new MailMessage();
            mailim.To.Add("info.Berberim@gmail.com");
            mailim.From = new MailAddress("info.Berberim@gmail.com");
            mailim.Subject = "Berberim.com Info'dan mesajınız var. " + model.Baslik;
            mailim.Body = "Sayın yetkili, " + model.Ad + model.Soyad + "kişisinden gelen mesajınız şu şekilde: <br>" + model.Icerik;
            mailim.IsBodyHtml = true;

            SmtpClient smtp = new SmtpClient();
            smtp.Credentials = new NetworkCredential("info.Berberim@gmail.com", "berberiminfo123");
            smtp.Port = 587;
            smtp.Host = "smpt.gmail.com";
            smtp.EnableSsl = true;

            try
            {
                smtp.Send(mailim);
                TempData["Message"] = "Mesajınız başarılı bir şekilde iletilmiştir.";
            }
            catch(Exception e)
            {
                TempData["Message"] = "Mesaj gönderilemedi. Hata nedeni: " + e.Message;
            }
            
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
