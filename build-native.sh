#!/usr/bin/env bash
set -xe

# build libopenzwave-1.4.dylib
make -C externals/open-zwave
install_name_tool -id "libopenzwave-1.4.dylib" \
    externals/open-zwave/libopenzwave-1.4.dylib

# build libopenzwave_c.dylib
xcodebuild clean build \
    -project native/build/openzwave_c.xcodeproj \
    -target openzwave_c \
    -arch x86_64 \
    -configuration Release
cp native/build/build/Release/libopenzwave_c.dylib \
    externals/open-zwave/libopenzwave_c.dylib
install_name_tool -id "libopenzwave_c.dylib" \
    externals/open-zwave/libopenzwave_c.dylib

# build the library
(cd source && \
    msbuild /restore OpenZWave.sln)