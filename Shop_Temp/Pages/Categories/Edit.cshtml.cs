using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopRazor_Temp.Data;
using ShopRazor_Temp.Models;

namespace ShopRazor_Temp.Pages.Categories
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public Category category { get; set; }
        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet(int? id)
        {
            if (id != null || id!=0)
            {
                category = _db.Categories.Find(id);
            }
        }

        public IActionResult OnPost(Category category)
        {
            if (ModelState.IsValid)
            {
                _db.Categories.Update(category);
                _db.SaveChanges();
                TempData["success"] = "Category updated successfilly";
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
