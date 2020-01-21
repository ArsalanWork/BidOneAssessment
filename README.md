# BidOneAssessment
The technical assessment from BidOne for the recruitment process. Assumed a hypothetical bounded context of marketing team which saves contacts for marketing and promotions. For better targetted emails, they keep track of contact's status (whether a lead, registered member or past member). They also have functionality to subscribe and unsubscribe emails.

Utilized SOLID principles, CQRS, Onion Architecture, Domian Driven Design, Event-Driven Architecture. Currently the data storage is RDBMS using mysql but in the future it can replaced with an event sourced database with only changing the infrastructure layer.

Due to the time limitation, i skipped unit and integration tests.

Avoided front-end all together and kept the focus of the test to the architecture, design and development of the backend. 


