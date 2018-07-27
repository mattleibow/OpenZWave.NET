#include <stddef.h>
#include <stdint.h>
#include <stdbool.h>

#include "Options.h"
#include "Manager.h"
#include "Driver.h"
#include "platform/Log.h"

using namespace OpenZWave;

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

#ifdef __cplusplus
extern "C" {
#endif


// types

typedef struct options_t options_t;
typedef struct manager_t manager_t;
typedef struct notification_t notification_t;

typedef void (*on_ontification_delegate_t)(notification_t* notification, void* _context);


// enums

typedef enum {
    OPTION_TYPE_INVALID = Options::OptionType::OptionType_Invalid,
    OPTION_TYPE_BOOL = Options::OptionType::OptionType_Bool,
    OPTION_TYPE_INT = Options::OptionType::OptionType_Int,
    OPTION_TYPE_STRING = Options::OptionType::OptionType_String,
} option_type_t;

typedef enum {
    LOG_LEVEL_INVALID = LogLevel::LogLevel_Invalid,
    LOG_LEVEL_NONE = LogLevel::LogLevel_None,
    LOG_LEVEL_ALWAYS = LogLevel::LogLevel_Always,
    LOG_LEVEL_FATAL = LogLevel::LogLevel_Fatal,
    LOG_LEVEL_ERROR = LogLevel::LogLevel_Error,
    LOG_LEVEL_WARNING = LogLevel::LogLevel_Warning,
    LOG_LEVEL_ALERT = LogLevel::LogLevel_Alert,
    LOG_LEVEL_INFO = LogLevel::LogLevel_Info,
    LOG_LEVEL_DETAIL = LogLevel::LogLevel_Detail,
    LOG_LEVEL_DEBUG = LogLevel::LogLevel_Debug,
    LOG_LEVEL_STREAM_DETAIL = LogLevel::LogLevel_StreamDetail,
    LOG_LEVEL_INTERNAL = LogLevel::LogLevel_Internal,
} log_level_t;

typedef enum {
    DRIVER_CONTROLLER_INTERFACE_UNKNOWN = Driver::ControllerInterface::ControllerInterface_Unknown,
    DRIVER_CONTROLLER_INTERFACE_SERIAL = Driver::ControllerInterface::ControllerInterface_Serial,
    DRIVER_CONTROLLER_INTERFACE_HID = Driver::ControllerInterface::ControllerInterface_Hid,
} driver_controller_interface_t;


// Options

EXPORT options_t* options_create(char* configPath, char* userPath, char* commandLine) {
    return reinterpret_cast<options_t*>(Options::Create(configPath, userPath, commandLine));
}

EXPORT bool options_destroy() {
    return Options::Destroy();
}

EXPORT options_t* options_get() {
    return reinterpret_cast<options_t*>(Options::Get());
}

EXPORT bool options_lock(options_t* o) {
    return reinterpret_cast<Options*>(o)->Lock();
}

EXPORT bool options_add_option_bool(options_t* o, char* name, bool value) {
    return reinterpret_cast<Options*>(o)->AddOptionBool(name, value);
}

EXPORT bool options_add_option_int(options_t* o, char* name, int value) {
    return reinterpret_cast<Options*>(o)->AddOptionInt(name, value);
}

EXPORT bool options_add_option_string(options_t* o, char* name, char* value, bool append) {
    return reinterpret_cast<Options*>(o)->AddOptionString(name, value, append);
}

EXPORT bool options_get_option_as_bool(options_t* o, char* name, bool* valueOut) {
    return reinterpret_cast<Options*>(o)->GetOptionAsBool(name, valueOut);
}

EXPORT bool options_get_option_as_int(options_t* o, char* name, int* valueOut) {
    return reinterpret_cast<Options*>(o)->GetOptionAsInt(name, valueOut);
}

EXPORT bool options_get_option_as_string(options_t* o, char* name, char* valueOut, int* len) {
    string str;
    auto result = reinterpret_cast<Options*>(o)->GetOptionAsString(name, &str);
    if (valueOut)
        strcpy(valueOut, str.c_str());
    if (len)
        *len = (int)str.length();
    return result;
}

EXPORT option_type_t options_get_option_type(options_t* o, char* name) {
    return (option_type_t)reinterpret_cast<Options*>(o)->GetOptionType(name);
}

EXPORT bool options_are_locked(options_t* o) {
    return reinterpret_cast<Options*>(o)->AreLocked();
}


// Manager

EXPORT manager_t* manager_create() {
    return reinterpret_cast<manager_t*>(Manager::Create());
}

EXPORT manager_t* manager_get() {
    return reinterpret_cast<manager_t*>(Manager::Get());
}

EXPORT void manager_destroy() {
    Manager::Destroy();
}

EXPORT int manager_get_version_as_string(char* versionOut) {
    string str = Manager::getVersionAsString();
    if (versionOut)
        strcpy(versionOut, str.c_str());
    return (int)str.length();
}

EXPORT int manager_get_version_long_as_string(char* versionOut) {
    string str = Manager::getVersionLongAsString();
    if (versionOut)
        strcpy(versionOut, str.c_str());
    return (int)str.length();
}

EXPORT void manager_write_config(manager_t* m, uint homeId) {
    reinterpret_cast<Manager*>(m)->WriteConfig(homeId);
}

EXPORT options_t* manager_get_options(manager_t* m) {
    return reinterpret_cast<options_t*>(reinterpret_cast<Manager*>(m)->GetOptions());
}

EXPORT bool manager_add_watcher(manager_t* m, on_ontification_delegate_t watcher, void* context) {
    return reinterpret_cast<Manager*>(m)->AddWatcher((Manager::pfnOnNotification_t)watcher, context);
}

EXPORT bool manager_remove_watcher(manager_t* m, on_ontification_delegate_t watcher, void* context) {
    return reinterpret_cast<Manager*>(m)->RemoveWatcher((Manager::pfnOnNotification_t)watcher, context);
}

EXPORT bool manager_add_driver(manager_t* m, char* controllerPath, driver_controller_interface_t controllerInterface) {
    return reinterpret_cast<Manager*>(m)->AddDriver(controllerPath, (Driver::ControllerInterface)controllerInterface);
}

EXPORT bool manager_remove_driver(manager_t* m, char* controllerPath) {
    return reinterpret_cast<Manager*>(m)->RemoveDriver(controllerPath);
}

EXPORT unsigned char manager_get_controller_node_id(manager_t* m, uint homeId) {
    return reinterpret_cast<Manager*>(m)->GetControllerNodeId(homeId);
}

EXPORT unsigned char manager_get_static_update_controller_node_id(manager_t* m, uint homeId) {
    return reinterpret_cast<Manager*>(m)->GetSUCNodeId(homeId);
}

EXPORT bool manager_is_primary_controller(manager_t* m, uint homeId) {
    return reinterpret_cast<Manager*>(m)->IsPrimaryController(homeId);
}

EXPORT bool manager_is_static_update_controller(manager_t* m, uint homeId) {
    return reinterpret_cast<Manager*>(m)->IsStaticUpdateController(homeId);
}

EXPORT bool manager_is_bridge_controller(manager_t* m, uint homeId) {
    return reinterpret_cast<Manager*>(m)->IsBridgeController(homeId);
}

EXPORT int manager_get_library_version(manager_t* m, uint homeId, char* versionOut) {
    string str = reinterpret_cast<Manager*>(m)->GetLibraryVersion(homeId);
    if (versionOut)
        strcpy(versionOut, str.c_str());
    return (int)str.length();
}

EXPORT int manager_get_library_type_name(manager_t* m, uint homeId, char* versionOut) {
    string str = reinterpret_cast<Manager*>(m)->GetLibraryTypeName(homeId);
    if (versionOut)
        strcpy(versionOut, str.c_str());
    return (int)str.length();
}

EXPORT int manager_get_send_queue_count(manager_t* m, uint homeId) {
    return reinterpret_cast<Manager*>(m)->GetSendQueueCount(homeId);
}

EXPORT void manager_log_driver_statistics(manager_t* m, uint homeId) {
    reinterpret_cast<Manager*>(m)->LogDriverStatistics(homeId);
}

EXPORT driver_controller_interface_t manager_get_controller_interface_type(manager_t* m, uint homeId) {
    return (driver_controller_interface_t)reinterpret_cast<Manager*>(m)->GetControllerInterfaceType(homeId);
}

EXPORT int manager_get_controller_path(manager_t* m, uint homeId, char* pathOut) {
    string str = reinterpret_cast<Manager*>(m)->GetControllerPath(homeId);
    if (pathOut)
        strcpy(pathOut, str.c_str());
    return (int)str.length();
}

#ifdef __cplusplus
}
#endif
