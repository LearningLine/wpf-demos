using System;
using System.Collections.Generic;

namespace WpfAddressBook
{
	public class IoC
	{
		private static IoC instance;
		public static IoC Instance
		{
			get { return instance ?? (instance = new IoC()); }
		}

		readonly Dictionary<Type,object> InterfaceToConcreteType = new Dictionary<Type, object>();

		public void Register<T>(Type interfaceType, T concreteInstance)
			where T : class
		{ 
			InterfaceToConcreteType.Add(interfaceType,concreteInstance);
		}

		public void Register<T>(Type interfaceType, Type concrete)
			where T : class
		{
			T concreteInstance = Activator.CreateInstance(concrete) as T;
			InterfaceToConcreteType.Add(interfaceType, concreteInstance);
		}

		public T Resolve<T>() where T : class
		{
			return InterfaceToConcreteType[typeof(T)] as T;
		}
	}
}
