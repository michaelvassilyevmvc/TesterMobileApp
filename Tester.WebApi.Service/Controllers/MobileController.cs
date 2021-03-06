using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Tester.WebApi.Service.Data;
using Tester.WebApi.Service.Models;
using Tester.WebApi.Service.PushNotificationServices;
using System.Threading;
using System.Threading.Tasks;
using Tester.WebApi.Service.PushNotification;

namespace Tester.WebApi.Service.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MobileController : ControllerBase
    {
        private readonly MainDbContext _context;
        private readonly INotificationService _notificationService;

        public MobileController(MainDbContext context, INotificationService notificationService)
        {
            _context = context;
            _notificationService = notificationService;
        }

        [HttpGet]
        public ActionResult Get()
        {
            var users = _context.Users;

            if (users == null || users.Count() == 0)
            {
                return NotFound();
            }

            return Ok();
        }

        [HttpPost]
        [Route("register")]
        public ActionResult PhoneRegister(Phone phone)
        {
            var phoneList = _context.Phones.Where(x => x.Number == phone.Number).ToList();

            if(phoneList != null)
            {
                return BadRequest("Phone is exist");
            }

            _context.Phones.Add(phone);
            _context.SaveChanges();

            return Ok();
        }

        [HttpPost]
        [Route("send")]
        public async Task<IActionResult> SendNotification(User user, NotificationModel notificationModel)
        {
            if (user != null)
            {
                _context.Users.Add(user);
                _context.SaveChanges();
                long id = user.ID;
            }

            var result = await _notificationService.SendNotification(notificationModel);

            return Ok(result);
        }

    }
}
