using contact_management.Data;
using contact_management.Models.Domain;
using contact_management.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace contact_management.Pages.Contacts
{
    public class AddContactModel : PageModel
    {
        private readonly ContactManagementDbContext _dbContext;

        public AddContactModel(ContactManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [BindProperty]
        public AddContactViewModel AddContactViewModel { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if(_dbContext.Contacts
                .Where(x => x.Phone == AddContactViewModel.Phone || x.Email == AddContactViewModel.Email)
                .Any())
            {
                ViewData["ContactDuplicated"] = "A contact with same contact and/or email address already exists!";
                return Page();
            }

            var contactModel = new Contact
            {
                Name = AddContactViewModel.Name,
                Phone = AddContactViewModel.Phone,
                Email = AddContactViewModel.Email,
                Active = true
            };

            _dbContext.Contacts.Add(contactModel);
            _dbContext.SaveChanges();

            return RedirectToPage("/Contacts/ListContact");
        }
    }
}
