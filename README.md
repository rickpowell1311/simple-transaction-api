### Simple transaction API ###

A simple API designed to save, update, delete and fetch transactions

### Prerequisites ###

* Visual studio 2017
    - solution runs on dot net core
    - solution uses C# v7

### Quickstart ###

* Using git, clone this repository
* Open the .sln file in Visual Studio and build the solution. Nuget packages should be restored on build
* To run, set the SimpleTransactions.Api project to be the Startup project, and begin debugging

### Time spent... ###

About 4 hours.

### Would have been nice to... ###

* Extend merchant to be an entity on its own, capturing more information than just a name
* Add an API exception filter to return an exception JSON result, rather than redirect to developer exception page.
* Implement a true 'PUT' to update a transaction (e.g. only update the fields that are specified in the request body)
