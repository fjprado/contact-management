using contact_management.Data;
using contact_management.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace contact_management.Pages.Contacts
{
    public class ViewContactModel : PageModel
    {
        private readonly ContactManagementDbContext _dbContext;
        [BindProperty]
        public EditContactViewModel ContactViewModel { get; set; }

        public ViewContactModel(ContactManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void OnGet(Guid id)
        {
            var contact = _dbContext.Contacts.Find(id);

            if (contact != null)
            {
                ContactViewModel = new EditContactViewModel()
                {
                    ID = contact.ID,
                    Name = contact.Name,
                    Phone = contact.Phone,
                    Email = contact.Email
                };
            }
        }
    }
}
