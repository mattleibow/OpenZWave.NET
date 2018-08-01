# OpenZWave .NET

OpenZWave .NET is a lightweight binding around the OpenZWave library which
is designed to control Z-Wave Networks via a USB Z-Wave Controller.

## Building

### macOS
```sh
./build.sh
```

### Windows
```ps
.\build.ps1
```

## To Do

 * Most of the API is bound, but there are a few members that need to be
   implemented. For these, there are a bunch of `// TODO: MethodNameHere`
   comments in the .c source file.
 * Add a Linux build
 * Get some sort of CI building this
 * Upstream our changes (ie: see if we can get our C API merged into 
   `open-zwave` master)
 * A few more tests
 * A nice sample app
