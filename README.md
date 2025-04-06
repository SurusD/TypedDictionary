# TypedDictionary Class
=====================================

### Overview
-----------

The `TypedDictionary` class is a custom implementation designed to enforce type safety at runtime for key-value pairs stored in a dictionary-like structure. It ensures that each key is associated with a specific data type, preventing type mismatches when storing or retrieving values.

### Description
-------------

* **Namespace:** `surus.util`
* **Language:** C# (.NET)
* **Key Features:**
    + Type allocation for each key
    + Runtime type checking for stored values
    + Generic method for typed value retrieval
    + Methods for allocating, checking, storing, retrieving, and deallocating types and values

### Pros
--------

* **Enhanced Type Safety:** Ensures values stored under a key match the allocated type, reducing runtime type errors.
* **Explicitness:** Forces developers to declare the type of data a key will hold, improving code clarity and maintainability.
* **Flexibility:** Supports dynamic allocation and deallocation of types for keys, accommodating changing requirements.
* **Strongly Typed Retrieval:** Generic `Get` method allows for retrieval of values in their native type, eliminating the need for explicit casting.

### Cons
--------

* **Additional Overhead:** Requires explicit type allocation for each key, which might seem cumbersome for simple use cases.
* **Runtime Checks:** While enhancing safety, these checks occur at runtime; careful planning is still necessary to avoid exceptions.
* **Limited Support for Inheritance/Polymorphism:** Currently, the class does not natively support storing derived types under a base type key, which might limit its use in more complex object-oriented scenarios.
