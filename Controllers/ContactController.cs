using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ContactApi.Models;
using ContactApi.Data;
using Microsoft.EntityFrameworkCore;

namespace ContactApi.Controllers
{
    [ApiController]
    [Route("api/contact")]
    public class ContactController : ControllerBase
    {
        private readonly ContactDbContext _context;
        private readonly string _staticFolderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads");
        public ContactController(ContactDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("contact")]
        public async Task<IActionResult> Create(Contact contact)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                contact.CreatedDate = DateTime.Now;
                contact.DeletedDate = DateTime.Now;
                contact.IsActive = true;
                contact.IsContacted = false;
                contact.CreatedBy = 1;
                _context.Contacts.Add(contact);
                await _context.SaveChangesAsync();

                return Ok(new { message = "Message sent successfully!" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Failed to send message", error = ex.Message });
            }
        }

        

        [HttpPost]
        [Route("upload")]
        public async Task<IActionResult> UploadFile([FromForm] IFormFile file)
        {


            if (file == null || file.Length == 0)
            {
                return BadRequest("No file selected");
            }

            // Create folder if not exists
            if (!Directory.Exists(_staticFolderPath))
            {
                Directory.CreateDirectory(_staticFolderPath);
            }

            // Build file path
            var filePath = Path.Combine(_staticFolderPath, file.FileName);

            // Save the file
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return Ok(new { filePath });
        }

        [HttpPost]
        [Route("saveApplication")]
        public async Task<IActionResult> SaveApplication(Applications applications)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                applications.CreatedDate = DateTime.Now;
                applications.DeletedDate = DateTime.Now;

                applications.IsActive = true;
                applications.IsContacted = false;
                applications.CreatedBy = 1;
                _context.Applications.Add(applications);
                await _context.SaveChangesAsync();

                //// for fetchinf message
                //var contactList = await _context.ReposneMessage
                //.Where(cm => cm.IsActive == true && cm.DisplayOrder == contactMessge.orderCount)
                //.ToListAsync();
                //string Message = "";
                //if (contactList.Count > 0)
                //{
                //    Message = contactList[0].Message;
                //}


                return Ok(new { message = "Application save successfully!" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Failed to send message", error = ex.Message });
            }
        }

        [HttpPost]
        [Route("SaveContactMessage")]
        public async Task<IActionResult> SaveContactMessage(ContactMessge contactMessge)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                contactMessge.CreatedDate = DateTime.Now;
                contactMessge.DeletedDate = DateTime.Now;

                contactMessge.IsActive = true;
                contactMessge.IsContacted = false;
                contactMessge.CreatedBy = 1;
                _context.ContactMessge.Add(contactMessge);
                await _context.SaveChangesAsync();

                // for fetchinf message
                var contactList = await _context.ReposneMessage
                .Where(cm => cm.IsActive == true && cm.DisplayOrder == contactMessge.orderCount)
                .ToListAsync();
                string Message = "";
                if (contactList.Count > 0)
                {
                    Message = contactList[0].Message;
                }


                return Ok(new { message = Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Failed to send message", error = ex.Message });
            }
        }
    }
}