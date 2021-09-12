A ReferenceToggle is used when a field should support both an inline object or a library object to be used.

If an object is used only once, then by unchecking useReference the details of the object can be entered directly.

If the same object is used in multiple places, then it is more convenient to create a library object inheriting from ScriptableObject for it and reference this object. 
Reference\<T> is essentially a wrapper around T that allows any object to be stored in the library by creating an empty subclass. For example:
```c#
[CreateAssetMenu(menuName="References/String")]
public class StringReference : Reference<string>
{}
```
Once a reference object has been created, checking useReference in a ReferenceToggle will allow the reference object to be selected.

A ReferenceToggle has a single property, Object, that allows the object to be used without the consumer needing to know whether a reference or direct object was used.
There is also an implicit conversion operator, allowing ReferenceObject\<T> to be treated as type T.

Usage:
```c#
[SerializeField] private ReferenceToggle<string> name;
...
Debug.Log(name.Object); // property
string T = name; // implicit conversion
```

DANGER: Objects inheriting from ScriptableObject can be overwritten. Need to be very careful about writing to an object extracted from a reference toggle.
Ideally in the future ReferenceToggle could include some protection for this like cloning. But for now, References should be to immutable objects only.