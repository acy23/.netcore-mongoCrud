using menu_api.Models;
using menu_api.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace menu_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuItemController : ControllerBase
    {
        private readonly MenuItemService _menuService;

        public MenuItemController(MenuItemService menuService)
        {
            _menuService = menuService;
        }

        [HttpGet]
        public async Task<List<MenuItem>> Get()
        {
            return await _menuService.GetAsync();
        }

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<MenuItem>> Get(string id)
        {
            var item = await _menuService.GetAsync(id);

            if (item is null)
            {
                return NotFound();
            }

            return item;
        }

        [HttpPost]
        public async Task<IActionResult> Post(MenuItem newBook)
        {
            try
            {
                await _menuService.CreateAsync(newBook);

            }
            catch(Exception ex)
            {
                return Forbid("Forbidden...");
            }
            return NoContent();
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, MenuItem updatedBook)
        {
            var item = await _menuService.GetAsync(id);

            if (item is null)
            {
                return NotFound();
            }

            updatedBook.Id = item.Id;

            await _menuService.UpdateAsync(id, updatedBook);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var item = await _menuService.GetAsync(id);

            if (item is null)
            {
                return NotFound();
            }

            await _menuService.RemoveAsync(id);

            return NoContent();
        }
    }
}
