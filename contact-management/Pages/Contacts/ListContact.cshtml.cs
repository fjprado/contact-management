using contact_management.Data;
using contact_management.Models.Domain;
using contact_management.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
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

        public IActionResult OnPostDelete(Guid id)
        {
            var existingContact = _dbContext.Contacts.Find(id);
            if (existingContact != null)
            {
                _dbContext.Contacts.Remove(existingContact);
                _dbContext.SaveChanges();
            }

            return RedirectToPage("/Contacts/ListContact");
        }
    }
}
