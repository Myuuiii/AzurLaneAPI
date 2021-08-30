using System;

namespace AzurLaneAPI.Routes.V1
{
    public static partial class Routes
    {
        public static class ReleaseNotes
		{
			public const String GetAll = "/releasenotes";
			public const String GetLatest = "/releasenotes/latest";
			public const String GetVersion = "/releasenotes/version/{version}";
			public const String Create = "/releasenotes";
		}
    }
}