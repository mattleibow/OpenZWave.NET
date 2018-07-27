
#ifndef OPENZWAVE_C_H
#define OPENZWAVE_C_H

#include <stddef.h>
#include <stdint.h>
#include <stdbool.h>

//

#if defined(OPENZWAVE_C_DLL)
    #if defined(_MSC_VER)
        #if OPENZWAVE_C_IMPLEMENTATION
            #define EXPORT __declspec(dllexport)
        #else
            #define EXPORT __declspec(dllimport)
        #endif
    #else
        #define EXPORT __attribute__((visibility("default")))
    #endif
#else
    #define EXPORT
#endif

//

#ifdef __cplusplus
extern "C" {
#endif

// Options

typedef struct options_t options_t;

typedef enum {
    OPTION_TYPE_INVALID = 0,
    OPTION_TYPE_BOOL,
    OPTION_TYPE_INT,
    OPTION_TYPE_STRING,
} option_type_t;

EXPORT options_t* options_create(char* configPath, char* userPath, char* commandLine);
EXPORT bool options_destroy(void);
EXPORT options_t* options_get(void);
EXPORT bool options_lock(options_t* o);
EXPORT bool options_add_option_bool(options_t* o, char* name, bool value);
EXPORT bool options_add_option_int(options_t* o, char* name, int value);
EXPORT bool options_add_option_string(options_t* o, char* name, char* value, bool append);
EXPORT bool options_get_option_as_bool(options_t* o, char* name, bool* valueOut);
EXPORT bool options_get_option_as_int(options_t* o, char* name, int* valueOut);
EXPORT bool options_get_option_as_string(options_t* o, char* name, char* valueOut, int* len);
EXPORT option_type_t options_get_option_type(options_t* o, char* name);
EXPORT bool options_are_locked(options_t* o);

#ifdef __cplusplus
}
#endif

#endif // OPENZWAVE_C_H
