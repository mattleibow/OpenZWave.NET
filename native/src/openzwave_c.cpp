#include "openzwave_c.h"

#include <string>

#include "Options.h"

using namespace OpenZWave;

// Options

options_t* options_create(char* configPath, char* userPath, char* commandLine) {
    return reinterpret_cast<options_t*>(Options::Create(configPath, userPath, commandLine));
}

bool options_destroy() {
    return Options::Destroy();
}

options_t* options_get() {
    return reinterpret_cast<options_t*>(Options::Get());
}

bool options_lock(options_t* o) {
    return reinterpret_cast<Options*>(o)->Lock();
}

bool options_add_option_bool(options_t* o, char* name, bool value) {
    return reinterpret_cast<Options*>(o)->AddOptionBool(name, value);
}

bool options_add_option_int(options_t* o, char* name, int value) {
    return reinterpret_cast<Options*>(o)->AddOptionInt(name, value);
}

bool options_add_option_string(options_t* o, char* name, char* value, bool append) {
    return reinterpret_cast<Options*>(o)->AddOptionString(name, value, append);
}

bool options_get_option_as_bool(options_t* o, char* name, bool* valueOut) {
    return reinterpret_cast<Options*>(o)->GetOptionAsBool(name, valueOut);
}

bool options_get_option_as_int(options_t* o, char* name, int* valueOut) {
    return reinterpret_cast<Options*>(o)->GetOptionAsInt(name, valueOut);
}

bool options_get_option_as_string(options_t* o, char* name, char* valueOut, int* len) {
    string str;
    auto result = reinterpret_cast<Options*>(o)->GetOptionAsString(name, &str);
    if (valueOut)
        strcpy(valueOut, str.c_str());
    if (len)
        *len = (int)str.length();
    return result;
}

option_type_t options_get_option_type(options_t* o, char* name) {
    return (option_type_t)reinterpret_cast<Options*>(o)->GetOptionType(name);
}

bool options_are_locked(options_t* o) {
    return reinterpret_cast<Options*>(o)->AreLocked();
}
