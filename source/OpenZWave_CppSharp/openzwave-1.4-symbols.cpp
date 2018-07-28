#include </Users/clancey/Projects/OpenZWave.NET/externals/open-zwave/cpp/src/Bitfield.h>
#include </Users/clancey/Projects/OpenZWave.NET/externals/open-zwave/cpp/src/Defs.h>
#include </Users/clancey/Projects/OpenZWave.NET/externals/open-zwave/cpp/src/DoxygenMain.h>
#include </Users/clancey/Projects/OpenZWave.NET/externals/open-zwave/cpp/src/Driver.h>
#include </Users/clancey/Projects/OpenZWave.NET/externals/open-zwave/cpp/src/Group.h>
#include </Users/clancey/Projects/OpenZWave.NET/externals/open-zwave/cpp/src/Manager.h>
#include </Users/clancey/Projects/OpenZWave.NET/externals/open-zwave/cpp/src/Msg.h>
#include </Users/clancey/Projects/OpenZWave.NET/externals/open-zwave/cpp/src/Node.h>
#include </Users/clancey/Projects/OpenZWave.NET/externals/open-zwave/cpp/src/Notification.h>
#include </Users/clancey/Projects/OpenZWave.NET/externals/open-zwave/cpp/src/OZWException.h>
#include </Users/clancey/Projects/OpenZWave.NET/externals/open-zwave/cpp/src/Options.h>
#include </Users/clancey/Projects/OpenZWave.NET/externals/open-zwave/cpp/src/Scene.h>
#include </Users/clancey/Projects/OpenZWave.NET/externals/open-zwave/cpp/src/Utils.h>
#include </Users/clancey/Projects/OpenZWave.NET/externals/open-zwave/cpp/src/ZWSecurity.h>

::uint32 (OpenZWave::Bitfield::Iterator::*openzwave_1_4_symbols1)() const = &OpenZWave::Bitfield::Iterator::operator*;
OpenZWave::Bitfield::Iterator& (OpenZWave::Bitfield::Iterator::*openzwave_1_4_symbols2)() = &OpenZWave::Bitfield::Iterator::operator++;
OpenZWave::Bitfield::Iterator (OpenZWave::Bitfield::Iterator::*openzwave_1_4_symbols3)(int) = &OpenZWave::Bitfield::Iterator::operator++;
bool (OpenZWave::Bitfield::Iterator::*openzwave_1_4_symbols4)(const OpenZWave::Bitfield::Iterator&) = &OpenZWave::Bitfield::Iterator::operator==;
bool (OpenZWave::Bitfield::Iterator::*openzwave_1_4_symbols5)(const OpenZWave::Bitfield::Iterator&) = &OpenZWave::Bitfield::Iterator::operator!=;
extern "C" { void openzwave_1_4_symbols6(void* instance, const OpenZWave::Bitfield::Iterator& _0) { new (instance) OpenZWave::Bitfield::Iterator(_0); } }
extern "C" { void openzwave_1_4_symbols7(OpenZWave::Bitfield::Iterator* instance) { instance->~Iterator(); } }
OpenZWave::Bitfield::Iterator& (OpenZWave::Bitfield::Iterator::*openzwave_1_4_symbols8)(const OpenZWave::Bitfield::Iterator&) = &OpenZWave::Bitfield::Iterator::operator=;
OpenZWave::Bitfield::Iterator& (OpenZWave::Bitfield::Iterator::*openzwave_1_4_symbols9)(OpenZWave::Bitfield::Iterator&&) = &OpenZWave::Bitfield::Iterator::operator=;
extern "C" { void openzwave_1_4_symbols10(void* instance) { new (instance) OpenZWave::Bitfield(); } }
extern "C" { void openzwave_1_4_symbols11(OpenZWave::Bitfield* instance) { instance->~Bitfield(); } }
void (OpenZWave::Bitfield::*openzwave_1_4_symbols12)(::uint32) = &OpenZWave::Bitfield::Set;
void (OpenZWave::Bitfield::*openzwave_1_4_symbols13)(::uint32) = &OpenZWave::Bitfield::Clear;
bool (OpenZWave::Bitfield::*openzwave_1_4_symbols14)(::uint32) const = &OpenZWave::Bitfield::IsSet;
::uint32 (OpenZWave::Bitfield::*openzwave_1_4_symbols15)() const = &OpenZWave::Bitfield::GetNumSetBits;
OpenZWave::Bitfield::Iterator (OpenZWave::Bitfield::*openzwave_1_4_symbols16)() const = &OpenZWave::Bitfield::Begin;
OpenZWave::Bitfield::Iterator (OpenZWave::Bitfield::*openzwave_1_4_symbols17)() const = &OpenZWave::Bitfield::End;
extern "C" { void openzwave_1_4_symbols18(void* instance, const OpenZWave::Bitfield& _0) { new (instance) OpenZWave::Bitfield(_0); } }
OpenZWave::Bitfield& (OpenZWave::Bitfield::*openzwave_1_4_symbols19)(const OpenZWave::Bitfield&) = &OpenZWave::Bitfield::operator=;
extern "C" { void openzwave_1_4_symbols20(void* instance, std::__1::string file, int line, OpenZWave::OZWException::ExceptionType exitCode, std::__1::string msg) { new (instance) OpenZWave::OZWException(file, line, exitCode, msg); } }
OpenZWave::OZWException::ExceptionType (OpenZWave::OZWException::*openzwave_1_4_symbols21)() = &OpenZWave::OZWException::GetType;
std::__1::string (OpenZWave::OZWException::*openzwave_1_4_symbols22)() = &OpenZWave::OZWException::GetFile;
::uint32 (OpenZWave::OZWException::*openzwave_1_4_symbols23)() = &OpenZWave::OZWException::GetLine;
std::__1::string (OpenZWave::OZWException::*openzwave_1_4_symbols24)() = &OpenZWave::OZWException::GetMsg;
extern "C" { void openzwave_1_4_symbols25(void* instance, const OpenZWave::OZWException& _0) { new (instance) OpenZWave::OZWException(_0); } }
OpenZWave::OZWException& (OpenZWave::OZWException::*openzwave_1_4_symbols26)(const OpenZWave::OZWException&) = &OpenZWave::OZWException::operator=;
extern "C" { void openzwave_1_4_symbols27(void* instance) { new (instance) OpenZWave::Driver::PollEntry(); } }
extern "C" { void openzwave_1_4_symbols28(void* instance, const OpenZWave::Driver::PollEntry& _0) { new (instance) OpenZWave::Driver::PollEntry(_0); } }
OpenZWave::Driver::PollEntry& (OpenZWave::Driver::PollEntry::*openzwave_1_4_symbols29)(const OpenZWave::Driver::PollEntry&) = &OpenZWave::Driver::PollEntry::operator=;
OpenZWave::Driver::PollEntry& (OpenZWave::Driver::PollEntry::*openzwave_1_4_symbols30)(OpenZWave::Driver::PollEntry&&) = &OpenZWave::Driver::PollEntry::operator=;
extern "C" { void openzwave_1_4_symbols31(OpenZWave::Driver::PollEntry* instance) { instance->~PollEntry(); } }
extern "C" { void openzwave_1_4_symbols32(void* instance) { new (instance) OpenZWave::Driver::DriverData(); } }
extern "C" { void openzwave_1_4_symbols33(void* instance, const OpenZWave::Driver::DriverData& _0) { new (instance) OpenZWave::Driver::DriverData(_0); } }
OpenZWave::Driver::DriverData& (OpenZWave::Driver::DriverData::*openzwave_1_4_symbols34)(const OpenZWave::Driver::DriverData&) = &OpenZWave::Driver::DriverData::operator=;
OpenZWave::Driver::DriverData& (OpenZWave::Driver::DriverData::*openzwave_1_4_symbols35)(OpenZWave::Driver::DriverData&&) = &OpenZWave::Driver::DriverData::operator=;
extern "C" { void openzwave_1_4_symbols36(OpenZWave::Driver::DriverData* instance) { instance->~DriverData(); } }
::uint8 (OpenZWave::Driver::*openzwave_1_4_symbols37)(const OpenZWave::Msg*) const = &OpenZWave::Driver::GetNodeNumber;
::uint8 (OpenZWave::Driver::*openzwave_1_4_symbols38)() const = &OpenZWave::Driver::GetTransmitOptions;
::uint32 (OpenZWave::ValueID::*openzwave_1_4_symbols39)() const = &OpenZWave::ValueID::GetHomeId;
::uint8 (OpenZWave::ValueID::*openzwave_1_4_symbols40)() const = &OpenZWave::ValueID::GetNodeId;
OpenZWave::ValueID::ValueGenre (OpenZWave::ValueID::*openzwave_1_4_symbols41)() const = &OpenZWave::ValueID::GetGenre;
::uint8 (OpenZWave::ValueID::*openzwave_1_4_symbols42)() const = &OpenZWave::ValueID::GetCommandClassId;
::uint8 (OpenZWave::ValueID::*openzwave_1_4_symbols43)() const = &OpenZWave::ValueID::GetInstance;
::uint8 (OpenZWave::ValueID::*openzwave_1_4_symbols44)() const = &OpenZWave::ValueID::GetIndex;
OpenZWave::ValueID::ValueType (OpenZWave::ValueID::*openzwave_1_4_symbols45)() const = &OpenZWave::ValueID::GetType;
::uint64 (OpenZWave::ValueID::*openzwave_1_4_symbols46)() const = &OpenZWave::ValueID::GetId;
bool (OpenZWave::ValueID::*openzwave_1_4_symbols47)(const OpenZWave::ValueID&) const = &OpenZWave::ValueID::operator==;
bool (OpenZWave::ValueID::*openzwave_1_4_symbols48)(const OpenZWave::ValueID&) const = &OpenZWave::ValueID::operator!=;
bool (OpenZWave::ValueID::*openzwave_1_4_symbols49)(const OpenZWave::ValueID&) const = &OpenZWave::ValueID::operator<;
bool (OpenZWave::ValueID::*openzwave_1_4_symbols50)(const OpenZWave::ValueID&) const = &OpenZWave::ValueID::operator>;
extern "C" { void openzwave_1_4_symbols51(void* instance, const ::uint32 _homeId, const ::uint8 _nodeId, const OpenZWave::ValueID::ValueGenre _genre, const ::uint8 _commandClassId, const ::uint8 _instance, const ::uint8 _valueIndex, const OpenZWave::ValueID::ValueType _type) { new (instance) OpenZWave::ValueID(_homeId, _nodeId, _genre, _commandClassId, _instance, _valueIndex, _type); } }
extern "C" { void openzwave_1_4_symbols52(void* instance, ::uint32 _homeId, ::uint64 id) { new (instance) OpenZWave::ValueID(_homeId, id); } }
extern "C" { void openzwave_1_4_symbols53(void* instance, const OpenZWave::ValueID& _0) { new (instance) OpenZWave::ValueID(_0); } }
extern "C" { void openzwave_1_4_symbols54(OpenZWave::ValueID* instance) { instance->~ValueID(); } }
OpenZWave::ValueID& (OpenZWave::ValueID::*openzwave_1_4_symbols55)(const OpenZWave::ValueID&) = &OpenZWave::ValueID::operator=;
OpenZWave::ValueID& (OpenZWave::ValueID::*openzwave_1_4_symbols56)(OpenZWave::ValueID&&) = &OpenZWave::ValueID::operator=;
extern "C" { void openzwave_1_4_symbols57(OpenZWave::Msg* instance) { instance->~Msg(); } }
::uint8 (OpenZWave::Msg::*openzwave_1_4_symbols58)() const = &OpenZWave::Msg::GetTargetNodeId;
::uint8 (OpenZWave::Msg::*openzwave_1_4_symbols59)() const = &OpenZWave::Msg::GetCallbackId;
::uint8 (OpenZWave::Msg::*openzwave_1_4_symbols60)() const = &OpenZWave::Msg::GetExpectedReply;
::uint8 (OpenZWave::Msg::*openzwave_1_4_symbols61)() const = &OpenZWave::Msg::GetExpectedCommandClassId;
::uint8 (OpenZWave::Msg::*openzwave_1_4_symbols62)() const = &OpenZWave::Msg::GetExpectedInstance;
std::__1::string (OpenZWave::Msg::*openzwave_1_4_symbols63)() const = &OpenZWave::Msg::GetLogText;
::uint32 (OpenZWave::Msg::*openzwave_1_4_symbols64)() const = &OpenZWave::Msg::GetLength;
::uint8 (OpenZWave::Msg::*openzwave_1_4_symbols65)() const = &OpenZWave::Msg::GetSendAttempts;
void (OpenZWave::Msg::*openzwave_1_4_symbols66)(::uint8) = &OpenZWave::Msg::SetSendAttempts;
::uint8 (OpenZWave::Msg::*openzwave_1_4_symbols67)() const = &OpenZWave::Msg::GetMaxSendAttempts;
void (OpenZWave::Msg::*openzwave_1_4_symbols68)(::uint8) = &OpenZWave::Msg::SetMaxSendAttempts;
bool (OpenZWave::Msg::*openzwave_1_4_symbols69)() = &OpenZWave::Msg::IsWakeUpNoMoreInformationCommand;
bool (OpenZWave::Msg::*openzwave_1_4_symbols70)() = &OpenZWave::Msg::IsNoOperation;
bool (OpenZWave::Msg::*openzwave_1_4_symbols71)(const OpenZWave::Msg&) const = &OpenZWave::Msg::operator==;
::uint8 (OpenZWave::Msg::*openzwave_1_4_symbols72)() = &OpenZWave::Msg::GetSendingCommandClass;
bool (OpenZWave::Msg::*openzwave_1_4_symbols73)() = &OpenZWave::Msg::isEncrypted;
void (OpenZWave::Msg::*openzwave_1_4_symbols74)() = &OpenZWave::Msg::setEncrypted;
bool (OpenZWave::Msg::*openzwave_1_4_symbols75)() = &OpenZWave::Msg::isNonceRecieved;
void (OpenZWave::Msg::*openzwave_1_4_symbols76)(::uint8[8]) = &OpenZWave::Msg::setNonce;
void (OpenZWave::Msg::*openzwave_1_4_symbols77)() = &OpenZWave::Msg::clearNonce;
void (OpenZWave::Msg::*openzwave_1_4_symbols78)(::uint32) = &OpenZWave::Msg::SetHomeId;
extern "C" { void openzwave_1_4_symbols79(void* instance, const OpenZWave::Msg& _0) { new (instance) OpenZWave::Msg(_0); } }
OpenZWave::Msg& (OpenZWave::Msg::*openzwave_1_4_symbols80)(const OpenZWave::Msg&) = &OpenZWave::Msg::operator=;
OpenZWave::InstanceAssociation& (OpenZWave::InstanceAssociation::*openzwave_1_4_symbols81)(const OpenZWave::InstanceAssociation&) = &OpenZWave::InstanceAssociation::operator=;
OpenZWave::InstanceAssociation& (OpenZWave::InstanceAssociation::*openzwave_1_4_symbols82)(OpenZWave::InstanceAssociation&&) = &OpenZWave::InstanceAssociation::operator=;
extern "C" { void openzwave_1_4_symbols83(void* instance, const OpenZWave::InstanceAssociation& _0) { new (instance) OpenZWave::InstanceAssociation(_0); } }
extern "C" { void openzwave_1_4_symbols84(OpenZWave::InstanceAssociation* instance) { instance->~InstanceAssociation(); } }
extern "C" { void openzwave_1_4_symbols85(void* instance) { new (instance) OpenZWave::InstanceAssociation(); } }
extern "C" { void openzwave_1_4_symbols86(OpenZWave::Group* instance) { instance->~Group(); } }
const std::__1::string& (OpenZWave::Group::*openzwave_1_4_symbols87)() const = &OpenZWave::Group::GetLabel;
::uint8 (OpenZWave::Group::*openzwave_1_4_symbols88)() const = &OpenZWave::Group::GetMaxAssociations;
::uint8 (OpenZWave::Group::*openzwave_1_4_symbols89)() const = &OpenZWave::Group::GetIdx;
extern "C" { void openzwave_1_4_symbols90(void* instance, const OpenZWave::Group& _0) { new (instance) OpenZWave::Group(_0); } }
OpenZWave::Group& (OpenZWave::Group::*openzwave_1_4_symbols91)(const OpenZWave::Group&) = &OpenZWave::Group::operator=;
extern "C" { void openzwave_1_4_symbols92(void* instance, const OpenZWave::Node::NodeData& _0) { new (instance) OpenZWave::Node::NodeData(_0); } }
OpenZWave::Node::NodeData& (OpenZWave::Node::NodeData::*openzwave_1_4_symbols93)(OpenZWave::Node::NodeData&&) = &OpenZWave::Node::NodeData::operator=;
extern "C" { void openzwave_1_4_symbols94(OpenZWave::Node::NodeData* instance) { instance->~NodeData(); } }
extern "C" { void openzwave_1_4_symbols95(void* instance) { new (instance) OpenZWave::Node::NodeData(); } }
OpenZWave::Node::NodeData& (OpenZWave::Node::NodeData::*openzwave_1_4_symbols96)(const OpenZWave::Node::NodeData&) = &OpenZWave::Node::NodeData::operator=;
extern "C" { void openzwave_1_4_symbols97(void* instance) { new (instance) OpenZWave::Node::CommandClassData(); } }
extern "C" { void openzwave_1_4_symbols98(void* instance, const OpenZWave::Node::CommandClassData& _0) { new (instance) OpenZWave::Node::CommandClassData(_0); } }
OpenZWave::Node::CommandClassData& (OpenZWave::Node::CommandClassData::*openzwave_1_4_symbols99)(const OpenZWave::Node::CommandClassData&) = &OpenZWave::Node::CommandClassData::operator=;
OpenZWave::Node::CommandClassData& (OpenZWave::Node::CommandClassData::*openzwave_1_4_symbols100)(OpenZWave::Node::CommandClassData&&) = &OpenZWave::Node::CommandClassData::operator=;
extern "C" { void openzwave_1_4_symbols101(OpenZWave::Node::CommandClassData* instance) { instance->~CommandClassData(); } }
OpenZWave::Node::QueryStage (OpenZWave::Node::*openzwave_1_4_symbols102)() = &OpenZWave::Node::GetCurrentQueryStage;
bool (OpenZWave::Node::*openzwave_1_4_symbols103)() const = &OpenZWave::Node::IsNodeAlive;
bool (OpenZWave::Node::*openzwave_1_4_symbols104)() const = &OpenZWave::Node::ProtocolInfoReceived;
bool (OpenZWave::Node::*openzwave_1_4_symbols105)() const = &OpenZWave::Node::NodeInfoReceived;
bool (OpenZWave::Node::*openzwave_1_4_symbols106)() const = &OpenZWave::Node::IsNodeZWavePlus;
bool (OpenZWave::Node::*openzwave_1_4_symbols107)() const = &OpenZWave::Node::AllQueriesCompleted;
void (OpenZWave::Node::*openzwave_1_4_symbols108)(const bool) = &OpenZWave::Node::SetNodePlusInfoReceived;
bool (OpenZWave::Node::*openzwave_1_4_symbols109)() const = &OpenZWave::Node::IsListeningDevice;
bool (OpenZWave::Node::*openzwave_1_4_symbols110)() const = &OpenZWave::Node::IsFrequentListeningDevice;
bool (OpenZWave::Node::*openzwave_1_4_symbols111)() const = &OpenZWave::Node::IsBeamingDevice;
bool (OpenZWave::Node::*openzwave_1_4_symbols112)() const = &OpenZWave::Node::IsRoutingDevice;
bool (OpenZWave::Node::*openzwave_1_4_symbols113)() const = &OpenZWave::Node::IsSecurityDevice;
::uint32 (OpenZWave::Node::*openzwave_1_4_symbols114)() const = &OpenZWave::Node::GetMaxBaudRate;
::uint8 (OpenZWave::Node::*openzwave_1_4_symbols115)() const = &OpenZWave::Node::GetVersion;
::uint8 (OpenZWave::Node::*openzwave_1_4_symbols116)() const = &OpenZWave::Node::GetSecurity;
::uint8 (OpenZWave::Node::*openzwave_1_4_symbols117)() const = &OpenZWave::Node::GetNodeId;
::uint8 (OpenZWave::Node::*openzwave_1_4_symbols118)() const = &OpenZWave::Node::GetBasic;
::uint8 (OpenZWave::Node::*openzwave_1_4_symbols119)() const = &OpenZWave::Node::GetGeneric;
::uint8 (OpenZWave::Node::*openzwave_1_4_symbols120)() const = &OpenZWave::Node::GetSpecific;
const std::__1::string& (OpenZWave::Node::*openzwave_1_4_symbols121)() const = &OpenZWave::Node::GetType;
bool (OpenZWave::Node::*openzwave_1_4_symbols122)() const = &OpenZWave::Node::IsController;
bool (OpenZWave::Node::*openzwave_1_4_symbols123)() const = &OpenZWave::Node::IsAddingNode;
void (OpenZWave::Node::*openzwave_1_4_symbols124)() = &OpenZWave::Node::SetAddingNode;
void (OpenZWave::Node::*openzwave_1_4_symbols125)() = &OpenZWave::Node::ClearAddingNode;
OpenZWave::Manager* (*openzwave_1_4_symbols126)() = &OpenZWave::Manager::Get;
OpenZWave::Options* (OpenZWave::Manager::*openzwave_1_4_symbols127)() const = &OpenZWave::Manager::GetOptions;
extern "C" { void openzwave_1_4_symbols128(void* instance, const OpenZWave::Manager& _0) { new (instance) OpenZWave::Manager(_0); } }
OpenZWave::Manager& (OpenZWave::Manager::*openzwave_1_4_symbols129)(const OpenZWave::Manager&) = &OpenZWave::Manager::operator=;
OpenZWave::Notification::NotificationType (OpenZWave::Notification::*openzwave_1_4_symbols130)() const = &OpenZWave::Notification::GetType;
::uint32 (OpenZWave::Notification::*openzwave_1_4_symbols131)() const = &OpenZWave::Notification::GetHomeId;
::uint8 (OpenZWave::Notification::*openzwave_1_4_symbols132)() const = &OpenZWave::Notification::GetNodeId;
const OpenZWave::ValueID& (OpenZWave::Notification::*openzwave_1_4_symbols133)() const = &OpenZWave::Notification::GetValueID;
::uint8 (OpenZWave::Notification::*openzwave_1_4_symbols134)() const = &OpenZWave::Notification::GetGroupIdx;
::uint8 (OpenZWave::Notification::*openzwave_1_4_symbols135)() const = &OpenZWave::Notification::GetEvent;
::uint8 (OpenZWave::Notification::*openzwave_1_4_symbols136)() const = &OpenZWave::Notification::GetButtonId;
::uint8 (OpenZWave::Notification::*openzwave_1_4_symbols137)() const = &OpenZWave::Notification::GetSceneId;
::uint8 (OpenZWave::Notification::*openzwave_1_4_symbols138)() const = &OpenZWave::Notification::GetNotification;
::uint8 (OpenZWave::Notification::*openzwave_1_4_symbols139)() const = &OpenZWave::Notification::GetByte;
extern "C" { void openzwave_1_4_symbols140(void* instance, const OpenZWave::Notification& _0) { new (instance) OpenZWave::Notification(_0); } }
OpenZWave::Notification& (OpenZWave::Notification::*openzwave_1_4_symbols141)(const OpenZWave::Notification&) = &OpenZWave::Notification::operator=;
OpenZWave::Options* (*openzwave_1_4_symbols142)() = &OpenZWave::Options::Get;
bool (OpenZWave::Options::*openzwave_1_4_symbols143)() const = &OpenZWave::Options::AreLocked;
extern "C" { void openzwave_1_4_symbols144(void* instance, const OpenZWave::Options& _0) { new (instance) OpenZWave::Options(_0); } }
OpenZWave::Options& (OpenZWave::Options::*openzwave_1_4_symbols145)(const OpenZWave::Options&) = &OpenZWave::Options::operator=;
extern "C" { void openzwave_1_4_symbols146(void* instance, const OpenZWave::Scene& _0) { new (instance) OpenZWave::Scene(_0); } }
OpenZWave::Scene& (OpenZWave::Scene::*openzwave_1_4_symbols147)(const OpenZWave::Scene&) = &OpenZWave::Scene::operator=;
extern "C" { void openzwave_1_4_symbols148(OpenZWave::LockGuard* instance) { instance->~LockGuard(); } }
void (OpenZWave::LockGuard::*openzwave_1_4_symbols149)() = &OpenZWave::LockGuard::Unlock;
OpenZWave::i_LogImpl& (OpenZWave::i_LogImpl::*openzwave_1_4_symbols150)(const OpenZWave::i_LogImpl&) = &OpenZWave::i_LogImpl::operator=;
extern "C" { void openzwave_1_4_symbols151(void* instance, const OpenZWave::Log& _0) { new (instance) OpenZWave::Log(_0); } }
OpenZWave::Log& (OpenZWave::Log::*openzwave_1_4_symbols152)(const OpenZWave::Log&) = &OpenZWave::Log::operator=;
