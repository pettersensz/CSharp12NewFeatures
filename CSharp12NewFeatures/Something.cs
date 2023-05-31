namespace CSharp12NewFeatures
{

  public class OldSomething
  {
    public string Name;
    public double LengthInFeet;
    public OldSomething(string name, double lengthInMeters) 
    {
      Name = name;
      LengthInFeet = Math.Round(lengthInMeters / 0.3048, 2); ;
    }
  }
  // Example of Primary Constructor, class takes input parameters in the same way a function would
  // This means we can assign variables directly in the class definition
  public class Something(string name, double lengthInMeters, bool unusedBool = false)
  {
    public string Name => name;
    public double LengthInFeet => Math.Round(lengthInMeters / 0.3048, 2);

    // We can still use explicit constructors, but need to use the this keyword to ensure primary constructor 
    public Something() : this("Default Thing", 3) { }

    // https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/instance-constructors#primary-constructors


    public void ShowUseOfBool()
    {
      // If this line is commented, the instance will not have this property even if it is defined in Primary Constructor (because it's not used)
      // If line is uncommented, we can see it in the debugger
      unusedBool = true;
    }

    // The class instance still has the properties from the Primary Constructor even though they are not stored as public properties.
    public double GetLengthInCentiMeters() => lengthInMeters * 100;

  }
}
