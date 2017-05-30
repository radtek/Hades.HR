using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hades.HR.UI
{
    using DevExpress.XtraEditors;
    using Hades.Dictionary.Facade;
    using Hades.Framework.Commons;
    using Hades.Framework.ControlUtil.Facade;

    /// <summary>
    /// 控件工具类
    /// </summary>
    internal class ControlUtil
    {
        /// <summary>
        /// 绑定下拉列表控件为指定的数据字典列表
        /// </summary>
        /// <param name="combo">下拉列表控件</param>
        /// <param name="dictTypeName">数据字典类型名称</param>
        public static void BindDictItems(ComboBoxEdit combo, string dictTypeName)
        {
            combo.Properties.Items.Clear();
            Dictionary<string, string> dict = CallerFactory<IDictDataService>.Instance.GetDictByDictType(dictTypeName);
            if (dict != null)
            {
                foreach (string key in dict.Keys)
                {
                    combo.Properties.Items.Add(new CListItem(key, dict[key]));
                }
            }
        }

        /// <summary>
        /// 绑定下拉列表控件为指定的数据字典列表
        /// </summary>
        /// <param name="combo">下拉列表控件</param>
        /// <param name="dictCode">数据字典编码</param>
        public static void BindDictToCombo(ComboBoxEdit combo, string dictCode)
        {
            combo.Properties.Items.Clear();

            var data = CallerFactory<IDictDataService>.Instance.GetDictListItemByCode(dictCode);

            if (data != null)
            {
                foreach(var item in data)
                {
                    combo.Properties.Items.Add(new CListItem(item.Text, item.Value));
                }
            }
        }
    }
}
