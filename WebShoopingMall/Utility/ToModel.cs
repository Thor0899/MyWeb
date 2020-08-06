using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace WebShoopingMall.Utility
{
    public static class ToModel
    {
        public static T DtToModel<T>(this DataRow dr) {
            //获取泛型的真实类型
            Type t = typeof(T);
            //实例化t类型变量
            T md = (T)Activator.CreateInstance(t);
            //获取对象中的熟悉
            var props = t.GetProperties();
            foreach (var prop in props)
            {
                if (dr.Table.Columns.Contains(prop.Name))
                {
                    prop.SetValue(md, dr[prop.Name]);
                }
            }
            return md;
        }
    }
}
