namespace vongine2d
{
	public abstract class Component
	{
		public ulong UID {get; private set;}
		public Entity? Entity {get; private set;}
		public bool IsEnabled {get; private set;}
	}
}