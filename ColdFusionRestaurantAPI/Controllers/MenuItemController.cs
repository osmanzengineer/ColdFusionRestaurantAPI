using Abstract;
using Business.DTO.Menu;
using Microsoft.AspNetCore.Mvc;

namespace ColdFusionRestaurantAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuItemController : ControllerBase
    {
        private readonly IMenuItemService _menuItemService;
        public MenuItemController(IMenuItemService menuItemService)
        {
           _menuItemService = menuItemService;
        }
        [HttpGet]
        public ActionResult<List<GetMenuItemResponse>> GetMenuItem([FromQuery]DayOfWeek dayOfWeek)
        {
            return Ok(_menuItemService.GetMenuOfTheDay(dayOfWeek));    
        }

        [HttpPost("CreateMenuItem")]
        public IActionResult CreateMenuItem(CreateMenuItemRequest createMenuItemRequest)
        {
            try
            {
                _menuItemService.CreateMenuItem(createMenuItemRequest);
                return Ok("Menü öğesi başarıyla oluşturuldu!");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Menü öğesi oluşturulurken bir hata oluştu: " + ex.Message);
            }
        }

        [HttpPost("UpdateMenuItem")]
        public IActionResult UpdateMenuItem(UpdateMenuItemRequest updateMenuItemRequest)
        {
            try
            {
                _menuItemService.UpdateMenuItem(updateMenuItemRequest);
                return Ok("Menü öğesi başarıyla güncellendi!");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Menü öğesi güncellenirken bir hata oluştu: " + ex.Message);
            }
        }

        [HttpPost("DeleteMenuItem/{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _menuItemService.DeleteMenuItem(id);
                return Ok("Menü öğesi başarıyla silindi!");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Menü öğesi silinirken bir hata oluştu: " + ex.Message);
            }
        }
    }
}
