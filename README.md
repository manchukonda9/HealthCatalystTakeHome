# health-catalyst-test

**People Search Application**

*Business Requirements*
- The application accepts search input in a text box and then displays in a
    pleasing style a list of people where any part of their first or last name
	matches what was typed in the search box (displaying at least name, address,
	age, interests, and a picture). 
- Solution should either seed data or provide a way to enter new users or both
- Simulate search being slow and have the UI gracefully handle the delay

*Technical Requirements*
- An ASP.NET MVC Application 
- Use Ajax to respond to search request (no full page refresh) using JSON for
    both the request and the response
- Use Entity Framework Code First to talk to the database
- Unit Tests for appropriate parts of the application

*Tooling*
- .NET Core
- Moq
- MSTest
- Visual Studio 2017 Community Edition

*Key Packages*
- Microsoft.AspNetCore
- Microsoft.EntityFrameworkCore

*Screenshot*
![People Search Application][appscreenshot]

[appscreenshot]: https://github.com/SushiGuy/health-catalyst-test/blob/master/PeopleSearch/PeopleSearchScreenshot.PNG?raw=true "Web App Screenshot"
