using InformCPISolution.Data;
using InformCPISolution.Domain.Contacts.Services;
using InformCPISolution.Domain.Dto;
using Microsoft.AspNetCore.Mvc;
using ILogger = Serilog.ILogger;

namespace InformCPISolution.Controllers
{
    [Controller]
    public class HomeController : Controller
    {
        private readonly IContactServices Services;
        private readonly ILogger Logger;

        public HomeController(IContactServices services, ILogger logger)
        {
            Services = services;
            Logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult> Index()
        {
            try
            {
                var contact = await Services.GetContacts();

                return View(contact);
            }
            catch (Exception e)
            {
                Logger.Error("Faield to get contact list");
            }

            return View(); 
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("/{id}")]
        public async Task<ActionResult> Contact(int id)
        {
            if(id > 0)
            {
                try
                {
                    var contact = await Services.GetContact(id);

                    return View(contact);
                }
                catch (Exception e)
                {
                    Logger.Error($"Error retrieving contact: {id}, {e}");
                }
            }

            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        [HttpGet]
        [Route("/CreateContact")]
        public async Task<ActionResult> CreateContact(ContactDto? dto)
        {
            if (dto.Name != null)
            {
                try
                {
                    var m = new ContactDto
                    {
                        Name = dto.Name,
                        Email = dto.Email,
                        PhoneNumber = dto.PhoneNumber
                    };

                    await Services.AddContact(m);

                    return RedirectToAction("Index");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }  
                return View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpGet]
        [HttpPost]
        [Route("/Home/Edit/{id?}")]
        public async Task<ActionResult> EditContact(ContactDto? dto)
        {
            if (dto.Name != null)
            {
                try
                {
                    var d = new ContactDto
                    {
                        Name = dto.Name,
                        Email = dto.Email,
                        PhoneNumber = dto.PhoneNumber
                    };

                    await Services.AddContact(d);

                    return RedirectToAction("Index");
                }
                catch (Exception e)
                {
                    Logger.Error($"Error editing contact: {e}");
                }
            }
            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("/Home/Delete/{id?}")]
        public async Task<ActionResult> DeleteContact(int id)
        {
            if(id > 0)
            {
                try
                {
                    await Services.DeleteContact(id);

                    return RedirectToAction("Index");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }

            return RedirectToAction("Index");
        }
    }
}
