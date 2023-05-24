using contact_management.Data;
using contact_management.Models.Domain;
using contact_management.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Numerics;
using System.Xml.Linq;

namespace contact_management.Pages.Contacts
{
    public class EditContactModel : PageModel
    {
        private readonly ContactManagementDbContext _dbContext;
        [BindProperty]
        public EditContactViewModel EditContactViewModel { get; set; }

        public EditContactModel(ContactManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void OnGet(Guid id)
        {
            var contact = _dbContext.Contacts.Find(id);

            if (contact != null)
            {
                EditContactViewModel = new EditContactViewModel()
                {
                    ID = contact.ID,
                    Name = contact.Name,
                    Phone = contact.Phone,
                    Email = contact.Email,
                    Active = contact.Active
                };
            }
        }

        public IActionResult OnPostUpdate()
        {
            if (_dbContext.Contacts
               .Where(x => (x.Phone == EditContactViewModel.Phone || x.Email == EditContactViewModel.Email) && x.ID != EditContactViewModel.ID)
               .Any())
            {
                ViewData["ContactDuplicated"] = "A contact with same contact and/or email address already exists!";
            }
            else
            {
                if (EditContactViewModel != null)
                {
                    var existingContact = _dbContext.Contacts.Find(EditContactViewModel.ID);
                    if (existingContact != null)
                    {
                        existingContact.ID = EditContactViewModel.ID;
                        existingContact.Name = EditContactViewModel.Name;
                        existingContact.Phone = EditContactViewModel.Phone;
                        existingContact.Email = EditContactViewModel.Email;
                        existingContact.Active = EditContactViewModel.Active;

                        _dbContext.SaveChanges();

                        ViewData["ContactEdited"] = "Contact has been edited successfully!";
                    }
                }
            }

            return Page();
        }

        public IActionResult OnPostDelete()
        {
            if (EditContactViewModel != null)
            {
                var existingContact = _dbContext.Contacts.Find(EditContactViewModel.ID);
                if (existingContact != null)
                {
                    existingContact.Active = false;
                    _dbContext.SaveChanges();

                    return RedirectToPage("/Contacts/ListContact");
                }
            }

            return Page();
        }
    }
}
