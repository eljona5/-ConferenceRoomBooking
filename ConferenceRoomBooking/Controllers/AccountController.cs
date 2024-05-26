//using Microsoft.AspNetCore.Authentication.Cookies;
//using Microsoft.AspNetCore.Authentication.JwtBearer;
//using Microsoft.AspNetCore.Authentication;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.IdentityModel.Tokens;
//using ConferenceRoomBooking.DataLayer.DBContext;
//using ConferenceRoomBooking.DataLayer.Entities;
//using ConferenceRoomBooking.Models;
//using System.IdentityModel.Tokens.Jwt;
//using System.Security.Claims;
//using System.Text;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.AspNetCore.Authorization;
//using System.Data;
//using ConferenceRoomBooking.DataLayer.Entities;
//using ConferenceRoomBooking.Models;
//namespace ConferenceRoomBooking.Controllers
//{
//    public class AccountController : Controller
//    {
//        private readonly ConferenceRoomBookingContext _context;
//        //Identity
//        private readonly UserManager<User> _userManager;
//        private readonly RoleManager<IdentityRole> _roleManager;
//        private readonly SignInManager<User> _signManager;
//        private readonly IConfiguration _config;
//        private readonly IHttpContextAccessor _httpContextAccessor;
//        public AccountController(ConferenceRoomBookingContext context,
//           UserManager<User> userManager,
//           RoleManager<IdentityRole> roleManager,
//           IHttpContextAccessor httpContextAccessor,
//           SignInManager<User> signManager,
//           IConfiguration configuration)
//        {
//            context = context;
//            _userManager = userManager;
//            _roleManager = roleManager;
//            _httpContextAccessor = httpContextAccessor;
//            _signManager = signManager;
//            _config = configuration;
//        }
//        //public IActionResult Index()
//        //{
//        //    return View();
//        //}
//        public async Task<IActionResult> Index(string filterTerm)
//        {
//            var users = _context.Users
//        .Where(p => (p.IsDeleted == false || p.IsDeleted == null))
//        .OrderBy(p => p.Name)
//        .ToList();
//            var userModels = new List<UserModel>();
//            foreach (var user in users)
//            {
//                var userModel = new UserModel()
//                {
//                    Id = user.Id,
//                    Name = user.Name,
//                    Email = user.Email,
//                    Surname = user.Surname,
//                    IsDeleted = user.IsDeleted,
//                    // IsAdmin = user.IsAdmin,
//                    //  PhoneNumber = user.PhoneNumber,
//                    // UserName = user.UserName,
//                    // CreatedDate = user.CreatedDate,
//                    //  Roles = new List<string>()
//                };
//            //    var roles = await _userManager.GetRolesAsync(user);
//            //    foreach (var role in roles)
//            //    {
//            //        userModel.Roles.Add(role);
//            //    }
//            //    userModels.Add(userModel);
//            //}
//            //if (!string.IsNullOrEmpty(filterTerm))
//            //{
//            //    userModels = userModels.Where(p => p.FullName.Contains(filterTerm))
//            //                      .ToList();
//            //}
//            return View(userModels);
//        }
//        public IActionResult Details(string id)
//        {
//            var user = _context.Users
//                .Where(p => p.Id == id)
//                .FirstOrDefault();

//            return View(user);
//        }

//        //public async Task<IActionResult> MyProfile()
//        //{
//        //    try
//        //    {
//        //        var sessionIdentity = User.Identity;
//        //        //check if user is authenticated
//        //        if (sessionIdentity.IsAuthenticated == false)
//        //        {

//        //            return RedirectToAction("LogIn");
//        //        }
//        //        var userID = User.Claims.Where(p => p.Type == ClaimTypes.Email).FirstOrDefault().Value;
//        //        var user = await _userManager.FindByEmailAsync(userID);
//        //        if (user == null)
//        //        {
//        //            throw new Exception("User not found");
//        //        }
//        //        var UserProfileModel = new UserProfileModel()
//        //        {
//        //            FullName = user.FullName,
//        //            Email = user.FullName,
//        //            IsAdmin = user.IsAdmin.HasValue && user.IsAdmin.Value == true ? "Yes" : "No",
//        //            Phone = user.PhoneNumber,
//        //            PhotoPath = user.PhotoPath
//        //        };
//        //        return View(UserProfileModel);
//        //    }
//        //    catch (Exception ex)
//        //    {
//        //        ViewBag.ErrorMessage = "Error in logging in. Check you credentials";
//        //        return View();
//        //    }
//        //}
//        public IActionResult Register()
//        {
//            return View();
//        }
//        [HttpPost, ActionName("Register")]
//        public async Task<IActionResult> Register([Bind("FirstName", "LastName", "Email", "Password", "Phone")] AccountRegisterModel accountRegisterModel)
//        {
//            try
//            {
//                if (await _userManager.FindByEmailAsync(accountRegisterModel.Email) != null)
//                {
//                    throw new Exception("User with exists with this email");
//                }
//                var user = new User()
//                {
//                    FullName = accountRegisterModel.FirstName + " " + accountRegisterModel.LastName,
//                    Email = accountRegisterModel.Email,
//                    NormalizedEmail = accountRegisterModel.Email,
//                    EmailConfirmed = true,
//                    PhoneNumber = accountRegisterModel.Phone,
//                    UserName = accountRegisterModel.FirstName[0] + accountRegisterModel.LastName,
//                };
//                var result = await _userManager.CreateAsync(user, accountRegisterModel.Password);
//                if (!result.Succeeded)
//                {
//                    throw new Exception(result.Errors.ToString());
//                }
//                var viewrRoleID = _context.Roles.Where(p => p.Name == "Viewr")
//                                                               .FirstOrDefault().Id;
//                _context.UserRoles.Add(new IdentityUserRole<string>()
//                {
//                    RoleId = viewrRoleID,
//                    UserId = user.Id
//                });
//                var userProfileModel = new UserProfileModel()
//                {
//                    FullName = user.FullName,
//                    Email = user.FullName,
//                    IsAdmin = user.IsAdmin.HasValue && user.IsAdmin.Value == true ? "Yes" : "No",
//                    Phone = user.PhoneNumber,
//                    PhotoPath = user.PhotoPath
//                };
//                return View("MyProfile", userProfileModel);
//            }
//            catch (Exception ex)
//            {
//                ViewBag.ErrorMessage = "Error in logging in. Check you credentials";
//                return View();
//            }

//        }

//        public async Task<IActionResult> Login()
//        {
//            return View();
//        }

//        [HttpPost, ActionName("LogIn")]
//        public async Task<IActionResult> LogIn([Bind("Email", "Password")] LogInModel logInModel)
//        {
//            try
//            {
//                var user = await _userManager.FindByEmailAsync(logInModel.Email);
//                if (user != null && await _userManager.CheckPasswordAsync(user, logInModel.Password))
//                {
//                    var userRoles = await _userManager.GetRolesAsync(user);
//                    var authClaims = new List<Claim>
//            {
//                new Claim(ClaimTypes.Name, user.UserName),
//                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
//            };
//                    foreach (var userRole in userRoles)
//                    {
//                        authClaims.Add(new Claim(ClaimTypes.Role, userRole));
//                    }

//                    authClaims.Add(new Claim(ClaimTypes.PrimarySid, user.Id));
//                    var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["SecretKey"]));//Secret key
//                    var token = new JwtSecurityToken(
//                        issuer: _config["Issuer"], //Your App URL
//                        audience: _config["Audience"], //Your App URL
//                        expires: DateTime.Now.AddDays(3),
//                        claims: authClaims,
//                        signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
//                        );

//                    authClaims.Add(new Claim("token", token.Payload.ToString()));
//                    ClaimsIdentity claimsIdentity = new ClaimsIdentity(authClaims, JwtBearerDefaults.AuthenticationScheme);
//                    AuthenticationProperties properties = new AuthenticationProperties()
//                    {
//                        AllowRefresh = true,
//                        IsPersistent = true
//                    };


//                    //Sign in on the session
//                    await _signManager.SignInAsync(user, true);

//                    //check if user is authenticated
//                    if (_context.UserLogins.Where(p => p.UserId == user.Id).FirstOrDefault() == null)
//                    {
//                        await _context.UserLogins.AddAsync(new IdentityUserLogin<string>()
//                        {
//                            LoginProvider = "Simple Web Application Log in",
//                            ProviderDisplayName = "Application Log in",
//                            UserId = user.Id,
//                            ProviderKey = "User Password",
//                        });
//                        await _context.SaveChangesAsync();
//                    }


//                    var userProfileModel = new UserProfileModel()
//                    {
//                        FullName = user.FullName,
//                        Email = user.FullName,
//                        IsAdmin = user.IsAdmin.HasValue && user.IsAdmin.Value == true ? "Yes" : "No",
//                        Phone = user.PhoneNumber,
//                        PhotoPath = user.PhotoPath
//                    };
//                    return View("MyProfile", userProfileModel);
//                }
//                else
//                {
//                    return RedirectToAction("LogIn");
//                }
//            }
//            catch (Exception ex)
//            {
//                ViewBag.ErrorMessage = "Error in logging in. Check you credentials";
//                return View();
//            }
//        }

//        [HttpPost, ActionName("LogOut")]
//        public async Task<IActionResult> LogOut()
//        {
//            try
//            {
//                if (User.Identity.IsAuthenticated)
//                {
//                    await _signManager.SignOutAsync();
//                }
//                return View("LogIn");
//            }
//            catch (Exception ex)
//            {
//                ViewBag.ErrorMessage = "Error in logging in. Check you credentials";
//                return View();
//            }
//        }

//        [Authorize(Roles = "Admin")]
//        public async Task<IActionResult> UpdateUserRole(string id)
//        {
//            try
//            {
//                var user = await _userManager.FindByIdAsync(id);
//                if (user == null)
//                {
//                    throw new Exception("User not found");
//                }
//                var userRoleDisplayModel = new UserRoleDisplayModel()
//                {
//                    FullName = user.FullName,
//                    Role = (await _userManager.GetRolesAsync(user)).FirstOrDefault(),
//                    Roles = _context.Roles.ToList()
//                };
//                return View(userRoleDisplayModel);
//            }
//            catch (Exception ex)
//            {
//                ViewBag.ErrorMessage = $"{ex.Message}";
//                return View();
//            }
//        }

//        [Authorize(Roles = "Admin")]
//        [HttpPost, ActionName("UpdateUserRole")]
//        public async Task<IActionResult> UpdateUserRole([Bind("FullName", "Role")] UserRoleDisplayModel userRolUpdateModel)
//        {
//            try
//            {
//                var user = _context.Users.Where(p => p.FullName.Contains(userRolUpdateModel.FullName))
//                    .FirstOrDefault();
//                if (user == null)
//                {
//                    throw new Exception("User not found");
//                }
//                // Get logged user
//                var loggedUserEmail = User.Claims.Where(p => p.Type == ClaimTypes.Email).FirstOrDefault().Value;
//                var loggedUser = await _userManager.FindByEmailAsync(loggedUserEmail);
//                if (loggedUser != null && loggedUser.Email == user.Email)
//                {
//                    throw new Exception("You cannnot edit your own access role");
//                }
//                var role = _context.Roles.Where(p => p.Id == userRolUpdateModel.Role)
//                    .FirstOrDefault();
//                if (role == null)
//                {
//                    throw new Exception("Role not found");
//                }
//                var userRole = _context.UserRoles.Where(p => p.UserId == user.Id).FirstOrDefault();
//                _context.UserRoles.Remove(userRole);
//                _context.UserRoles.Add(new IdentityUserRole<string>()
//                {
//                    RoleId = role.Id,
//                    UserId = user.Id
//                });
//                _context.SaveChanges();
//                var userRoleDisplayModel = new UserRoleDisplayModel()
//                {
//                    FullName = user.FullName,
//                    Role = (await _userManager.GetRolesAsync(user)).FirstOrDefault(),
//                    Roles = _context.Roles.ToList()
//                };
//                return View("UpdateUserRole", userRoleDisplayModel);
//            }
//            catch (Exception ex)
//            {
//                ViewBag.ErrorMessage = $"{ex.Message}";
//                return View();
//            }
//        }
//    }
//}