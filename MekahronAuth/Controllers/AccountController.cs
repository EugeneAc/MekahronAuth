using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using MekahronAuth.Models;

namespace MekahronAuth.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private IICUTech.ICUTechClient _iCuTechClient;

        public AccountController()
        {
            _iCuTechClient = new IICUTech.ICUTechClient();
        }

        //
        // GET: /Account/Login
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        //
        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var response = _iCuTechClient.Login(model.Username, model.Password, String.Empty);
            var successResult = Newtonsoft.Json.JsonConvert.DeserializeObject<SuccessLoginModel>(response);
            var badResult = Newtonsoft.Json.JsonConvert.DeserializeObject<BadLoginModel>(response);

            var retModel = new LoginResultModel();
            retModel.SuccessLoginModel = successResult;
            retModel.BadLoginModel = badResult;
            return PartialView("_LoginResult", retModel);
        }

        //
        // GET: /Account/Register
        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        //
        // POST: /Account/Register
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            var result = new JsonResult();
            if (ModelState.IsValid)
            {
                result.Data = _iCuTechClient.RegisterNewCustomer(model.Email, model.Password, model.Username, model.Username, model.Mobile, 0, 0, "localhost");
                
            }
            return result;
        }
    }
}