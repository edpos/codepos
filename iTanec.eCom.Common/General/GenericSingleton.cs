using System;
using System.Globalization;
using System.Reflection;
using System.Threading;

namespace iTanec.eCom.Common.General
{
    /// <summary>
    /// Generic singleton class provides singleton instance of appropriate type
    /// </summary>
    /// <history>
    ///  Author				:	Edwin J
    ///  Creation Date		:	16/1/2014
    ///  Last revised		:
    ///  Revision history	:
    /// </history>
    public static class GenericSingleton<T> where T : class
    {
        /// <summary>
        /// Private variable for instance count
        /// </summary>
        private static int instanceCount;

        /// <summary>
        /// Private variable for instance
        /// </summary>
        private static T instance;

        /// <summary>
        /// Gets the instance of the singleton
        /// </summary>
        public static T Instance
        {
            get
            {
                if (instanceCount == 0)
                {
                    T newInstance = CreateInstance();
                    object reference = Interlocked.CompareExchange(
                        ref instance, newInstance, null);

                    if (reference == null)
                    {
                        Interlocked.Increment(ref instanceCount);
                    }
                }

                return instance;
            }
        }

        /// <summary>
        /// Creates the instance of the specified type
        /// </summary>
        /// <returns>The type used in the singleton</returns>
        private static T CreateInstance()
        {
            return (T)Activator.CreateInstance(typeof(T), BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance, null, new object[0], CultureInfo.InvariantCulture);
        }
    }
}