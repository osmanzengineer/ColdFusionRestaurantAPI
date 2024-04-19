using Business.DTO.Menu;
using System;
using System.Collections.Generic;

namespace Abstract
{
    public interface IMenuItemService
    {
        List<GetMenuItemResponse> GetMenuOfTheDay(DayOfWeek dayOfWeek);
        void CreateMenuItem(CreateMenuItemRequest request);
        void UpdateMenuItem(UpdateMenuItemRequest request);
        void DeleteMenuItem(Guid id);
    }
}
