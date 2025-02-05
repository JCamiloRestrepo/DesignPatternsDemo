# Singleton Pattern

## Description
The Singleton pattern ensures that a class has only one instance and provides a global access point to it.

## Implementation
- A private static variable to hold the single instance.
- A private constructor to prevent external instantiation.
- A public static method to return the unique instance.

## Example Code (C#)
```csharp
var instance1 = Singleton.GetInstance();
var instance2 = Singleton.GetInstance();
Console.WriteLine(instance1 == instance2 ? "Same instance" : "Different instances");