using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace _ExtensionMethods
{
    public static class Helper
    {
        private static readonly IDictionary<Type, IEnumerable<PropertyInfo>> _Properties =
            new Dictionary<Type, IEnumerable<PropertyInfo>>();

        /// <summary>
        /// Converts a DataTable to a list with generic objects
        /// </summary>
        /// <typeparam name="T">Generic object</typeparam>
        /// <param name="table">DataTable</param>
        /// <returns>List with generic objects</returns>
        /// 


        public static List<T> Tabla_a_Lista<T>(this DataTable dt) where T : new()
        {
            Type businessEntityType = typeof(T);
            List<T> entitys = new List<T>();
            Hashtable hashtable = new Hashtable();
            PropertyInfo[] properties = businessEntityType.GetProperties();
            foreach (PropertyInfo info in properties)
            {
                hashtable[info.Name.ToUpper()] = info;
            }
            // while (dr.Read())

            var aTSource = new T();
            foreach (DataRow row in dt.Rows)
            {

                T newObject = new T();

                for (int index = 0; index < dt.Columns.Count; index++)
                {
                    PropertyInfo info = (PropertyInfo)
                                        hashtable[dt.Columns[index].ColumnName.ToUpper()];
                    if ((info != null) && info.CanWrite)
                    {
                        var oo = Convert.ChangeType(row[index], info.PropertyType);
                        info.SetValue(newObject, Convert.ChangeType(row[index], info.PropertyType), null);
                    }
                }
                entitys.Add(newObject);


            }

            return entitys;
        }




        public static List<T> DataTableToList<T>(this DataTable table) where T : class, new()
        {
            try
            {
                List<T> list = new List<T>();

                foreach (var row in table.AsEnumerable())
                {
                    T obj = new T();

                    foreach (var prop in obj.GetType().GetProperties())
                    {
                        try
                        {
                            PropertyInfo propertyInfo = obj.GetType().GetProperty(prop.Name);
                            propertyInfo.SetValue(obj, Convert.ChangeType(row[prop.Name], propertyInfo.PropertyType), null);
                        }
                        catch
                        {
                            continue;
                        }
                    }

                    list.Add(obj);
                }

                return list;
            }
            catch
            {
                return null;
            }
        }



        /// <summary>
        ///  public static List<T> MapDataToBusinessEntityCollection<T>(this IDataReader dr)where T : new()
        public static List<T> MapData<T>(this IDataReader dr)where T : new()
        {
            Type businessEntityType = typeof(T);
            List<T> entitys = new List<T>();
            Hashtable hashtable = new Hashtable();
            PropertyInfo[] properties = businessEntityType.GetProperties();
            foreach (PropertyInfo info in properties)
            {
                hashtable[info.Name.ToUpper()] = info;
            }
            while (dr.Read())
            {
                T newObject = new T();
                for (int index = 0; index < dr.FieldCount; index++)
                {
                    PropertyInfo info = (PropertyInfo)
                                        hashtable[dr.GetName(index).ToUpper()];
                    string e = dr.GetName(index).ToUpper();
                    if ((info != null) && info.CanWrite)
                    {


                        var ee = dr.GetDataTypeName(index);
                        var pp = dr.GetFieldType(index);
                        Type type = dr.GetFieldType(index);

                        var value = dr.GetValue(index);
                        switch (type.Name)
                        {
                            case "String":
                                 if (value == DBNull.Value) value = "";
                                break;
                            case "Decimal":
                                if (value == DBNull.Value) value =Convert.ToDecimal(0);
                                break;
                                ;
                            case "Boolean":
                                if (value == DBNull.Value) value =Convert.ToBoolean(0);
                                break;
                            case "DateTime":
                                if (value == DBNull.Value) value =Convert.ToDateTime("01/01/1999");
                                break;
                            case "Double":
                                if (value == DBNull.Value) value =Convert.ToDouble(0);
                                break;

                        }
 
                        info.SetValue(newObject, value, null);
                        


                    }
                }
                entitys.Add(newObject);
            }
           
            return entitys;
        }


        public static T Cast<T>(this Object myobj, ref SqlDataReader destObject)
        {
            Type objectType = myobj.GetType();
            Type target = typeof(T);
            var x = Activator.CreateInstance(target, false);
            var z = from source in objectType.GetMembers().ToList()
                    where source.MemberType == MemberTypes.Property
                    select source;
            var d = from source in target.GetMembers().ToList()
                    where source.MemberType == MemberTypes.Property
                    select source;
            List<MemberInfo> members = d.Where(memberInfo => d.Select(c => c.Name)
               .ToList().Contains(memberInfo.Name)).ToList();
            PropertyInfo propertyInfo;
            object value;
            foreach (var memberInfo in members)
            {
                propertyInfo = typeof(T).GetProperty(memberInfo.Name);
                value = myobj.GetType().GetProperty(memberInfo.Name).GetValue(myobj, null);

                propertyInfo.SetValue(x, value, null);
            }
            return (T)x;
        }

    }
}
