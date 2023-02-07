# C#

CSharp is a "Classical Object Oriented Programming Language"

    - Classical here means "Class Based" (not like Mozart or something).

This means we build application by thinking about _types_. we define types and coding types

## 2/7/2023:

Every bit of Code must be a part of a Type:

Value Types:

- Definied by a struct\*
- They "live" on the stack
- Memory is managed automatically - cleaned up when the variable goes out of scope.

Reference Types:

- defined as classes\*
- They "live" on the heap (specifically, the "managed" heap)
- Memory is managed automatically, but non-deterministically using an algorithm called "generational garbage collection"

C# is a statically typed lanaguage.
Variables cannot change their type. "If a variable is born as an integer, it will die an integer"
