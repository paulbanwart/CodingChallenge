Part 1

For your convenience, I added an export of my postman collection to test the api/encode endpoint, if you don't already have one. It can be found under Postman/LightFeather.postman_collection.json. Run this solution in Visual Studio ideally. Then test the endpoint with different Shift and Message combinations. Successfully encoded messages are saved to /EncodedMessages. You may need to setup files permission to save to disk.


Part 2

This is an ASP.NET Core MVC project. Due to the limitations of the framework, I could not make the client-side validation work with a disabled submit button without create a custom validation obj, which is outside the scope of my time allocation for this assessment. It does perform all client-side validation before making a request to the server even if you hit the submit button before having a valid form.
