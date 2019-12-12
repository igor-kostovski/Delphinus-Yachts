using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;
using AutoMapper;
using Delphinus_Yachts.Domain.Models;
using Delphinus_Yachts.Domain.Services;
using Delphinus_Yachts.DTOs;
using Microsoft.AspNet.Identity.Owin;

namespace Delphinus_Yachts.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        private readonly AuthenticationService _authenticationService;
        private readonly UserService _userService;
        private readonly IMapper _mapper;

        public AccountController(AuthenticationService authenticationService, IMapper mapper, UserService userService)
        {
            _authenticationService = authenticationService;
            _userService = userService;
            _mapper = mapper;
        }
        
        public ActionResult SignIn()
        {
            return View();
        }
        
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginDTO dto)
        {
            var model = _mapper.Map<LoginModel>(dto);

            var status = _authenticationService.SignIn(model);

            switch (status)
            {
                case SignInStatus.Success:
                    return RedirectToAction("Index","Mvc",new RouteValueDictionary{{"entity","Bookings"}});
                default:
                    ModelState.AddModelError("CustomError", "Invalid credentials.");
                    return View(dto);
            }
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOut()
        {
            _authenticationService.SignOut();
            return Redirect("/Account/Login");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignIn(LoginDTO dto)
        {
            var model = _mapper.Map<LoginModel>(dto);
            var result = _userService.Create(model);
            if (result.Succeeded)
                return Redirect("/Account/Login");

            var errorMessage = result.Errors.Aggregate((prev, curr) => prev + " " + curr);
            ModelState.AddModelError("CustomError", errorMessage);
            return View(dto);
        }
    }
}