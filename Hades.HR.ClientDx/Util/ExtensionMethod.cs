using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Hades.HR.UI
{
    public static class ExtensionMethod
    {
        /// <summary>
        /// 显示Display属性值
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string DisplayName(this Enum value)
        {
            Type enumType = value.GetType();
            var enumValue = Enum.GetName(enumType, value);
            MemberInfo member = enumType.GetMember(enumValue)[0];

            var attrs = member.GetCustomAttributes(typeof(DisplayAttribute), false);
            if (attrs == null || attrs.Length == 0)
                return value.ToString();

            var outString = ((DisplayAttribute)attrs[0]).Name;

            if (((DisplayAttribute)attrs[0]).ResourceType != null)
            {
                outString = ((DisplayAttribute)attrs[0]).GetName();
            }

            return outString;
        }

        /// <summary>
        /// 显示DateTime? 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToDateString(this DateTime? value)
        {
            if (value == null)
                return "";
            else
            {
                if (value.Value <= Convert.ToDateTime("1900-1-1"))
                {
                    return "";
                }
                else
                {
                    DateTime dt = (DateTime)value;
                    return dt.ToString("yyyy-MM-dd");
                }
            }
        }

        /// <summary>
        /// 显示DateTime
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToDateString(this DateTime value)
        {
            if (value == null)
                return "";
            else
            {
                if (value <= Convert.ToDateTime("1900-1-1"))
                {
                    return "";
                }
                else
                {
                    return value.ToString("yyyy-MM-dd");
                }
            }
        }
    }
}
