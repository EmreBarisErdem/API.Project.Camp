using API.Project.Camp.WebApi.Context;
using API.Project.Camp.WebApi.Dtos.ContactDtos;
using API.Project.Camp.WebApi.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Project.Camp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly ApiContext _context;

		public ContactsController(ApiContext context)
		{
			_context = context;
		}

		[HttpGet]
		public IActionResult ContactList()
		{
			var values = _context.Contacts.ToList();
			return Ok(values);
		}

		[HttpPost]
		public IActionResult CreateContact(CreateContactDto createContactDto)
		{
			Contact contact = new Contact();
			contact.Email = createContactDto.Email;
			contact.Adress = createContactDto.Adress;
			contact.Phone = createContactDto.Phone;
			contact.MapLocation = createContactDto.MapLocation;
			contact.OpenHours = createContactDto.OpenHours;

			_context.Contacts.Add(contact);
			_context.SaveChanges();

			return Ok("Ekleme işlemi başarılı");
		}

		[HttpDelete]
		public IActionResult DeleteContact(int id)
		{
			var value = _context.Contacts.Find(id);

			_context.Contacts.Remove(value);
			_context.SaveChanges();

			return Ok("Silme İşlemi Başarılı");
		}

		[HttpGet("GetContact")]
		public IActionResult GetContact(int id)
		{
			var value = _context.Contacts.Find(id);

			return Ok(value);
		}

		[HttpPut]
		public IActionResult GetContact(UpdateContactDto updateContactDto)
		{
			Contact contact = new Contact();
			contact.Email = updateContactDto.Email;
			contact.Adress = updateContactDto.Adress;
			contact.Phone = updateContactDto.Phone;
			contact.MapLocation = updateContactDto.MapLocation;
			contact.OpenHours = updateContactDto.OpenHours;
			contact.ContactId = updateContactDto.ContactId;

			_context.Contacts.Update(contact);
			_context.SaveChanges();

			return Ok("Günceleme İşlemi Başarılı");
		}

	}
}
