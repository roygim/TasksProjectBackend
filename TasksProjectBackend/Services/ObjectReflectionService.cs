using Org.BouncyCastle.Asn1.X509.SigI;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using TasksProjectBackend.SimpleObjects;
using System.Reflection;

namespace TasksProjectBackend.Services
{
    public class ObjectReflectionService
    {
        public ObjectReflectionService()
        {
        }

        //public string GetData(Object obj)
        //{
        //    string val = string.Empty;

        //    Type t = obj.GetType();
        //    val += "Object of Class \"" + t.Name + "\"\r\n";
        //    val += "----------------------------\r\n";

        //    PropertyInfo[] props = t.GetProperties();

        //    foreach (var prop in props)
        //    {
        //        val += prop.Name + " = " + prop.GetValue(obj) + "\r\n";
        //    }

        //    return val;
        //}

        public string GetData(Object obj)
        {
            string val = string.Empty;
            val = this.GetDataRecursive(obj, 1);
            return val;
        }

        private string GetDataRecursive(Object obj, int index)
        {
            if(obj == null)
                return "null";

            string val = string.Empty;

            Type t = obj.GetType();

            string classTabs = new string('\t', index - 1);

            val += "Object of Class \"" + t.Name + "\"\r\n";
            val += classTabs + "----------------------------\r\n";

            PropertyInfo[] props = t.GetProperties();

            foreach (var prop in props)
            {
                string propTabs = new string('\t', index);

                if (this.IsSimpleType(prop))
                {
                    var propVal = prop.GetValue(obj) != null? prop.GetValue(obj) : "null";
                    val += propTabs + prop.Name + " = " + propVal + "\r\n";
                }
                else
                {
                    val += propTabs + prop.Name + " = " + this.GetDataRecursive(prop.GetValue(obj), index + 1);
                }
            }

            return val;
        }

        private bool IsSimpleType(PropertyInfo prop)
        {
            Type type = prop.PropertyType;

            return
                type.IsValueType ||
                type.IsPrimitive ||
                new Type[]
                {
                    typeof(String),
                    typeof(Decimal),
                    typeof(DateTime),
                    typeof(DateTimeOffset),
                    typeof(TimeSpan),
                    typeof(Guid)

                }.Contains(type) ||
                        Convert.GetTypeCode(type) != TypeCode.Object;
        }
    }
}
