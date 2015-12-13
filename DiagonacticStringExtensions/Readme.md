Diagonactic String Extensions
-----------------------------

A set of extension methods for string manipulation.  Migration from my other open source application, TheMissingMethods, with the goal
of providing a set of common string manipulation tasks that are fully unit tested.
The current solution is quite small but will be added to when I need methods I have defined in TheMissingMethods.

```c#
"Domain\\Name".RightOf("\\"); // returns "Name"
"Domain\\Name".LeftOf("\\"); // returns "Domain"
"Domain\\Name".RightOfIndex(6); // returns "Name"
"Domain\\Name".RightOfIndex(4); // returns "Domain"
int? result = "1".TryParseInt(); // returns an 1 boxed in a nullable
int intResult;
bool success = "1".TryParseInt(out intResult); // returns true with 1 in the intResult
```
