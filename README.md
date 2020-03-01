Part 1

For your convenience, I added an export of my postman collection to test the api/encode endpoint, if you don't already have one. It can be found under Postman/LightFeather.postman_collection.json. Run this solution in Visual Studio ideally. Then test the endpoint with different Shift and Message combinations. Successfully encoded messages are saved to /EncodedMessages/EncodedMessages.txt. You may need to modify file permissions to save to disk, but that most likely will not be an issue.


Part 2

This is an ASP.NET Core MVC project. Due to the limitations of the framework, I could not make the client-side validation work with a disabled submit button without creating a custom validation obj, which is outside the scope of a basic coding assessment. It does perform all client-side validation before making a request to the server even if you hit the submit button before having a valid form. The only difference is that the button does not appear in a disabled state at any point.
