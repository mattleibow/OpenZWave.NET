#!/usr/bin/env bash

# build libopenzwave.dylib
if [ ! -f externals/open-zwave/libopenzwave.dylib ]; then
    (cd externals/CppSharp/build && \
        ./premake5-osx --file=scripts/LLVM.lua download_llvm && \
        ./Compile.sh)

    (cd externals/open-zwave && \
        git apply ../../native/open-zwave.patch)

    make -C externals/open-zwave
fi

# build and run the generator
(cd source && \
    msbuild Generator/Generator.csproj
    mono Generator/bin/Debug/net47/Generator.exe)

# build the library
(cd source && \
    msbuild OpenZWave_CppSharp.sln)