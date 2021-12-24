# Task: *Location Search*

Note: check out the **design** folder to view the analysis and diagrams.
The solution was made as a working scalable API (you can run it using your Visual Studio).

## Structural and conceptual decisions

- Used the **Domain Driven Design (DDD)** to structure the code. Added other projects that represent **Domain**, **Application**, and **Infrastructure** layers.
- Also kept request/response models in the **CQRS** way.
- The unit tests are made that way to be **parallelizable in the test method level** (i.e. all the tests run in parallel).
- You can see the **TDD** approach by reviewing the commit history (tests first, implementation then)
- **Patterns**:
	- **Specification**: pattern used to filter the values that are retrieved from the database.
	- **Mediator**: to properly handle requests it is a good idea to add request handlers and put a mediator between these handlers and controllers. This way, we have a flexible way to handle each type of request separately with little to no pipe-wiring code.
- Added **Request validation** to validate the query's values
- Used **.csv** file as a database (constrained by time)

## NuGet packages used

**MediatR**: a mediator between controllers and handlers in code 
**Moq**: for mocking in tests
**FluentAssertions**: for asserting objects and lists in tests

## Disclaimers / Improvables
	- This is not the most efficient solution, as it reads data directly from the .csv file. A better way should be replace it with ORM and construct queries with conditions and sorting. So, we retrieve only the necessarry set of collections instead of reading all of them and then removing unnecessary ones.
	- Logging: 
		all the calls to this API (an ASP.NET Core middle ware would be a perfect candidate for that)
		the calls to the third party (or a database in this case)