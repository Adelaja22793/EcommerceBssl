using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EcommerceBssl.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace EcommerceBssl.Pages.Customer.Products
{
    public class GroupModel : PageModel
    {
        private readonly EcommerceBssl.Data.ApplicationDbContext _context;

        

        public GroupModel(EcommerceBssl.Data.ApplicationDbContext context)
        {
            _context = context;
        }
       
        public SubCategory SubCategory { get; set; }

        public async Task OnGetTaskAsync(int? subgroup)
        {
            if (subgroup != null)
	        {
                SubCategory = await _context.SubCategories.Include (m => m.Products).FirstOrDefaultAsync(n => n.Id == subgroup.Value);

               // return Page();
	        }
            else
            {
               // return NotFound();
            }
            //SubCategory = await _context.SubCategories.FindAsync(subgroup);

            //SubCategory = await _context.SubCategories.Include (m=>m.Products).FirstOrDefaultAsync(n=>n.subgroup);
        }
    }
}