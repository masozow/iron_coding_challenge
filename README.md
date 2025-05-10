# iron_coding_challenge

Old phone keypad with alphabetical letters, a backspace key, and a send button

## Old Phone Pad Translator

This project is a simple translator that takes a string of numbers and converts it into a corresponding string of letters, using the old phone pad layout.

### Getting Started

To run the program, navigate to the project directory and execute the following command:

`dotnet run`

This will compile and run the program, allowing you to input a string of numbers and see the corresponding translated string of letters.

### Running Tests

To run the unit tests for this project, execute the following command:

`dotnet test`

This will run all the tests in the NumberMessage_TranslateTo_TextMessage test class, including the test cases in the OldPhonePadTestData enumerable.

### Adding More Test Cases

To add more test cases to the OldPhonePadTestData enumerable, simply add a new tuple to the list with the input string and expected output string. For example:

```
public static IEnumerable<object[]> OldPhonePadTestData => new[]
{
    new object[] { "227#", "B" },
    new object[] { "22*#", "A" },
    // Add new test case here
    new object[] { "345#", "DEF" },
};
```

Make sure to update the test case name and expected output string accordingly.

#### Note

This project uses the dotnet CLI to build and run the program, as well as to execute the unit tests. Make sure you have the .NET Core SDK installed on your machine to use this project.
