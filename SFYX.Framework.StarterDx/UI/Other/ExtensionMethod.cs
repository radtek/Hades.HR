using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.XtraEditors;
using Hades.Framework.BaseUI;
using Hades.Framework.Commons;

namespace SFYX.Framework.Starter
{
    /// <summary>
    /// 扩展函数封装
    /// </summary>
    public static class ExtensionMethod
    {
        #region 日期控件
        /// <summary>
        /// 设置时间格式有效显示，如果大于默认时间，赋值给控件；否则不赋值
        /// </summary>
        /// <param name="control">DateEdit控件对象</param>
        /// <param name="dateTime">日期对象</param>
        public static void SetDateTime(this DateEdit control, DateTime dateTime)
        {
            if (dateTime > Convert.ToDateTime("1900-1-1"))
            {
                control.DateTime = dateTime;
            }
            else
            {
                control.Text = "";
            }
        }

        /// <summary>
        /// 获取时间的显示内容，如果小于默认时间（1900-1-1），则为空
        /// </summary>
        /// <param name="dateTime">时间对象</param>
        /// <param name="formatString">默认格式为yyyy-MM-dd</param>
        /// <returns></returns>
        public static string GetDateTimeString(this DateTime dateTime, string formatString = "yyyy-MM-dd")
        {
            string result = "";
            if (dateTime > Convert.ToDateTime("1900-1-1"))
            {
                result = dateTime.ToString(formatString);
            }
            return result;
        } 
        #endregion
        
        #region ComboBoxEdit控件
        /// <summary>
        /// 获取下拉列表的值
        /// </summary>
        /// <param name="combo">下拉列表</param>
        /// <returns></returns>
        public static string GetComboBoxValue(this ComboBoxEdit combo)
        {
            CListItem item = combo.SelectedItem as CListItem;
            if (item != null)
            {
                return item.Value;
            }
            else
            {
                return "";
            }
        }

        /// <summary>
        /// 设置下拉列表选中指定的值
        /// </summary>
        /// <param name="combo">下拉列表</param>
        /// <param name="value">指定的CListItem中的值</param>
        public static void SetComboBoxItem(this ComboBoxEdit combo, string value)
        {
            for (int i = 0; i < combo.Properties.Items.Count; i++)
            {
                CListItem item = combo.Properties.Items[i] as CListItem;
                if (item != null && item.Value == value)
                {
                    combo.SelectedIndex = i;
                }
            }
        }

        #endregion

        /// <summary>
        /// 设置单选框组的选定内容
        /// </summary>
        /// <param name="radGroup">单选框组</param>
        /// <param name="value">选定内容</param>
        public static void SetRaidioGroupItem(this RadioGroup radGroup, string value)
        {
            radGroup.SelectedIndex = radGroup.Properties.Items.GetItemIndexByValue(value);
        }

        /// <summary>
        /// 用于生成SQL IN中的字符串
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string CreateSQLInCondition(this List<string> source)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(",");
            foreach (var s in source)
            {
                sb.Append("'")
                  .Append(s)
                  .Append("',");
            }
            return sb.ToString().Trim(new char[] { ',' });
        }
    }
}
