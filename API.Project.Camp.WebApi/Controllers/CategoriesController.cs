using API.Project.Camp.WebApi.Context;
using API.Project.Camp.WebApi.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace API.Project.Camp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ApiContext _context;

		public CategoriesController(ApiContext context)
		{
			_context = context;
		}

		[HttpPost]
		public async Task<IActionResult> CreateCategoryAsync(Category category)
		{
			//After Validations
			_context.Categories.Add(category);
			await _context.SaveChangesAsync();
			return Ok("Kategori eklendi!");
		}

		[HttpGet]
		public async Task<IActionResult> CategoryList()
		{
			var values = await _context.Categories.ToListAsync();
			return Ok(values);
		}

		[HttpDelete]
		public async Task<IActionResult> DeleteCategoryAsync(int id)
		{
			Category? value = await _context.Categories.FindAsync(id);

			_context.Categories.Remove(value);
			await _context.SaveChangesAsync();
			return Ok("Kategoris silme işlemi başarılı!");
		}

		[HttpGet("GetCategory")]
		public async Task<IActionResult> GetCategory(int id)
		{
			Category? value = await _context.Categories.FindAsync(id);

			return Ok(value);

		}

		[HttpPut]
		public async Task<IActionResult> UpdateCategoryAsync(Category category)
		{
			_context.Categories.Update(category);
			await _context.SaveChangesAsync();
			return Ok("Kategori güncelleme başarılı!");

		}

	}
}
