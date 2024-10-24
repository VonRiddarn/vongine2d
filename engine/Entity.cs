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
		public Entity? Parent {get; private set;}
		public Entity RootParent => Parent == null ? this : Parent.RootParent; // TODO: Maybe use cahce and invalidation later for better performance?
		public int ComponentsCount => _components.Count;
		public Component[] Components => _components.ToArray();
		public Entity[] Children => _children.ToArray();
		public int ChildrenCount => _children.Count;

		protected List<Tag> _tags = new List<Tag>();
		protected List<Component> _components = new List<Component>();
		protected List<Entity> _children = new List<Entity>();

		public override string ToString()
		{
			return $"Object: {Name} < {Parent?.Name} << {RootParent.Name}\nComponent count: {ComponentsCount}";
		}

		public Entity()
		{
			throw new NotImplementedException();
		}

		public void SetActive(bool newState) 
		{
			IsActive = newState;
		}

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

		public T[] GetComponentsInChildren<T>() where T : Component
		{
			// This list will still resize like crazy on bigger trees, but it shouldn't be an issue
			List<T> components = new List<T>(_components.Count + _children.Count);
			Stack<Entity> stack = new Stack<Entity>();

			for(int i = 0; i < _children.Count; i++)
				stack.Push(_children[i]);

			while(stack.Count > 0)
			{
				Entity currentChild = stack.Pop();

				for(int i = 0; i < currentChild.ComponentsCount; i++)
				{
					if(currentChild.Components[i] is T c)
						components.Add(c);
				}

				for(int i = 0; i < currentChild.ChildrenCount; i++)
				{
					stack.Push(currentChild.Children[i]);
				}
			}

			return components.ToArray();
		}

		public Component AddComponent(Component component)
		{
			_components.Add(component);

			return component;
		}

		public T AddComponent<T>(T component) where T : Component 
		{
			_components.Add(component);

			return component;
		}

		public Component[] AddComponents(Component[] components)
		{
			for(int i = 0; i < components.Length; i++)
				_components.Add(components[i]);

			return components;
		}

		public T[] AddComponents<T>(T[] components) where T : Component
		{
			for(int i = 0; i < components.Length; i++)
				_components.Add(components[i]);

			return components;
		}

		public void  ForceAppendChild(Entity child)
		{
			_children.Add(child);
		}

		public Entity AppendChild(Entity child)
		{
			child.ChangeParent(this);
			_children.Add(child);
			
			return child;
		}

		public Entity[] AppendChildren(Entity[] children)
		{
			for(int i = 0; i < children.Length; i++)
			{
				children[i].ChangeParent(this);
				_children.Add(children[i]);
			}

			return children;
		}

		public bool CompareTag(Tag tag)
		{
			return _tags.Contains(tag);
		}

		public bool CompareTags(Tag[] tags, bool matchAll)
		{
			for(int i = 0; i < tags.Length; i++)
			{
				if(matchAll)
				{
					if(!_tags.Contains(tags[i]))
						return false;
				}
				else
				{
					if(_tags.Contains(tags[i]))
						return true;
				}
			}

			return matchAll;
		}

		public bool RemoveChild(Entity child)
		{
			if(!_children.Remove(child))
				return false;

			child.ChangeParent(null);
			return true;
		}

		public void ChangeParent(Entity? newParent)
		{
			if(Parent == newParent)
				return;

			Entity? ancestor = newParent;
			while(ancestor != null)
			{
				if(ancestor == this)
					throw new InvalidOperationException("Cannot set entity as its own parent or ancestor!");

				ancestor = ancestor.Parent;
			}

			Parent?.RemoveChild(this);
			
			Parent = newParent;
			newParent?.ForceAppendChild(this);
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