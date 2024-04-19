using Abstract;
using Business.DTO;
using Business.DTO.Menu;
using Entity;
using Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Business.Service
{
    public class MenuItemService : IMenuItemService
    {
        private readonly Context _context;
        public MenuItemService(Context context)
        {
            _context = context;
        }
        public List<GetMenuItemResponse> GetMenuOfTheDay(DayOfWeek dayOfWeek)
        {
            return _context.Set<MenuItem>()
                .Where(x => x.IsActive && (x.IsPermanent || x.DayOfWeek == dayOfWeek))
                    .Select(x => new GetMenuItemResponse
                    {
                        ID = x.ID,
                        Category = new CategoryResponse
                        {
                            ID = x.Category.ID,
                            Name = x.Category.Name
                        },
                        IsPermanent = x.IsPermanent,
                        IsActive = x.IsActive,
                        CreateDate = x.CreateDate,
                        Description = x.Description,
                        GlutenFree = x.GlutenFree,
                        IsVegan = x.IsVegan,
                        Name = x.Name,
                        Price = x.Price
                    }
                    ).ToList();
        }

        public void CreateMenuItem(CreateMenuItemRequest request)
        {
            if (!request.IsPermanent && !request.DayOfWeek.HasValue)
                throw new Exception("Sürekli menüde bulunmayan ürün için haftanın günü boş olamaz!");
            var menuItem = new MenuItem
            {
                CategoryID = request.CategoryID,
                IsPermanent = request.IsPermanent,
                IsActive = request.IsActive,
                CreateDate = DateTime.UtcNow,
                Description = request.Description,
                GlutenFree = request.GlutenFree,
                IsVegan = request.IsVegan,
                Name = request.Name,
                Price = request.Price,
                DayOfWeek = request.IsPermanent ? null : request.DayOfWeek
            };

            _context.Set<MenuItem>().Add(menuItem);
            _context.SaveChanges();
        }

        public void UpdateMenuItem(UpdateMenuItemRequest request)
        {
            var menuItem = _context.Set<MenuItem>().Find(request.ID);
            if (menuItem == null)
            {
                throw new Exception("Menü öğesi bulunamadı.");
            }
            menuItem.CategoryID = request.CategoryID ?? menuItem.CategoryID;
            menuItem.IsPermanent = request.IsPermanent ?? menuItem.IsPermanent;
            menuItem.IsActive = request.IsActive ?? menuItem.IsActive;
            menuItem.Description = request.Description;
            menuItem.GlutenFree = request.GlutenFree ?? menuItem.GlutenFree;
            menuItem.IsVegan = request.IsVegan ?? menuItem.IsVegan;
            menuItem.Name = request.Name ?? menuItem.Name;
            menuItem.Price = request.Price ?? menuItem.Price;

            _context.SaveChanges();
        }

        public void DeleteMenuItem(Guid id)
        {
            var menuItem = _context.Set<MenuItem>().Find(id);
            if (menuItem == null)
            {
                throw new Exception("Belirtilen menü öğesi bulunamadı.");
            }

            _context.Set<MenuItem>().Remove(menuItem);
            _context.SaveChanges();
        }
    }
}
