using System;
namespace UsersDb_Core.Entities
{
	public abstract class Entity<T>
	{
		public T Id { get; set; }
	}
}

