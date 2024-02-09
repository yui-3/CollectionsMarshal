#pragma warning disable 8500

using System.Runtime.CompilerServices;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace System.Runtime.InteropServices
{
    public static class CollectionsMarshal
    {
        public static unsafe Span<T> AsSpan<T>(List<T>? list)
        {
            if (list is null)
                return default;
            return new(((StrongBox<T[]>*)&list)->Value, 0, list.Count);
        }
    }
}

namespace System.Collections.Generic
{
    public static class ListExtensions
    {
        public static Span<T> AsSpan<T>(this List<T> list)
        {
            return CollectionsMarshal.AsSpan(list);
        }
    }
}