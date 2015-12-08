using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using JetBrains.Annotations;

namespace Diagonactic.StringExtensions
{
    /// <summary>
    /// The direction to search for a value.
    /// </summary>
    public enum SearchDirection
    {
        /// <summary>
        /// Search from the beginning (left hand) side of the string
        /// </summary>
        FromLeft = 0,
        /// <summary>
        /// Search from the end (rigt hand) side of the string
        /// </summary>
        FromRight = 1
    }

    /// <summary>
    /// String helper methods for non-conversion related extension methods
    /// </summary>
    public static class StringExtensions
    {

        /// <summary>
        ///     Determines if string is <see langword="null" />, <see cref="string.Empty" /> or contains only whitespace characters. Directly calls
        ///     <see cref="string.IsNullOrWhiteSpace" />
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns>
        ///     <see langword="true" /> if the string is is <see langword="null" />, <see cref="string.Empty" /> or contains only whitespace characters; otherwise
        ///     <see langword="false" />.
        /// </returns>
        public static bool IsNullOrWhitespace([CanBeNull] this string source)
        {
            return string.IsNullOrWhiteSpace(source);
        }

        /// <summary>Determines if string is <see langword="null" /> or <see cref="string.Empty" />. Directly calls <see cref="string.IsNullOrEmpty" />
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns><see langword="true" /> if the string is is <see langword="null" /> or <see cref="string.Empty" />; otherwise <see langword="false" />.</returns>
        public static bool IsNullOrEmpty([CanBeNull] this string source)
        {
            return string.IsNullOrEmpty(source);
        }

        /// <summary>
        /// A fast check to determine if the string is empty
        /// </summary>
        /// <remarks>If <paramref name="source"/> is <see langword="null"/>, this method will return false</remarks>
        /// <param name="source">The string to check if it is empty</param>
        /// <returns><see langword="true"/> if the string is a zero length string; otherwise <see langword="false"/></returns>
        [ContractAnnotation("source:null=>false")]
        public static bool IsEmpty([CanBeNull] this string source)
        {
            if (source?.Length == 0) return true;
            return false;
        }


        /// <summary>Gets the portion of <paramref name="source" /> that is left of the first instance of <paramref name="search" />, not including <paramref name="search" />.</summary>
        /// <remarks>
        ///     If <paramref name="search" /> is not found in <paramref name="source" />, <paramref name="source" /> is returned. If <paramref name="source" /> is <see langword="null" />
        ///     , <see langword="null" /> is returned.
        /// </remarks>
        /// <param name="source">The string to search.</param>
        /// <param name="search">The string to search for.</param>
        /// <param name="direction">The direction to search <paramref name="source" /></param>
        /// <param name="compare">How to search for the string.</param>
        /// <returns><see langword="true" /> if <paramref name="source" /> contains <paramref name="search" /></returns>
        /// <exception cref="ArgumentNullException"><paramref name="search" /> is <see langword="null" />.</exception>
        [ContractAnnotation("source:null=>null")]
        public static string LeftOf([NotNull] this string source, [NotNull] string search, SearchDirection direction = SearchDirection.FromLeft,
                                    StringComparison compare = StringComparison.Ordinal)
        {
            // ReSharper disable once ConditionIsAlwaysTrueOrFalse
            Util.ThrowIfSourceNull(source);
            if (search == null) throw new ArgumentNullException(nameof(search));

            var indexOf = direction == SearchDirection.FromLeft ? source.IndexOf(search, compare) : source.LastIndexOf(search, compare);
            switch (indexOf)
            {
                case -1:
                    return null;
                case 0:
                    return string.Empty;
                default:
                    return source.Substring(0, indexOf);
            }
        }

        /// <summary>Gets the portion of <paramref name="source" /> that is left of the first instance of <paramref name="search" />, not including <paramref name="search" />.</summary>
        /// <remarks>
        ///     If <paramref name="search" /> is not found in <paramref name="source" />, null is returned. If <paramref name="search" /> equals <paramref name="source" /> based on
        ///     <paramref name="compare" /> provided, <see cref="string.Empty" /> is returned.
        /// </remarks>
        /// <param name="source">The string to search.</param>
        /// <param name="search">The string to search for.</param>
        /// <param name="direction">The direction to search <paramref name="source" /></param>
        /// <param name="compare">How to search for the string.</param>
        /// <returns><see langword="true" /> if <paramref name="source" /> contains <paramref name="search" /></returns>
        /// <exception cref="ArgumentNullException"><paramref name="search" /> or <paramref name="source" /> is <see langword="null" />.</exception>
        [CanBeNull]
        public static string RightOf([NotNull] this string source, [NotNull] string search, SearchDirection direction = SearchDirection.FromLeft,
                                     StringComparison compare = StringComparison.Ordinal)
        {
            Util.ThrowIfSourceNull(source);
            if (search == null) throw new ArgumentNullException(nameof(search));

            var indexOf = direction == SearchDirection.FromLeft ? source.IndexOf(search, compare) : source.LastIndexOf(search, compare);
            switch (indexOf)
            {
                case -1:
                    return null;
                default:
                    if (indexOf + search.Length >= source.Length)
                        return string.Empty;
                    return source.Substring(indexOf + search.Length);
            }
        }

        /// <summary>Returns <paramref name="source" /> with characters in reverse order.</summary>
        /// <param name="source">The string to reverse</param>
        /// <returns>The reverse of <paramref name="source" /></returns>
        /// <exception cref="ArgumentNullException"><paramref name="source" /> is <see langword="null" />.</exception>
        public static string Reverse([NotNull] this string source)
        {
            Util.ThrowIfSourceNull(source);
            if (source.Length == 0) return source;
            var cs = source.ToCharArray();
            Array.Reverse(cs);
            return new string(cs);
        }

        /// <summary>
        ///     Returns a string to the right of <paramref name="index" /> (including <paramref name="index" />), or <see langword="null" /> if the index does not occur within the
        ///     string.
        /// </summary>
        /// <remarks>
        ///     If index doesn't occur within the string but is greater than 0, null is returned.  Since a value below 0 is always invalid for an index operation on a string, an
        ///     exception is thrown if the value is less than 0
        /// </remarks>
        /// <param name="source">The source string.</param>
        /// <param name="index">The index to get the string to the right of from <paramref name="source" />.</param>
        /// <exception cref="ArgumentNullException">source is <see langword="null" />.</exception>
        /// <returns>A string to the right of <paramref name="index" /> (including <paramref name="index" />), or <see langword="null" /> if the index does not occur within the string.</returns>
        /// <exception cref="ArgumentException">An index of less than 0 is not valid</exception>
        public static string RightOfIndex([NotNull] this string source, int index)
        {
            Util.ThrowIfSourceNull(source);
            if (index < 0) throw new ArgumentException("An index of less than 0 is not valid", nameof(index));
            if (index >= source.Length) return null;

            return source.Substring(index);
        }

        /// <summary>
        ///     Returns a string to the left of <paramref name="index" /> (including <paramref name="index" />), or <paramref name="source" /> if the index is greater than the length of
        ///     the string.
        /// </summary>
        /// <remarks>
        ///     If index doesn't occur within the string but is greater than 0, null is returned.  Since a value below 0 is always invalid for an index operation on a string, an
        ///     exception is thrown if the value is less than 0
        /// </remarks>
        /// <param name="source">The source string.</param>
        /// <param name="index">The index to get the string to the left of from <paramref name="source" />.</param>
        /// <exception cref="ArgumentNullException">source is <see langword="null" />.</exception>
        /// <returns>
        ///     A string to the left of <paramref name="index" /> (including <paramref name="index" />), or <paramref name="source" /> if the index is greater than the length of the
        ///     string.
        /// </returns>
        /// <exception cref="ArgumentException">An index of less than 0 is not valid</exception>
        public static string LeftOfIndex([NotNull] this string source, int index)
        {
            Util.ThrowIfSourceNull(source);
            if (index < 0) throw new ArgumentException("An index of less than 0 is not valid", nameof(index));
            if (index >= source.Length) return source;

            return source.Substring(0, index);
        }

        /// <summary>Determines whether <paramref name="source" /> contains <paramref name="search" />.</summary>
        /// <param name="source">The string to search.</param>
        /// <param name="search">The string to search for.</param>
        /// <param name="compare">How to search for the string.</param>
        /// <returns><see langword="true" /> if <paramref name="source" /> contains <paramref name="search" /></returns>
        /// <exception cref="ArgumentNullException"><paramref name="search" /> is <see langword="null" />.</exception>
        public static bool Contains([CanBeNull] this string source, [NotNull] string search, StringComparison compare = StringComparison.Ordinal)
        {
            if (search == null) throw new ArgumentNullException(nameof(search));
            if (source == null) return false;

            return source.IndexOf(search, compare) != -1;
        }

        /// <summary>Gets the <see cref="StringComparer" /> that corresponds to <paramref name="comparison" />.</summary>
        /// <param name="comparison">The <see cref="StringComparison" /> <see langword="enum" /> to get the <see cref="StringComparer" /> value for.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">Invalid value for <paramref name="comparison" /></exception>
        public static StringComparer ToComparer(this StringComparison comparison)
        {
            switch (comparison)
            {
                case StringComparison.OrdinalIgnoreCase:
                    return StringComparer.OrdinalIgnoreCase;
                case StringComparison.CurrentCulture:
                    return StringComparer.CurrentCulture;
                case StringComparison.CurrentCultureIgnoreCase:
                    return StringComparer.CurrentCulture;
                case StringComparison.InvariantCulture:
                    return StringComparer.InvariantCulture;
                case StringComparison.InvariantCultureIgnoreCase:
                    return StringComparer.InvariantCultureIgnoreCase;
                case StringComparison.Ordinal:
                    return StringComparer.Ordinal;
                default:
                    throw new ArgumentException("Invalid value", nameof(comparison));
            }
        }
    }
}