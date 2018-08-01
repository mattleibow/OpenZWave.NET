namespace OpenZWave
{
	public enum ZWValueType
	{
		Bool = 0,
		Byte,
		Decimal,
		Int,
		List,
		Schedule,
		Short,
		String,
		Button,
		Raw,
	}

	public enum ValueGenre
	{
		Basic = 0,
		User,
		Config,
		System,
	}

	public enum NotificationType
	{
		ValueAdded = 0,
		ValueRemoved,
		ValueChanged,
		ValueRefreshed,
		Group,
		NodeNew,
		NodeAdded,
		NodeRemoved,
		NodeProtocolInfo,
		NodeNaming,
		NodeEvent,
		PollingDisabled,
		PollingEnabled,
		SceneEvent,
		CreateButton,
		DeleteButton,
		ButtonOn,
		ButtonOff,
		DriverReady,
		DriverFailed,
		DriverReset,
		EssentialNodeQueriesComplete,
		NodeQueriesComplete,
		AwakeNodesQueried,
		AllNodesQueriedSomeDead,
		AllNodesQueried,
		Notification,
		DriverRemoved,
		ControllerCommand,
		NodeReset
	}

	public enum NotificationCode
	{
		MessageComplete = 0,
		Timeout,
		NoOperation,
		Awake,
		Sleep,
		Dead,
		Alive
	}

	public enum LogLevel
	{
		Invalid,
		None,
		Always,
		Fatal,
		Error,
		Warning,
		Alert,
		Info,
		Detail,
		Debug,
		StreamDetail,
		Internal
	}
}
