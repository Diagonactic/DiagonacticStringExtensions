using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace Diagonactic.StringExtensions
{
    internal static class Util
    {
        [SuppressMessage("ReSharper", "NotResolvedInText")]
        private static readonly Lazy<ArgumentNullException> s_SourceNull =
           new Lazy<ArgumentNullException>(() => new ArgumentNullException("source"));

        /// <exception cref="ArgumentNullException"><paramref name="source" /> is <see langword="null" />.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void ThrowIfSourceNull(string source)
        {
            if (source == null) throw s_SourceNull.Value;
        }

        
    }
}