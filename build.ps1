$ErrorActionPreference = 'Stop'

$vswhere = 'C:\Program Files (x86)\Microsoft Visual Studio\Installer\vswhere.exe'

$vs = & "$vswhere" -requires Microsoft.Component.MSBuild -latest -property installationPath
$msbuild = "$vs\MSBuild\15.0\Bin\MSBuild.exe"

# build openzwave_c.dll
& $msbuild native/build/win32/openzwave_c.sln /p:Configuration=Release /p:Platform=Win32
& $msbuild native/build/win32/openzwave_c.sln /p:Configuration=Release /p:Platform=x64

# build the library
& $msbuild /restore source/OpenZWave.sln

exit $LASTEXITCODE
