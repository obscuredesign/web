using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace ObscureDesign.Processors
{
    // Simply for the lulz and F# feel everything implemented as expressions
    public static class ProcessorHelper
    {
        #region Extension methods

        public static string GetProcessorDisplayName(this Type processorType) =>
            processorType.GetTypeInfo().GetCustomAttribute<ProcessorAttribute>(inherit: false)?.Name ??
            processorType.Name;

        private static IEnumerable<Type> ImplementsInterface<T>(this IEnumerable<Type> source, bool throwOnMismatch = false) =>
            source.Where(s =>
            {
                if (s.GetInterfaces().Contains(typeof(T)))
                    return true;
                else if (!throwOnMismatch)
                    return false;
                else
                    throw new ArgumentException(); // I really need throw expression
            });

        #endregion

        private static IEnumerable<Type> GetProcessors<T>() => typeof(ProcessorHelper).GetTypeInfo().Assembly
            .GetTypes()
            .ImplementsInterface<T>()
            .Where(t => t.GetInterfaces()
                    .Where(iface => iface.IsConstructedGenericType)
                    .Any(iface => iface.GetGenericTypeDefinition() == (typeof(IProcessor<>)))
            )
            .Where(t => t.GetTypeInfo().GetCustomAttribute<ProcessorAttribute>(inherit: false) != null);
        
        public static Type[] GetPreprocessors() => GetProcessors<IPreprocessor>().ToArray();
        public static Type[] GetPostprocessors() => GetProcessors<IPostprocessor>().ToArray();

        private static Type CreateProcessor<T>(IEnumerable<string> processorAQNs) => processorAQNs
            .Select(pp => Type.GetType(pp, throwOnError: true, ignoreCase: true))
            .ImplementsInterface<T>(throwOnMismatch: true) //security thingy
            .Aggregate(typeof(CopyContent), (current, next) => next.MakeGenericType(current));

        public static Type CreatePreprocessor(IEnumerable<string> processorAQNs) => CreateProcessor<IPreprocessor>(processorAQNs);
        public static Type CreatePostprocessor(IEnumerable<string> processorAQNs) => CreateProcessor<IPostprocessor>(processorAQNs);

        public static IEnumerable<string> DestructProcessor(Type processor)
        {
            var types = new List<Type>();
            Type current = processor;
            while (current != typeof(CopyContent))
            {
                types.Add(current.GetGenericTypeDefinition());
                current = current.GetGenericArguments()[0];
            }
            return types.Select(t => t.AssemblyQualifiedName).ToList();
        }
    }
}
