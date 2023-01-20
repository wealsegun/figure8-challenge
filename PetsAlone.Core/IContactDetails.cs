using PetsAlone.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Figure8Challenge.Core
{
    public interface IContactDetails
    {
        List<ContactDetails> GetAllContact(Figure8ChallengeContext context);
        ContactDetails GetContactById(Figure8ChallengeContext context, long Id);
        int CreateContact(Figure8ChallengeContext context, ContactDetails model);
        bool UpdateContact(Figure8ChallengeContext context, ContactDetails model, long Id);
        bool DeleteContact(Figure8ChallengeContext context, long Id);
    }
}
