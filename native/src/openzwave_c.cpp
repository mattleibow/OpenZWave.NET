#include <stddef.h>
#include <stdint.h>
#include <stdbool.h>

#include "Options.h"
#include "Manager.h"
#include "Notification.h"
#include "value_classes/ValueID.h"
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


//==============================================================================
// TYPES
//=============================================================================

typedef struct options_t options_t;
typedef struct manager_t manager_t;
typedef struct notification_t notification_t;
typedef struct value_id_t value_id_t;

typedef void (*on_ontification_delegate_t)(notification_t* notification, void* _context);


//==============================================================================
// ENUMS
//==============================================================================

typedef enum {
    OPTION_TYPE_INVALID   = Options::OptionType::OptionType_Invalid,
    OPTION_TYPE_BOOL      = Options::OptionType::OptionType_Bool,
    OPTION_TYPE_INT       = Options::OptionType::OptionType_Int,
    OPTION_TYPE_STRING    = Options::OptionType::OptionType_String,
} option_type_t;

typedef enum {
    LOG_LEVEL_INVALID         = LogLevel::LogLevel_Invalid,
    LOG_LEVEL_NONE            = LogLevel::LogLevel_None,
    LOG_LEVEL_ALWAYS          = LogLevel::LogLevel_Always,
    LOG_LEVEL_FATAL           = LogLevel::LogLevel_Fatal,
    LOG_LEVEL_ERROR           = LogLevel::LogLevel_Error,
    LOG_LEVEL_WARNING         = LogLevel::LogLevel_Warning,
    LOG_LEVEL_ALERT           = LogLevel::LogLevel_Alert,
    LOG_LEVEL_INFO            = LogLevel::LogLevel_Info,
    LOG_LEVEL_DETAIL          = LogLevel::LogLevel_Detail,
    LOG_LEVEL_DEBUG           = LogLevel::LogLevel_Debug,
    LOG_LEVEL_STREAM_DETAIL   = LogLevel::LogLevel_StreamDetail,
    LOG_LEVEL_INTERNAL        = LogLevel::LogLevel_Internal,
} log_level_t;

typedef enum {
    DRIVER_CONTROLLER_INTERFACE_UNKNOWN   = Driver::ControllerInterface::ControllerInterface_Unknown,
    DRIVER_CONTROLLER_INTERFACE_SERIAL    = Driver::ControllerInterface::ControllerInterface_Serial,
    DRIVER_CONTROLLER_INTERFACE_HID       = Driver::ControllerInterface::ControllerInterface_Hid,
} driver_controller_interface_t;

typedef enum {
    NOTIFICATION_TYPE_VALUE_ADDED                     = Notification::NotificationType::Type_ValueAdded,
    NOTIFICATION_TYPE_VALUE_REMOVED                   = Notification::NotificationType::Type_ValueRemoved,
    NOTIFICATION_TYPE_VALUE_CHANGED                   = Notification::NotificationType::Type_ValueChanged,
    NOTIFICATION_TYPE_VALUE_REFRESHED                 = Notification::NotificationType::Type_ValueRefreshed,
    NOTIFICATION_TYPE_GROUP                           = Notification::NotificationType::Type_Group,
    NOTIFICATION_TYPE_NODE_NEW                        = Notification::NotificationType::Type_NodeNew,
    NOTIFICATION_TYPE_NODE_ADDED                      = Notification::NotificationType::Type_NodeAdded,
    NOTIFICATION_TYPE_NODE_REMOVED                    = Notification::NotificationType::Type_NodeRemoved,
    NOTIFICATION_TYPE_NODE_PROTOCOLINFO               = Notification::NotificationType::Type_NodeProtocolInfo,
    NOTIFICATION_TYPE_NODE_NAMING                     = Notification::NotificationType::Type_NodeNaming,
    NOTIFICATION_TYPE_NODE_EVENT                      = Notification::NotificationType::Type_NodeEvent,
    NOTIFICATION_TYPE_POLLING_DISABLED                = Notification::NotificationType::Type_PollingDisabled,
    NOTIFICATION_TYPE_POLLING_ENABLED                 = Notification::NotificationType::Type_PollingEnabled,
    NOTIFICATION_TYPE_SCENE_EVENT                     = Notification::NotificationType::Type_SceneEvent,
    NOTIFICATION_TYPE_CREATE_BUTTON                   = Notification::NotificationType::Type_CreateButton,
    NOTIFICATION_TYPE_DELETE_BUTTON                   = Notification::NotificationType::Type_DeleteButton,
    NOTIFICATION_TYPE_BUTTON_ON                       = Notification::NotificationType::Type_ButtonOn,
    NOTIFICATION_TYPE_BUTTON_OFF                      = Notification::NotificationType::Type_ButtonOff,
    NOTIFICATION_TYPE_DRIVER_READY                    = Notification::NotificationType::Type_DriverReady,
    NOTIFICATION_TYPE_DRIVER_FAILED                   = Notification::NotificationType::Type_DriverFailed,
    NOTIFICATION_TYPE_DRIVER_RESET                    = Notification::NotificationType::Type_DriverReset,
    NOTIFICATION_TYPE_ESSENTIAL_NODE_QUERIES_COMPLETE = Notification::NotificationType::Type_EssentialNodeQueriesComplete,
    NOTIFICATION_TYPE_NODE_QUERIES_COMPLETE           = Notification::NotificationType::Type_NodeQueriesComplete,
    NOTIFICATION_TYPE_AWAKE_NODES_QUERIED             = Notification::NotificationType::Type_AwakeNodesQueried,
    NOTIFICATION_TYPE_ALL_NODES_QUERIED_SOME_DEAD     = Notification::NotificationType::Type_AllNodesQueriedSomeDead,
    NOTIFICATION_TYPE_ALL_NODES_QUERIED               = Notification::NotificationType::Type_AllNodesQueried,
    NOTIFICATION_TYPE_NOTIFICATION                    = Notification::NotificationType::Type_Notification,
    NOTIFICATION_TYPE_DRIVER_REMOVED                  = Notification::NotificationType::Type_DriverRemoved,
    NOTIFICATION_TYPE_CONTROLLER_COMMAND              = Notification::NotificationType::Type_ControllerCommand,
    NOTIFICATION_TYPE_NODE_RESET                      = Notification::NotificationType::Type_NodeReset,
} notification_type_t;

typedef enum {
    NOTIFICATION_CODE_MSG_COMPLETE  = Notification::NotificationCode::Code_MsgComplete,
    NOTIFICATION_CODE_TIMEOUT       = Notification::NotificationCode::Code_Timeout,
    NOTIFICATION_CODE_NO_OPERATION  = Notification::NotificationCode::Code_NoOperation,
    NOTIFICATION_CODE_AWAKE         = Notification::NotificationCode::Code_Awake,
    NOTIFICATION_CODE_SLEEP         = Notification::NotificationCode::Code_Sleep,
    NOTIFICATION_CODE_DEAD          = Notification::NotificationCode::Code_Dead,
    NOTIFICATION_CODE_ALIVE         = Notification::NotificationCode::Code_Alive,
} notification_code_t;

typedef enum {
    VALUE_GENRE_BASIC   = ValueID::ValueGenre::ValueGenre_Basic,
    VALUE_GENRE_USER    = ValueID::ValueGenre::ValueGenre_User,
    VALUE_GENRE_CONFIG  = ValueID::ValueGenre::ValueGenre_Config,
    VALUE_GENRE_SYSTEM  = ValueID::ValueGenre::ValueGenre_System,
    VALUE_GENRE_COUNT   = ValueID::ValueGenre::ValueGenre_Count,
} value_genre_t;

typedef enum {
    VALUE_ID_VALUE_TYPE_BOOL       = ValueID::ValueType::ValueType_Bool,
    VALUE_ID_VALUE_TYPE_BYTE       = ValueID::ValueType::ValueType_Byte,
    VALUE_ID_VALUE_TYPE_DECIMAL    = ValueID::ValueType::ValueType_Decimal,
    VALUE_ID_VALUE_TYPE_INT        = ValueID::ValueType::ValueType_Int,
    VALUE_ID_VALUE_TYPE_LIST       = ValueID::ValueType::ValueType_List,
    VALUE_ID_VALUE_TYPE_SCHEDULE   = ValueID::ValueType::ValueType_Schedule,
    VALUE_ID_VALUE_TYPE_SHORT      = ValueID::ValueType::ValueType_Short,
    VALUE_ID_VALUE_TYPE_STRING     = ValueID::ValueType::ValueType_String,
    VALUE_ID_VALUE_TYPE_BUTTON     = ValueID::ValueType::ValueType_Button,
    VALUE_ID_VALUE_TYPE_RAW        = ValueID::ValueType::ValueType_Raw,
} value_id_value_type_t;


//==============================================================================
// OPTIONS
//==============================================================================

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

EXPORT bool options_add_option_int(options_t* o, char* name, int32_t value) {
    return reinterpret_cast<Options*>(o)->AddOptionInt(name, value);
}

EXPORT bool options_add_option_string(options_t* o, char* name, char* value, bool append) {
    return reinterpret_cast<Options*>(o)->AddOptionString(name, value, append);
}

EXPORT bool options_get_option_as_bool(options_t* o, char* name, bool* valueOut) {
    return reinterpret_cast<Options*>(o)->GetOptionAsBool(name, valueOut);
}

EXPORT bool options_get_option_as_int(options_t* o, char* name, int32_t* valueOut) {
    return reinterpret_cast<Options*>(o)->GetOptionAsInt(name, valueOut);
}

EXPORT bool options_get_option_as_string(options_t* o, char* name, char* valueOut, int32_t* len) {
    string str;
    auto result = reinterpret_cast<Options*>(o)->GetOptionAsString(name, &str);
    if (valueOut)
        strcpy(valueOut, str.c_str());
    if (len)
        *len = (int32_t)str.length();
    return result;
}

EXPORT option_type_t options_get_option_type(options_t* o, char* name) {
    return (option_type_t)reinterpret_cast<Options*>(o)->GetOptionType(name);
}

EXPORT bool options_are_locked(options_t* o) {
    return reinterpret_cast<Options*>(o)->AreLocked();
}


//==============================================================================
// NOTIFICATION
//==============================================================================

EXPORT notification_type_t notification_get_type(notification_t* n) {
    return (notification_type_t)reinterpret_cast<Notification*>(n)->GetType();
}

EXPORT uint32_t notification_get_home_id(notification_t* n) {
    return reinterpret_cast<Notification*>(n)->GetHomeId();
}

EXPORT uint8_t notification_get_node_id(notification_t* n) {
    return reinterpret_cast<Notification*>(n)->GetNodeId();
}

EXPORT const value_id_t* notification_get_value_id(notification_t* n) {
    const ValueID& vid = reinterpret_cast<Notification*>(n)->GetValueID();
    return reinterpret_cast<const value_id_t*>(&vid);
}

EXPORT uint8_t notification_get_group_index(notification_t* n) {
    return reinterpret_cast<Notification*>(n)->GetGroupIdx();
}

EXPORT uint8_t notification_get_event(notification_t* n) {
    return reinterpret_cast<Notification*>(n)->GetEvent();
}

EXPORT uint8_t notification_get_button_id(notification_t* n) {
    return reinterpret_cast<Notification*>(n)->GetButtonId();
}

EXPORT uint8_t notification_get_scene_id(notification_t* n) {
    return reinterpret_cast<Notification*>(n)->GetSceneId();
}

EXPORT uint8_t notification_get_notification(notification_t* n) {
    return reinterpret_cast<Notification*>(n)->GetNotification();
}

EXPORT uint8_t notification_get_byte(notification_t* n) {
    return reinterpret_cast<Notification*>(n)->GetByte();
}

EXPORT int32_t notification_get_as_string(notification_t* n, char* strOut) {
    string str = reinterpret_cast<Notification*>(n)->GetAsString();
    if (strOut)
        strcpy(strOut, str.c_str());
    return (int32_t)str.length();
}


//==============================================================================
// VALUEID
//==============================================================================

EXPORT value_id_t* value_id_create(uint32_t const _homeId, uint8_t const _nodeId, value_genre_t const _genre, uint8_t const _commandClassId, uint8_t const _instance, uint8_t const _valueIndex, value_id_value_type_t const _type) {
    ValueID* vid = new ValueID(_homeId, _nodeId, (ValueID::ValueGenre)_genre, _commandClassId, _instance, _valueIndex, (ValueID::ValueType)_type);
    return reinterpret_cast<value_id_t*>(vid);
}

EXPORT void value_id_delete(value_id_t* v) {
    delete reinterpret_cast<ValueID*>(v);
}

EXPORT uint32_t value_id_get_home_id(value_id_t* n) {
    return reinterpret_cast<ValueID*>(n)->GetHomeId();
}

EXPORT uint8_t value_id_get_node_id(value_id_t* n) {
    return reinterpret_cast<ValueID*>(n)->GetNodeId();
}

EXPORT value_genre_t value_id_get_genre_type(value_id_t* n) {
    return (value_genre_t)reinterpret_cast<ValueID*>(n)->GetGenre();
}

EXPORT uint8_t value_id_get_command_class_id(value_id_t* n) {
    return reinterpret_cast<ValueID*>(n)->GetCommandClassId();
}

EXPORT uint8_t value_id_get_instance(value_id_t* n) {
    return reinterpret_cast<ValueID*>(n)->GetInstance();
}

EXPORT uint8_t value_id_get_value_index(value_id_t* n) {
    return reinterpret_cast<ValueID*>(n)->GetIndex();
}

EXPORT value_id_value_type_t value_id_get_value_type(value_id_t* n) {
    return (value_id_value_type_t)reinterpret_cast<ValueID*>(n)->GetType();
}

EXPORT uint64_t value_id_get_id(value_id_t* n) {
    return reinterpret_cast<ValueID*>(n)->GetId();
}


//==============================================================================
// MANAGER
//==============================================================================

//-----------------------------------------------------------------------------
// Construction

EXPORT manager_t* manager_create() {
    return reinterpret_cast<manager_t*>(Manager::Create());
}

EXPORT manager_t* manager_get() {
    return reinterpret_cast<manager_t*>(Manager::Get());
}

EXPORT void manager_destroy() {
    Manager::Destroy();
}

EXPORT int32_t manager_get_version_as_string(char* versionOut) {
    string str = Manager::getVersionAsString();
    if (versionOut)
        strcpy(versionOut, str.c_str());
    return (int32_t)str.length();
}

EXPORT int32_t manager_get_version_long_as_string(char* versionOut) {
    string str = Manager::getVersionLongAsString();
    if (versionOut)
        strcpy(versionOut, str.c_str());
    return (int32_t)str.length();
}

//-----------------------------------------------------------------------------
// Configuration

EXPORT void manager_write_config(manager_t* m, uint32_t homeId) {
    reinterpret_cast<Manager*>(m)->WriteConfig(homeId);
}

EXPORT options_t* manager_get_options(manager_t* m) {
    return reinterpret_cast<options_t*>(reinterpret_cast<Manager*>(m)->GetOptions());
}

//-----------------------------------------------------------------------------
// Drivers

EXPORT bool manager_add_driver(manager_t* m, char* controllerPath, driver_controller_interface_t controllerInterface) {
    return reinterpret_cast<Manager*>(m)->AddDriver(controllerPath, (Driver::ControllerInterface)controllerInterface);
}

EXPORT bool manager_remove_driver(manager_t* m, char* controllerPath) {
    return reinterpret_cast<Manager*>(m)->RemoveDriver(controllerPath);
}

EXPORT uint8_t manager_get_controller_node_id(manager_t* m, uint32_t homeId) {
    return reinterpret_cast<Manager*>(m)->GetControllerNodeId(homeId);
}

EXPORT uint8_t manager_get_static_update_controller_node_id(manager_t* m, uint32_t homeId) {
    return reinterpret_cast<Manager*>(m)->GetSUCNodeId(homeId);
}

EXPORT bool manager_is_primary_controller(manager_t* m, uint32_t homeId) {
    return reinterpret_cast<Manager*>(m)->IsPrimaryController(homeId);
}

EXPORT bool manager_is_static_update_controller(manager_t* m, uint32_t homeId) {
    return reinterpret_cast<Manager*>(m)->IsStaticUpdateController(homeId);
}

EXPORT bool manager_is_bridge_controller(manager_t* m, uint32_t homeId) {
    return reinterpret_cast<Manager*>(m)->IsBridgeController(homeId);
}

EXPORT int32_t manager_get_library_version(manager_t* m, uint32_t homeId, char* versionOut) {
    string str = reinterpret_cast<Manager*>(m)->GetLibraryVersion(homeId);
    if (versionOut)
        strcpy(versionOut, str.c_str());
    return (int32_t)str.length();
}

EXPORT int32_t manager_get_library_type_name(manager_t* m, uint32_t homeId, char* versionOut) {
    string str = reinterpret_cast<Manager*>(m)->GetLibraryTypeName(homeId);
    if (versionOut)
        strcpy(versionOut, str.c_str());
    return (int32_t)str.length();
}

EXPORT int32_t manager_get_send_queue_count(manager_t* m, uint32_t homeId) {
    return reinterpret_cast<Manager*>(m)->GetSendQueueCount(homeId);
}

EXPORT void manager_log_driver_statistics(manager_t* m, uint32_t homeId) {
    reinterpret_cast<Manager*>(m)->LogDriverStatistics(homeId);
}

EXPORT driver_controller_interface_t manager_get_controller_interface_type(manager_t* m, uint32_t homeId) {
    return (driver_controller_interface_t)reinterpret_cast<Manager*>(m)->GetControllerInterfaceType(homeId);
}

EXPORT int32_t manager_get_controller_path(manager_t* m, uint32_t homeId, char* pathOut) {
    string str = reinterpret_cast<Manager*>(m)->GetControllerPath(homeId);
    if (pathOut)
        strcpy(pathOut, str.c_str());
    return (int32_t)str.length();
}

//-----------------------------------------------------------------------------
// Polling Z-Wave devices

EXPORT uint32_t manager_get_poll_interval(manager_t* m) {
    return reinterpret_cast<Manager*>(m)->GetPollInterval();
}

EXPORT void manager_set_poll_interval(manager_t* m, int milliseconds, bool intervalBetweenPolls) {
    reinterpret_cast<Manager*>(m)->SetPollInterval(milliseconds, intervalBetweenPolls);
}

EXPORT bool manager_enable_poll(manager_t* m, value_id_t* valueId, uint8_t intensity) {
    const ValueID* vid = reinterpret_cast<ValueID*>(valueId);
    return reinterpret_cast<Manager*>(m)->EnablePoll(*vid, intensity);
}

EXPORT bool manager_disable_poll(manager_t* m, value_id_t* valueId) {
    const ValueID* vid = reinterpret_cast<ValueID*>(valueId);
    return reinterpret_cast<Manager*>(m)->DisablePoll(*vid);
}

EXPORT bool manager_is_polled(manager_t* m, value_id_t* valueId) {
    const ValueID* vid = reinterpret_cast<ValueID*>(valueId);
    return reinterpret_cast<Manager*>(m)->isPolled(*vid);
}

EXPORT void manager_set_poll_intensity(manager_t* m, value_id_t* valueId, uint8_t intensity) {
    const ValueID* vid = reinterpret_cast<ValueID*>(valueId);
    reinterpret_cast<Manager*>(m)->SetPollIntensity(*vid, intensity);
}

EXPORT uint8_t manager_get_poll_intensity(manager_t* m, value_id_t* valueId) {
    const ValueID* vid = reinterpret_cast<ValueID*>(valueId);
    return reinterpret_cast<Manager*>(m)->GetPollIntensity(*vid);
}

//-----------------------------------------------------------------------------
// Node information

EXPORT bool manager_refresh_node_info(manager_t* m, uint32_t homeId, uint8_t nodeId) {
    return reinterpret_cast<Manager*>(m)->RefreshNodeInfo(homeId, nodeId);
}

EXPORT bool manager_request_node_state(manager_t* m, uint32_t homeId, uint8_t nodeId) {
    return reinterpret_cast<Manager*>(m)->RequestNodeState(homeId, nodeId);
}

EXPORT bool manager_is_node_listening_device(manager_t* m, uint32_t homeId, uint8_t nodeId) {
    return reinterpret_cast<Manager*>(m)->IsNodeListeningDevice(homeId, nodeId);
}

EXPORT bool manager_request_node_dynamic(manager_t* m, uint32_t homeId, uint8_t nodeId) {
    return reinterpret_cast<Manager*>(m)->RequestNodeDynamic(homeId, nodeId);
}

EXPORT bool manager_is_node_frequent_listening_device(manager_t* m, uint32_t homeId, uint8_t nodeId) {
    return reinterpret_cast<Manager*>(m)->IsNodeFrequentListeningDevice(homeId, nodeId);
}

EXPORT bool manager_is_node_beaming_device(manager_t* m, uint32_t homeId, uint8_t nodeId) {
    return reinterpret_cast<Manager*>(m)->IsNodeBeamingDevice(homeId, nodeId);
}

EXPORT bool manager_is_node_routing_device(manager_t* m, uint32_t homeId, uint8_t nodeId) {
    return reinterpret_cast<Manager*>(m)->IsNodeRoutingDevice(homeId, nodeId);
}

EXPORT bool manager_is_node_security_device(manager_t* m, uint32_t homeId, uint8_t nodeId) {
    return reinterpret_cast<Manager*>(m)->IsNodeSecurityDevice(homeId, nodeId);
}

EXPORT uint32_t manager_get_node_max_baud_rate(manager_t* m, uint32_t homeId, uint8_t nodeId) {
    return reinterpret_cast<Manager*>(m)->GetNodeMaxBaudRate(homeId, nodeId);
}

EXPORT uint8_t manager_get_node_version(manager_t* m, uint32_t homeId, uint8_t nodeId) {
    return reinterpret_cast<Manager*>(m)->GetNodeVersion(homeId, nodeId);
}

EXPORT uint8_t manager_get_node_security(manager_t* m, uint32_t homeId, uint8_t nodeId) {
    return reinterpret_cast<Manager*>(m)->GetNodeSecurity(homeId, nodeId);
}

EXPORT bool manager_is_node_zwave_plus(manager_t* m, uint32_t homeId, uint8_t nodeId) {
    return reinterpret_cast<Manager*>(m)->IsNodeZWavePlus(homeId, nodeId);
}

EXPORT uint8_t manager_get_node_basic(manager_t* m, uint32_t homeId, uint8_t nodeId) {
    return reinterpret_cast<Manager*>(m)->GetNodeBasic(homeId, nodeId);
}

EXPORT uint8_t manager_get_node_generic(manager_t* m, uint32_t homeId, uint8_t nodeId) {
    return reinterpret_cast<Manager*>(m)->GetNodeGeneric(homeId, nodeId);
}

EXPORT uint8_t manager_get_node_specific(manager_t* m, uint32_t homeId, uint8_t nodeId) {
    return reinterpret_cast<Manager*>(m)->GetNodeSpecific(homeId, nodeId);
}

EXPORT int manager_get_node_type(manager_t* m, uint32_t homeId, uint8_t nodeId, char* strOut) {
    string str = reinterpret_cast<Manager*>(m)->GetNodeType(homeId, nodeId);
    if (strOut)
        strcpy(strOut, str.c_str());
    return (int)str.length();
}

EXPORT void manager_get_node_neighbors(manager_t* m, uint32_t homeId, uint8_t nodeId, uint8_t** neighbors, uint32_t* num) {
    *num = reinterpret_cast<Manager*>(m)->GetNodeNeighbors(homeId, nodeId, neighbors);
}

EXPORT int manager_get_node_manufacturer_name(manager_t* m, uint32_t homeId, uint8_t nodeId, char* strOut) {
    string str = reinterpret_cast<Manager*>(m)->GetNodeManufacturerName(homeId, nodeId);
    if (strOut)
        strcpy(strOut, str.c_str());
    return (int)str.length();
}

EXPORT int manager_get_node_product_name(manager_t* m, uint32_t homeId, uint8_t nodeId, char* strOut) {
    string str = reinterpret_cast<Manager*>(m)->GetNodeProductName(homeId, nodeId);
    if (strOut)
        strcpy(strOut, str.c_str());
    return (int)str.length();
}

EXPORT int manager_get_node_name(manager_t* m, uint32_t homeId, uint8_t nodeId, char* strOut) {
    string str = reinterpret_cast<Manager*>(m)->GetNodeName(homeId, nodeId);
    if (strOut)
        strcpy(strOut, str.c_str());
    return (int)str.length();
}

EXPORT int manager_get_node_location(manager_t* m, uint32_t homeId, uint8_t nodeId, char* strOut) {
    string str = reinterpret_cast<Manager*>(m)->GetNodeLocation(homeId, nodeId);
    if (strOut)
        strcpy(strOut, str.c_str());
    return (int)str.length();
}

EXPORT int manager_get_node_manufacturer_id(manager_t* m, uint32_t homeId, uint8_t nodeId, char* strOut) {
    string str = reinterpret_cast<Manager*>(m)->GetNodeManufacturerId(homeId, nodeId);
    if (strOut)
        strcpy(strOut, str.c_str());
    return (int)str.length();
}

EXPORT int manager_get_node_product_type(manager_t* m, uint32_t homeId, uint8_t nodeId, char* strOut) {
    string str = reinterpret_cast<Manager*>(m)->GetNodeProductType(homeId, nodeId);
    if (strOut)
        strcpy(strOut, str.c_str());
    return (int)str.length();
}

EXPORT int manager_get_node_product_id(manager_t* m, uint32_t homeId, uint8_t nodeId, char* strOut) {
    string str = reinterpret_cast<Manager*>(m)->GetNodeProductId(homeId, nodeId);
    if (strOut)
        strcpy(strOut, str.c_str());
    return (int)str.length();
}

EXPORT void manager_set_node_manufacturer_name(manager_t* m, uint32_t homeId, uint8_t nodeId, char* name) {
    reinterpret_cast<Manager*>(m)->SetNodeManufacturerName(homeId, nodeId, name);
}

EXPORT void manager_set_node_name(manager_t* m, uint32_t homeId, uint8_t nodeId, char* name) {
    reinterpret_cast<Manager*>(m)->SetNodeName(homeId, nodeId, name);
}

EXPORT void manager_set_node_location(manager_t* m, uint32_t homeId, uint8_t nodeId, char* name) {
    reinterpret_cast<Manager*>(m)->SetNodeLocation(homeId, nodeId, name);
}

EXPORT void manager_set_node_on(manager_t* m, uint32_t homeId, uint8_t nodeId) {
    reinterpret_cast<Manager*>(m)->SetNodeOn(homeId, nodeId);
}

EXPORT void manager_set_node_off(manager_t* m, uint32_t homeId, uint8_t nodeId) {
    reinterpret_cast<Manager*>(m)->SetNodeOff(homeId, nodeId);
}

EXPORT void manager_set_node_level(manager_t* m, uint32_t homeId, uint8_t nodeId, uint8_t level) {
    reinterpret_cast<Manager*>(m)->SetNodeLevel(homeId, nodeId, level);
}

// TODO: IsNodeInfoReceived
// TODO: GetNodeClassInformation
// TODO: IsNodeAwake
// TODO: IsNodeFailed
// TODO: GetNodeQueryStage
// TODO: GetNodeDeviceType
// TODO: GetNodeDeviceTypeString
// TODO: GetNodeRole
// TODO: GetNodeRoleString
// TODO: GetNodePlusType
// TODO: GetNodePlusTypeString

//-----------------------------------------------------------------------------
// Values

EXPORT int manager_get_node_value_label(manager_t* m, value_id_t* valueId, char* strOut) {
    const ValueID* vid = reinterpret_cast<ValueID*>(valueId);
    string str = reinterpret_cast<Manager*>(m)->GetValueLabel(*vid);
    if (strOut)
        strcpy(strOut, str.c_str());
    return (int)str.length();
}

EXPORT void manager_set_node_value_label(manager_t* m, value_id_t* valueId, char* name) {
    const ValueID* vid = reinterpret_cast<ValueID*>(valueId);
    reinterpret_cast<Manager*>(m)->SetValueLabel(*vid, name);
}

EXPORT int manager_get_node_value_units(manager_t* m, value_id_t* valueId, char* strOut) {
    const ValueID* vid = reinterpret_cast<ValueID*>(valueId);
    string str = reinterpret_cast<Manager*>(m)->GetValueUnits(*vid);
    if (strOut)
        strcpy(strOut, str.c_str());
    return (int)str.length();
}

EXPORT void manager_set_node_value_units(manager_t* m, value_id_t* valueId, char* name) {
    const ValueID* vid = reinterpret_cast<ValueID*>(valueId);
    reinterpret_cast<Manager*>(m)->SetValueUnits(*vid, name);
}

EXPORT int manager_get_node_value_help(manager_t* m, value_id_t* valueId, char* strOut) {
    const ValueID* vid = reinterpret_cast<ValueID*>(valueId);
    string str = reinterpret_cast<Manager*>(m)->GetValueHelp(*vid);
    if (strOut)
        strcpy(strOut, str.c_str());
    return (int)str.length();
}

EXPORT void manager_set_node_value_help(manager_t* m, value_id_t* valueId, char* name) {
    const ValueID* vid = reinterpret_cast<ValueID*>(valueId);
    reinterpret_cast<Manager*>(m)->SetValueHelp(*vid, name);
}

EXPORT uint32_t manager_get_value_min(manager_t* m, value_id_t* valueId) {
    const ValueID* vid = reinterpret_cast<ValueID*>(valueId);
    return reinterpret_cast<Manager*>(m)->GetValueMin(*vid);
}

EXPORT uint32_t manager_get_value_max(manager_t* m, value_id_t* valueId) {
    const ValueID* vid = reinterpret_cast<ValueID*>(valueId);
    return reinterpret_cast<Manager*>(m)->GetValueMax(*vid);
}

EXPORT bool manager_is_value_read_only(manager_t* m, value_id_t* valueId) {
    const ValueID* vid = reinterpret_cast<ValueID*>(valueId);
    return reinterpret_cast<Manager*>(m)->IsValueReadOnly(*vid);
}

EXPORT bool manager_is_value_write_only(manager_t* m, value_id_t* valueId) {
    const ValueID* vid = reinterpret_cast<ValueID*>(valueId);
    return reinterpret_cast<Manager*>(m)->IsValueWriteOnly(*vid);
}

EXPORT bool manager_is_value_set(manager_t* m, value_id_t* valueId) {
    const ValueID* vid = reinterpret_cast<ValueID*>(valueId);
    return reinterpret_cast<Manager*>(m)->IsValueSet(*vid);
}

EXPORT bool manager_is_value_polled(manager_t* m, value_id_t* valueId) {
    const ValueID* vid = reinterpret_cast<ValueID*>(valueId);
    return reinterpret_cast<Manager*>(m)->IsValuePolled(*vid);
}

EXPORT bool manager_get_value_as_bool(manager_t* m, value_id_t* valueId, bool* outBool) {
    const ValueID* vid = reinterpret_cast<ValueID*>(valueId);
    return reinterpret_cast<Manager*>(m)->GetValueAsBool(*vid, outBool);
}

EXPORT bool manager_get_value_as_byte(manager_t* m, value_id_t* valueId, uint8_t* outByte) {
    const ValueID* vid = reinterpret_cast<ValueID*>(valueId);
    return reinterpret_cast<Manager*>(m)->GetValueAsByte(*vid, outByte);
}

EXPORT bool manager_get_value_as_float(manager_t* m, value_id_t* valueId, float* outFloat) {
    const ValueID* vid = reinterpret_cast<ValueID*>(valueId);
    return reinterpret_cast<Manager*>(m)->GetValueAsFloat(*vid, outFloat);
}

EXPORT bool manager_get_value_as_int(manager_t* m, value_id_t* valueId, int* outInt) {
    const ValueID* vid = reinterpret_cast<ValueID*>(valueId);
    return reinterpret_cast<Manager*>(m)->GetValueAsInt(*vid, outInt);
}

EXPORT bool manager_get_value_as_short(manager_t* m, value_id_t* valueId, int16* outInt) {
    const ValueID* vid = reinterpret_cast<ValueID*>(valueId);
    return reinterpret_cast<Manager*>(m)->GetValueAsShort(*vid, outInt);
}

EXPORT bool manager_get_node_value_string(manager_t* m, value_id_t* valueId, string* strOut) {
    const ValueID* vid = reinterpret_cast<ValueID*>(valueId);
    return reinterpret_cast<Manager*>(m)->GetValueAsString(*vid, strOut);
}

// TODO: GetValueAsRaw

EXPORT bool manager_get_node_value_list_selection(manager_t* m, value_id_t* valueId, string* strOut) {
    const ValueID* vid = reinterpret_cast<ValueID*>(valueId);
    return reinterpret_cast<Manager*>(m)->GetValueListSelection(*vid, strOut);
}

// TODO: bool GetValueListSelection( ValueID const& _id, int32* o_value );
// TODO: GetValueListItems
// TODO: GetValueListValues
// TODO: GetValueFloatPrecision
// TODO: SetValue (bool, uint8, float, int32, int16, uint8*, string)
// TODO: SetValueListSelection
// TODO: RefreshValue
// TODO: SetChangeVerified
// TODO: GetChangeVerified
// TODO: PressButton
// TODO: ReleaseButton

//-----------------------------------------------------------------------------
// Climate Control Schedules

// TODO: GetNumSwitchPoints
// TODO: SetSwitchPoint
// TODO: RemoveSwitchPoint
// TODO: ClearSwitchPoints
// TODO: GetSwitchPoint

//-----------------------------------------------------------------------------
// SwitchAll

// TODO: SwitchAllOn
// TODO: SwitchAllOff

//-----------------------------------------------------------------------------
// Configuration Parameters

EXPORT bool manager_set_config_params(manager_t* m, uint32_t homeId, uint8_t nodeId, uint8_t param, int32_t value, uint8_t size = 2) {
    return reinterpret_cast<Manager*>(m)->SetConfigParam(homeId, nodeId, param, value, size);
}

EXPORT void manager_request_config_params(manager_t* m, uint32_t homeId, uint8_t nodeId, uint8_t param) {
    reinterpret_cast<Manager*>(m)->RequestConfigParam(homeId, nodeId, param);
}

EXPORT void manager_request_all_config_params(manager_t* m, uint32_t homeId, uint8_t nodeId) {
    reinterpret_cast<Manager*>(m)->RequestAllConfigParams(homeId, nodeId);
}

//-----------------------------------------------------------------------------
// Groups (wrappers for the Node methods)

// TODO: GetNumGroups
// TODO: GetAssociations x2
// TODO: GetMaxAssociations
// TODO: GetGroupLabel
// TODO: AddAssociation
// TODO: RemoveAssociation

//-----------------------------------------------------------------------------
// Notifications

EXPORT bool manager_add_watcher(manager_t* m, on_ontification_delegate_t watcher, void* context) {
    return reinterpret_cast<Manager*>(m)->AddWatcher((Manager::pfnOnNotification_t)watcher, context);
}

EXPORT bool manager_remove_watcher(manager_t* m, on_ontification_delegate_t watcher, void* context) {
    return reinterpret_cast<Manager*>(m)->RemoveWatcher((Manager::pfnOnNotification_t)watcher, context);
}

//-----------------------------------------------------------------------------
// Controller commands

EXPORT void manager_reset_controller(manager_t* m, uint32_t homeId) {
    reinterpret_cast<Manager*>(m)->ResetController(homeId);
}

EXPORT void manager_soft_reset(manager_t* m, uint32_t homeId) {
    reinterpret_cast<Manager*>(m)->SoftReset(homeId);
}

// TODO: BeginControllerCommand (DEPRECATED)
// TODO: RemoveAssociation

//-----------------------------------------------------------------------------
// Network commands

// TODO: TestNetworkNode
// TODO: TestNetwork
// TODO: HealNetworkNode
// TODO: HealNetwork

EXPORT bool manager_add_node(manager_t* m, uint32_t homeId, bool doSecurity) {
    return reinterpret_cast<Manager*>(m)->AddNode(homeId, doSecurity);
}

EXPORT bool manager_remove_node(manager_t* m, uint32_t homeId) {
    return reinterpret_cast<Manager*>(m)->RemoveNode(homeId);
}

EXPORT bool manager_remove_failed_node(manager_t* m, uint32_t homeId, uint8_t nodeId) {
    return reinterpret_cast<Manager*>(m)->RemoveFailedNode(homeId, nodeId);
}

EXPORT bool manager_has_node_failed(manager_t* m, uint32_t homeId, uint8_t nodeId) {
    return reinterpret_cast<Manager*>(m)->HasNodeFailed(homeId, nodeId);
}

// TODO: RequestNodeNeighborUpdate
// TODO: AssignReturnRoute
// TODO: DeleteAllReturnRoutes
// TODO: SendNodeInformation

EXPORT bool manager_create_new_primary(manager_t* m, uint32_t homeId) {
    return reinterpret_cast<Manager*>(m)->CreateNewPrimary(homeId);
}

EXPORT bool manager_revieve_configuration(manager_t* m, uint32_t homeId) {
    return reinterpret_cast<Manager*>(m)->ReceiveConfiguration(homeId);
}

// TODO: TransferPrimaryRole

EXPORT bool manager_transfer_primary_role(manager_t* m, uint32_t homeId) {
    return reinterpret_cast<Manager*>(m)->TransferPrimaryRole(homeId);
}

// TODO: ReplicationSend
// TODO: CreateButton
// TODO: DeleteButton

//-----------------------------------------------------------------------------
// Scene commands

// TODO: GetNumScenes
// TODO: GetAllScenes
// TODO: RemoveAllScenes
// TODO: CreateScene
// TODO: RemoveScene
// TODO: AddSceneValue x6
// TODO: AddSceneValueListSelection x2
// TODO: RemoveSceneValue
// TODO: SceneGetValues
// TODO: SceneGetValueAs[Bool|Byte|Float|Int|Short|String]
// TODO: SceneGetValueListSelection x2
// TODO: SetSceneValue x6
// TODO: SetSceneValueListSelection x2
// TODO: GetSceneLabel
// TODO: SetSceneLabel
// TODO: SceneExists
// TODO: ActivateScene

//-----------------------------------------------------------------------------
// Statistics interface

// TODO: GetDriverStatistics
// TODO: GetNodeStatistics

#ifdef __cplusplus
}
#endif
