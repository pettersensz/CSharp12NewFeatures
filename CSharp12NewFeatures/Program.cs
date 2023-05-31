// See https://aka.ms/new-console-template for more information

// Setup
// - Visual Studio Preview 2022 17.6
// - .Net 8.0 SDK (8.0.100-preview.4)
// - .csproj file has preview language features enabled

using CSharp12NewFeatures;
using System.Collections.Frozen;
using System.Collections.Immutable;
// Any type can now be aliased, including tuples
using ThreeDimensionalPoint = (int x, int y, int z);

Console.WriteLine("Here's an example of a Primary Constructor:");

var theThing = new Something("The Thing", 5);

Console.WriteLine($"{theThing.Name} is {theThing.LengthInFeet} feet long.\n");

Console.WriteLine("Now we use the explicit constructor with default values:");

var defaultThing = new Something();

Console.WriteLine($"{defaultThing.Name} is {defaultThing.LengthInFeet} feet long.\n");

// Stick a breakpoint here to see the class properties in debugger
var cm = theThing.GetLengthInCentiMeters();


Console.WriteLine("--------------------------------------------------------------------------");
Console.WriteLine("Here's an example of a lambda expression with default parameters:\n");

var Subtract = (int valueBefore, int subtractWith = 1) => valueBefore - subtractWith;

Console.WriteLine("100 - 1: " + Subtract(100));
Console.WriteLine("100 - 3: " + Subtract(100, 3));

Console.WriteLine("--------------------------------------------------------------------------");
Console.WriteLine("Here's an example of a using alias on a Tuple, which was not previously allowed:\n");

var point = new ThreeDimensionalPoint(4, 6, 8);
Console.WriteLine($"Coordinates: x = {point.x}, y = {point.y}, z = {point.z}");


Console.WriteLine("--------------------------------------------------------------------------");

var dictionary = new Dictionary<int, ThreeDimensionalPoint>();
var random = new Random();
for (var i = 0; i < 10; i++)
{
  dictionary.Add(i, new ThreeDimensionalPoint(random.Next(0, 999), random.Next(0, 999), random.Next(0, 999)));
}

// We now have a new type FrozenDictionary. The intention is to create it once and get items often
// Optimized for lookup, faster than the existing types (but creation is expensive)
var frozenDict = FrozenDictionary.ToFrozenDictionary(dictionary);

// Earlier we had immutableDictionary, but it still allows adding/removing
// Actually it creates a new copy if we add or remove
var immutableDict = ImmutableDictionary.ToImmutableDictionary(dictionary);

// We also already have ReadOnlyDict. It does not allow adding removing, but the underlying data can still be changed
var readOnlyDict = dictionary.AsReadOnly();

Console.WriteLine("Fresh start:");
Console.WriteLine($"Dictionary       : {dictionary.Count}");
Console.WriteLine($"Immutable        : {immutableDict.Count}");
Console.WriteLine($"Read only        : {readOnlyDict.Count}");
Console.WriteLine($"Frozen           : {frozenDict.Count}");
Console.WriteLine("Add one to underlying dictionary:");
dictionary.Add(64, (6, 5, 4));
Console.WriteLine($"Dictionary       : {dictionary.Count}");
Console.WriteLine($"Immutable        : {immutableDict.Count}");
Console.WriteLine($"Read only        : {readOnlyDict.Count}");
Console.WriteLine($"Frozen           : {frozenDict.Count}");

Console.WriteLine("Add to immutable dictionary:");
var updated = immutableDict.Add(56, (5, 4, 6));
Console.WriteLine($"Old immutable    : {immutableDict.Count}");
Console.WriteLine($"Updated Immutable: {updated.Count}");


