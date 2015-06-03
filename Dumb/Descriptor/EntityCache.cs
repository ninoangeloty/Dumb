using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Dumb
{
    public static class EntityCache
    {
        public static List<ModelInfo> _cache;

        public static ModelInfo Get<T>()
        {
            if (_cache == null)
            {
                _cache = new List<ModelInfo>();
            }

            if (!_cache.Any(_ => _.DataType == typeof(T)))
            {
                EntityCache.Register<T>();
            }

            return _cache.Single(_ => _.DataType == typeof(T));
        }

        private static void Register<T>()
        {
            _cache.Add(
                new ModelInfo() 
                { 
                    TableName = EntityCache.GetTableInformation<T>(), 
                    DataType = typeof(T), 
                    Properties = EntityCache.GetPropertyInfo<T>() 
                }
            );
        }

        private static string GetTableInformation<T>()
        {
            var attribute = typeof(T).GetCustomAttribute(typeof(TableAttribute));

            if (attribute != null)
            {
                return ((TableAttribute)attribute).Name;
            }

            return string.Empty;
        }

        private static IEnumerable<PropertyDescription> GetPropertyInfo<T>()
        {
            var propertyDescriptions = new List<PropertyDescription>();
            var properties = typeof(T).GetProperties();
            
            foreach (var prop in properties)
	        {
                var attribute = prop.GetCustomAttribute(typeof(FieldAttribute));
                var fieldAttribute = attribute != null ? (FieldAttribute)attribute : (FieldAttribute)null;
                propertyDescriptions.Add(new PropertyDescription() { Member = prop, Field = fieldAttribute });
	        }

            return propertyDescriptions;
        }
    }
}
