using EcommerceFull.Data;
using EcommerceFull.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
namespace EcommerceFull.Controllers
{
    public class CheckOutController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly DBLayer _dbLayer;
        private readonly DBUtils _dBUtils;

        public CheckOutController(IConfiguration configuration, DBLayer dBLayer, DBUtils dBUtils)
        {
            _configuration = configuration;
            _dbLayer = dBLayer;
            _dBUtils = dBUtils;
        }

        public IActionResult Index()
        {
            int UserID = Convert.ToInt32(HttpContext.Session.GetString("UserID"));
            if (UserID == 0)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                return View();
            };
        }

        public IActionResult Sold(int userId, float Total)
        {
            string email = HttpContext.Session.GetString("Email");
            string subject = "Compra realizada com sucesso";
            string name = HttpContext.Session.GetString("isLog");
            Random random = new Random();

            int numeroAleatorio = random.Next(10000, 100000);
            string minhaString = name;
            string resultadoRandon = minhaString + numeroAleatorio;

            string message = $"<!DOCTYPE html>\r\n<html>\r\n<head>\r\n    <title>Confirmação de Compra</title>\r\n</head>\r\n<body>\r\n    <h1>Confirmação de Compra</h1>\r\n    <p>Olá {name},</p>\r\n    \r\n    <p>Obrigado por fazer a sua compra em nossa loja! Abaixo estão os detalhes da sua compra:</p>\r\n    \r\n    <table>\r\n        <thead>\r\n            <tr>\r\n                <th>RastreioID</th>\r\n                <th>Total</th>\r\n            </tr>\r\n        </thead>\r\n        <tbody>\r\n            <!-- Loop para cada item na compra -->\r\n            <tr>\r\n                <td>{resultadoRandon}</td>\r\n                <td>{Total}</td>\r\n            </tr>\r\n            <!-- Fim do loop -->\r\n        </tbody>\r\n        <tfoot>\r\n            <tr>\r\n                <th colspan=\"3\">Total da Compra:</th>\r\n                <td>{Total} EUR</td>\r\n            </tr>\r\n        </tfoot>\r\n    </table>\r\n    \r\n    <p>O pagamento no valor de {Total} EUR foi processado com sucesso.</p>\r\n    \r\n    <p>Se você tiver alguma dúvida sobre a sua compra, entre em contato conosco através do nosso suporte.</p>\r\n    \r\n    <p>Obrigado por escolher a nossa loja!</p>\r\n    \r\n    <p>Atenciosamente,</p>\r\n    <p>A Equipe da Loja</p>\r\n</body>\r\n</html>";

            bool isSold = _dbLayer.SetSold(userId);
            if (isSold)
            {
                _dBUtils.Enviar(email, subject, message, name);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Index", "CheckOut");
            }
        }



    }
}
