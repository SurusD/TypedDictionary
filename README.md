# TypedDictionary
A dictionary where you can put values which is mathing with type allocated for specific keys

```csharp
TypedDictionary dictionary = new TypedDictionary();
// now you can only put int to key1
dictionary.AllocateType("key1", typeof(int));
dictionary.Put("key1", 1); // correct
dictionary.Put("key1", "1"); // ArgumentException: Type of value System.String does not match allocated type System.Int32 for key key1
dictionary.Put("key2", 1); // ArgumentException: No type allocated for key key2

int gettingValue = dictionary.Get<int>("key1"); // correct
string gettingString = dictionary.Get<string>("key1"); // ArgumentException: Allocated type System.Int32 for key key1 does not match type System.String

// now getting value for key that does not exist
 gettingValue = dictionary.Get<int>("key2"); // ArgumentException: No type allocated for key key2

dictionary.DellocateType("key1"); // removes key1 and its value
// also you can get required type for specific key
System.Type type = dictionary.GetRequiredType("key1");
// check if any type allocated for specific key
bool can = dictionary.CanAssign("key1");
```
