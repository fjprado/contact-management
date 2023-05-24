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

        public void OnPost()
        {
            var contactModel = new Contact
            {
                Name = AddContactViewModel.Name,
                Phone = AddContactViewModel.Phone,
                Email = AddContactViewModel.Email
            };

            _dbContext.Contacts.Add(contactModel);
            _dbContext.SaveChanges();
        }
    }
}
