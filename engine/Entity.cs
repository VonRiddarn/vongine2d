using System;
using System.Collections.Generic;

namespace vongine2d
{
	public class Entity
	{
		public ulong UID {get; private set;}
		public string Name {get; private set;}
		public Layer Layer {get; private set;}
		public bool IsActive {get; set;}
		public Entity Parent {get; private set;}
		public Entity RootParent {get; private set;}
		public int ComponentsCount => _components.Count;
		public Component[] Components => _components.ToArray();
		public Entity[] Children => _children.ToArray();
		public int ChildrenCount => _children.Count;

		protected List<Tag> _tags = new List<Tag>();
		protected List<Component> _components = new List<Component>();
		protected List<Entity> _children = new List<Entity>();

		public override string ToString()
		{
			return $"Object: {Name} < {Parent.Name} << {RootParent.Name}\nComponent count: {ComponentsCount}";
		}

		public Entity()
		{
			throw new NotImplementedException();
		}

		public void SetActive(bool newState) => IsActive = newState;

		public T? GetComponent<T>() where T : Component
		{
			for(int i = 0; i < _components.Count; i++)
			{
				if(_components[i] is T c)
					return c;
			}
			
			return null;
		}

		public T? GetComponentInChildren<T>() where T : Component
		{
			Stack<Entity> stack = new Stack<Entity>();

			for(int i = 0; i < _children.Count; i++)
				stack.Push(_children[i]);

			while(stack.Count > 0)
			{
				Entity currentChild = stack.Pop();

				for(int i = 0; i < currentChild.ComponentsCount; i++)
				{
					if(currentChild.Components[i] is T c)
						return c;
				}

				for(int i = 0; i < currentChild.ChildrenCount; i++)
				{
					stack.Push(currentChild.Children[i]);
				}
			}

			return null;
		}

		public T[] GetComponents<T>() where T : Component
		{
			List<T> components = new List<T>(_components.Count);

			for(int i = 0; i < _components.Count; i++)
			{
				if(_components[i] is T c)
					components.Add(c);
			}
			
			return components.ToArray();
		}

		public Component[] GetComponentsInChildren<T>()
		{
			throw new NotImplementedException();
		}

		public Component AddComponent(Component component)
		{
			throw new NotImplementedException();
		}

		public Component[] AddComponents(Component[] components)
		{
			throw new NotImplementedException();
		}

		public Entity AppendChild(Entity child)
		{
			throw new NotImplementedException();
		}

		public Entity AppendChildren(Entity[] children)
		{
			throw new NotImplementedException();
		}

		public bool CompareTag(Tag tag)
		{
			throw new NotImplementedException();
		}

		public bool CompareTags(Tag[] tags, bool matchAll)
		{
			throw new NotImplementedException();
		}

		void UpdateMetaData()
		{
			// Update Parent and Root parent
			throw new NotImplementedException();
		}

		void OnUpdate()
		{
			throw new NotImplementedException();
			// TODO:
			/*
				Add logic in initialization to trigger this function when an update happens globally.
			*/
		}

		// STATICS 

		// CREATE / DESTROY
		public static Entity Create() => throw new NotImplementedException();
		public static Entity Destroy(Entity entity) => throw new NotImplementedException();

		// SEARCH
		public static Entity Find(int UID) => throw new NotImplementedException();
		public static Entity Find(string name) => throw new NotImplementedException();
		public static Entity Find(Tag tag) => throw new NotImplementedException();
		public static Entity Find(Tag[] tags, bool matchAll) => throw new NotImplementedException();

		public static Entity FindAll(int UID) => throw new NotImplementedException();
		public static Entity FindAll(string name) => throw new NotImplementedException();
		public static Entity FindAll(Tag tag) => throw new NotImplementedException();
		public static Entity FindAll(Tag[] tags, bool matchAll) => throw new NotImplementedException();

	}
}