using BidOneAssessment.Core;
using BidOneAssessment.Core.Domain.Marketing.Events;
using BidOneAssessment.Core.Events;
using System;

namespace BidOneAssessment.Domain
{
    public class Contact : DomainEntity, IAggregateRoot
    {
        protected Contact () { }

        public Contact(Guid id, string fname, string lname, string email)
        {
            this.Id = id;
            this.FirstName = fname;
            this.LastName = lname;
            this.Email = email;
            this.Status = ContactStatus.Lead;

            this.AddDomainEvent(new ContactCreated(Id, FirstName, LastName, Email));
        }

        public void Update(string fname, string lname, string email)
        {
            this.FirstName = fname;
            this.LastName = lname;
            this.Email = email;

            this.AddDomainEvent(new ContactUpdated(Id, FirstName, LastName, Email));
        }

        public void UpdateStatus(ContactStatus status)
        {
            if (status == ContactStatus.RegisteredMember && this.Status != ContactStatus.Lead)
            {
                // throw domain exception : to be marked as registered member, the contact has to be a lead
            }
            if (status == ContactStatus.PastMember && this.Status != ContactStatus.RegisteredMember)
            {
                // throw domain exception : not a registered member
            }

            this.Status = status;

            this.AddDomainEvent(new ContactStatusUpdated(Id, Status));
        }

        public void Unsubscribe()
        {
            if (!InterestedInCommunications)
            {
                // throw domain exception: already unsubscribed for communications
            }
            this.InterestedInCommunications = false;
            this.AddDomainEvent(new ContactUnsubscribed(Id));
        }

        public void Subscribe()
        {
            if (InterestedInCommunications)
            {
                // throw domain exception: already subscribed for communications
            }
            this.InterestedInCommunications = true;
            this.AddDomainEvent(new ContactSubscribed(Id));
        }

        public string FirstName { get; protected set; }
        public string LastName { get; protected set; }
        public string Email { get; protected set; }

        public ContactStatus Status { get; protected set; }
        public bool InterestedInCommunications { get; protected set; }
    }
}
