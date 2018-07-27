# OpenZWave .NET

## Building

There are currently 2 ways to generate a binding:
 1. using CppSharp
 2. using a new C library

### Using CppSharp

This one is quick to generate, but I need to investigate why the generation is not working properly.

To build, run:

```
sh build-cppsharp.sh
```

###

This one is working, because I wrote it the way I wanted it to, but there is only the `Options` type.

To build, run:

```
sh build-native.sh
```
