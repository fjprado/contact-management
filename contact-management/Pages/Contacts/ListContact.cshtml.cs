using contact_management.Data;
using contact_management.Models.Domain;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace contact_management.Pages.Contacts
{
    public class ListContactModel : PageModel
    {
        private readonly ContactManagementDbContext _dbContext;
        public List<Contact> Contacts { get; set; }

        public ListContactModel(ContactManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void OnGet()
        {
            Contacts = _dbContext.Contacts.ToList();
        }
    }
}
