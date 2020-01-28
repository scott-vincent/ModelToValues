using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModelToValues.Helpers
{
    public class Model
    {
        /// <summary>
        /// Converts a model into a set of property name/value pairs.
        /// Any objects in the model are recursed and included in the
        /// set but the set is flat (does not include object names).
        /// 
        /// Any null properties in the model are not included in the set.
        /// </summary>
        public static Dictionary<string, string> GetProperties(object model)
        {
            var values = new Dictionary<string, string>();

            Type type = model.GetType();

            // Do primitives first
            foreach (var prop in type.GetProperties())
            {
                var value = prop.GetValue(model);

                if (value != null)
                {
                    values.Add(prop.Name, value.ToString());
                }
            }

            // Now do objects
            foreach (var field in type.GetFields())
            {
                var objValue = field.GetValue(model);

                if (objValue != null)
                {
                    var objValues = GetProperties(objValue);
                    objValues.ToList().ForEach(x => values.Add(x.Key, x.Value));
                }
            }

            return values;
        }

        /// <summary>
        /// Sets the primitive properties of a model from the supplied property
        /// name/value pairs. Note that only primitives are set, not objects.
        /// 
        /// Any supplied property names that aren't in the model are ignored.
        /// </summary>
        public static object SetProperties(Dictionary<string, string> values)
        {
            return null;
        }
    }
}
