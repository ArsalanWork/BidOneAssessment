# BidOneAssessment

## Description
- This is a solution for technical assessment from BidOne for the recruitment process. Assumed a hypothetical bounded context of marketing team which saves contacts for marketing and promotions. For better targetted emails, they keep track of contact's status (whether a lead, registered member or past member). They also have functionality to subscribe and unsubscribe emails.

- Utilized SOLID principles, CQRS, Onion Architecture, Domian Driven Design, Event-Driven Architecture. Currently the data storage is RDBMS using mysql but in the future it can replaced with an event sourced database with only changing the infrastructure layer.

- Due to the time limitation, i skipped unit and integration tests.

- Avoided front-end all together and kept the focus of the test to the architecture, design and development of the backend. 

## Running Locally

**Prerequisites in Windows Environment:**
- Docker on Windows
- Git Bash
- Visual Studio 2017/19 OR Visual Studio Code. An IDE is only required for code viewing and editing. The compilation and execution is all containerized using docker-compose.

**Steps for running locally:**
- Open Command Promt or Git Bash at the solution directory.
- To build the docker images: `docker-compose build`
- To run the appliction in containers,: `docker-compose up`
- To stop the running application: `CTRL + C''
- When application is successfully running, the following urls could be attempted:
(https://localhost:8091/api/contacts&&pageSize=[default is 10]&&pageNum=[default is 1])
- To remove containers: `docker-compose down -v`

## Expected Issues:
- The application throws few mysql connection errors when starting. It is an expected behavior. The API starts attempting connection with mySQL when mySQL container is ready but not yet ready for connections. There's retry policy in place so the API eventually gets a successful connection when mySQL is ready for connections. If no successful connection is made for a 1 minute, please report as that will be an unexpected behavior.
- The API container is setup to forward its localport 80 to your machine port 8091. If port 8091 is already in use, you may receive a relevant error. You can simply define some other available port in `docker.compose.yml` file in the solution directory.
- If you face any other errors, please reach out for help on the following contact details.


