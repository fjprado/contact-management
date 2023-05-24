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

            if(contact != null)
            {
                EditContactViewModel = new EditContactViewModel()
                {
                    ID = contact.ID,
                    Name = contact.Name,
                    Phone = contact.Phone,
                    Email = contact.Email
                };
            }
        }

        public void OnPost()
        {
            if(EditContactViewModel != null)
            {
                var existingContact = _dbContext.Contacts.Find(EditContactViewModel.ID);
                if(existingContact != null)
                {
                    existingContact.ID = EditContactViewModel.ID;
                    existingContact.Name = EditContactViewModel.Name;
                    existingContact.Phone = EditContactViewModel.Phone;
                    existingContact.Email = EditContactViewModel.Email;

                    _dbContext.SaveChanges();

                    ViewData["ContactEdited"] = "Contact has been edited successfully!";
                }                
            }            
        }
    }
}
