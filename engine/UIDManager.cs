namespace vongine2d
{
	public static class UIDManager
	{
		static ulong nextUID = 0;

		public static ulong GenerateUID() => nextUID++;
	}
}