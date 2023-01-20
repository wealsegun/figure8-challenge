using Figure8Challenge.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetsAlone.Core
{
    public class ContactService: IContactDetails
    {
        public List<ContactDetails>GetAllContact(Figure8ChallengeContext context)
        {
            return context.ContactDetails.OrderByDescending(c=>c.DateCreated).ToList();
        }

        public ContactDetails GetContactById(Figure8ChallengeContext context, long Id)
        {
            return context.ContactDetails.Where(c=>c.Id==Id).FirstOrDefault();
        }

        public int CreateContact(Figure8ChallengeContext context, ContactDetails model)
        {
            int result = 0;
            if (model == null) return result;
            model.DateCreated = DateTime.UtcNow;
            var response = context.ContactDetails.Add(model);
            context.SaveChanges();
            result = result + 1;
            return  result;
        }

        public bool UpdateContact(Figure8ChallengeContext context, ContactDetails model, long Id)
        {
            if(model==null) return false;
            var response = context.ContactDetails.Where(c=>c.Id ==Id).FirstOrDefault();
            if(response==null) return false;

            response.Name = model.Name;
            response.PhoneNumber = model.PhoneNumber;
            response.UpdatedAt = DateTime.UtcNow;

            var compe= context.ContactDetails.Update(response);
            context.SaveChanges();
            return true;
        }

        public bool DeleteContact(Figure8ChallengeContext context,long Id)
        {
            var response = context.ContactDetails.Where(c=>c.Id==Id).FirstOrDefault();
            if(null==response) return false;
            context.ContactDetails.Remove(response);
            context.SaveChanges();
            return true;
        }


    }
}
