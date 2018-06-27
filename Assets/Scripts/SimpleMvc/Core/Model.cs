using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleMvc
{
    public class Model : IModel
    {
        protected static readonly IDictionary<Type, IModel> mInstanceMap;

        static Model()
        {
            mInstanceMap = new Dictionary<Type, IModel>();
        }

        public static T GetModel<T>() where T : IModel
        {
            Type key = typeof(T);
            IModel result;
            if (mInstanceMap.TryGetValue(key, out result))
            {
                return (T)result;
            }
            result = Activator.CreateInstance<T>();
            mInstanceMap[key] = result;
            return (T)result;
        }

        public static void RemoveModel<T>() where T : IModel
        {
            Type key = typeof(T);
            IModel model;
            if (!mInstanceMap.TryGetValue(key, out model))
            {
                return;
            }
            mInstanceMap.Remove(key);
        }
    }
}
