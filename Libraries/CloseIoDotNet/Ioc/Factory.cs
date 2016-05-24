namespace CloseIoDotNet.Ioc
{
    using System;
    using System.Collections.Generic;

    public static class Factory
    {
        #region Instance Variables
        private static Dictionary<Type, Object> _typeLookup;
        #endregion

        #region Properties
        private static Dictionary<Type, Object> TypeLookup
        {
            get { return _typeLookup ?? (_typeLookup = new Dictionary<Type, object>()); }
            set { _typeLookup = value; }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Clears the dispenser.
        /// </summary>
        public static void ClearDispenser()
        {
            TypeLookup.Clear();
        }

        /// <summary>
        /// Adds an object to be dispensed for the given type.
        /// </summary>
        /// <typeparam name="Interface">The type of the Interface.</typeparam>
        /// <typeparam name="Class">The type of the Class.</typeparam>
        /// <param name="obj">The obj.</param>
        public static void DispenseForType<Interface, Class>(Interface obj)
        {
            if (TypeLookup.ContainsKey(typeof(Class)))
            {
                TypeLookup[typeof(Class)] = obj;
            }
            else
            {
                TypeLookup.Add(typeof(Class), obj);
            }
        }

        /// <summary>
        /// Creates the specified type passing in the supplied args.
        /// </summary>
        /// <typeparam name="Interface">The type of the interface.</typeparam>
        /// <typeparam name="Class">The type of the class.</typeparam>
        /// <param name="args">The constuctor arguments.</param>
        /// <returns></returns>
        public static Interface Create<Interface, Class>(params object[] args) where Class : Interface
        {
            if (TypeLookup.ContainsKey(typeof(Class)))
            {
                return (Interface)TypeLookup[typeof(Class)];
            }

            return (Interface)Activator.CreateInstance(typeof(Class), args);

        }

        /// <summary>
        /// Create the specified type using default/no arg constuctor
        /// </summary>
        /// <typeparam name="Interface">The type of the interface</typeparam>
        /// <typeparam name="Class">The type of the class</typeparam>
        /// <returns></returns>
        public static Interface Create<Interface, Class>() where Class : Interface, new()
        {
            if (TypeLookup.ContainsKey(typeof(Class)))
            {
                return (Interface)TypeLookup[typeof(Class)];
            }

            return (Interface)new Class();
        }
        #endregion
    }
}