using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Deep.Logging;
using Deep.Memory.Attributes;
using ff14bot;
using ff14bot.Enums;
using GreyMagic;

namespace Deep.Memory
{
    internal class OffsetManager
    {
        internal static void Init()
        {
            var types = typeof(Offsets).GetFields(BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance);

            Parallel.ForEach(types, type =>
                {
                    var pf = new PatternFinder(Core.Memory);
                    if (type.FieldType.IsClass)
                    {
                        var instance = Activator.CreateInstance(type.FieldType);


                        foreach (var field in type.FieldType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance))
                        {
                            var res = ParseField(field, pf);
                            if(field.FieldType == typeof(IntPtr))
                                field.SetValue(instance, res);
                            else
                                field.SetValue(instance, (int)res);
                        }

                        //set the value
                        type.SetValue(null, instance);
                    }
                    else
                    {
                        var res = ParseField(type, pf);
                        if (type.FieldType == typeof(IntPtr))
                            type.SetValue(null, res);
                        else
                            type.SetValue(null, (int)res);
                    }

                }
            );
        }

        private static IntPtr ParseField(FieldInfo field, PatternFinder pf)
        {
            var offset = (OffsetAttribute)Attribute.GetCustomAttributes(field, typeof(OffsetAttribute))
                .FirstOrDefault();
            var valcn = (OffsetValueCN)Attribute.GetCustomAttributes(field, typeof(OffsetValueCN))
                .FirstOrDefault();
            var valna = (OffsetValueNA)Attribute.GetCustomAttributes(field, typeof(OffsetValueNA))
                .FirstOrDefault();
            
            IntPtr results;

            if (Constants.Lang == Language.Chn)
            {
                if (valcn != null)
                    return (IntPtr)valcn.Value;
                if (offset == null)
                {
                    return IntPtr.Zero;
                }
                lock (Core.Memory)
                {
                    results = pf.Find(offset.PatternCN);
                }
            }
            else
            {
                if (valna != null)
                    return (IntPtr)valna.Value;
                if (offset == null)
                {
                    return IntPtr.Zero;
                }
                lock (Core.Memory)
                {
                    results = pf.Find(offset.Pattern);
                }
            }
            
            Logger.Info("[OffsetManager][{0:,27}] {1}", field.Name, results.ToString("X"));

            return results;


        }
        
    }
}