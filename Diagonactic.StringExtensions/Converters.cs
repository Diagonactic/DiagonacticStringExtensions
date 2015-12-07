using System;
using System.Globalization;
using JetBrains.Annotations;

namespace Diagonactic.StringExtensions.ExtendedConverters{
	public static class ExtendedNumericConversionExtensions {

		/// <summary>Shortcut for <see cref="byte.TryParse(string, out byte)" /> with the out value discarded.</summary>
        /// <remarks>
        ///     It would be inefficient to use this to test before parsing, use <see cref="TryParseToByte(string)" /> and check that the returned value is null or <see cref="TryParseToByte(string, out byte)" /> if
        ///     you intend to get the value.
        /// </remarks>
        /// <param name="source">The string to parse to an integer</param>
        /// <returns></returns>
		[ContractAnnotation("source:null=>false")]
        public static bool IsToByte([CanBeNull]this string source)
        {
            if (source.IsNullOrWhitespace()) return false;

            byte unused;
            return byte.TryParse(source, out unused);
        }
		
		/// <summary>Directly calls <see cref="byte.TryParse(string, out byte)" />, and boxes the return into a <see cref="Nullable" /> <see cref="int" />.</summary>
        /// <param name="source">A string containing a number to convert</param>
        /// <returns>The converted number or <see langword="null" /> if the conversion failed</returns>
        public static byte? TryParseToByte([NotNull] this string source)
        {
            Util.ThrowIfSourceNull(source);
            byte result;
            return byte.TryParse(source, out result) ? result as byte? : null;
        }
		
		
        /// <summary>Directly calls <see cref="byte.TryParse(string, out byte)" />.</summary>
        /// <param name="source">A string containing a number to convert</param>
        /// <param name="result">The result of the conversion operation</param>
        /// <returns><see langword="true" /> if the conversion succeeded; otherwise <see langword="false" /></returns>
        public static bool TryParseToByte([NotNull] this string source, out byte result) => byte.TryParse(source, out result);
		
        /// <summary>Shortcut for <see cref="byte.TryParse(string, NumberStyles, IFormatProvider, out byte)" /> with the out value discarded.</summary>
        /// <remarks>
        ///     It would be inefficient to use this to test before parsing, use <see cref="TryParseToByte(string)" /> and check that the returned value is null or <see cref="TryParseToByte(string, out byte)" /> if
        ///     you intend to get the value.
        /// </remarks>
        /// <param name="source">The string to parse to an integer</param>
		/// <param name="formatProvider">An object that supplies culture-specific formatting information about <paramref name="source"/></param>
        /// <param name="styles">A bitwise combination of enumeration values that indicates the style elements that can be present in s. A typical value to specify is <see cref="NumberStyles.Integer"/>.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"><paramref name="formatProvider"/> is <see langword="null" />.</exception>
		[ContractAnnotation("source:null=>false; formatProvider:null=>halt")]
        public static bool IsToByte([CanBeNull] this string source, [NotNull] IFormatProvider formatProvider, NumberStyles styles = NumberStyles.Integer)
        {
            if (string.IsNullOrWhiteSpace(source)) return false;
            if (formatProvider == null) throw new ArgumentNullException(nameof(formatProvider));

            byte unused;
            return byte.TryParse(source, styles, formatProvider, out unused);
        }		

        /// <summary>Directly calls <see cref="byte.TryParse(string, out byte)" />, and boxes the return into a <see cref="Nullable" /> <see cref="int" />.</summary>
        /// <param name="source">A string containing a number to convert</param>
        /// <param name="formatProvider">An object that supplies culture-specific formatting information about <paramref name="source" /></param>
        /// <param name="styles">
        ///     A bitwise combination of enumeration values that indicates the style elements that can be present in s. A typical value to specify is
        ///     <see cref="NumberStyles.Integer" />.
        /// </param>
        /// <returns>The converted number or <see langword="null" /> if the conversion failed</returns>
        public static byte? TryParseToByte([NotNull]this string source, [NotNull] IFormatProvider formatProvider, NumberStyles styles = NumberStyles.Integer)
        {
            Util.ThrowIfSourceNull(source);
            byte result;
            return byte.TryParse(source, styles, formatProvider, out result) ? result as byte? : null;
        }

        /// <summary>Directly calls <see cref="byte.TryParse(string, out byte)" />.</summary>
        /// <param name="source">A string containing a number to convert</param>
        /// <param name="result">The result of the conversion operation if it was successful</param>
        /// <param name="formatProvider">An object that supplies culture-specific formatting information about <paramref name="source" /></param>
        /// <param name="styles">
        ///     A bitwise combination of enumeration values that indicates the style elements that can be present in s. A typical value to specify is
        ///     <see cref="NumberStyles.Integer" />.
        /// </param>
        /// <returns><see langword="true" /> if the conversion succeeded; otherwise <see langword="false" /></returns>
        public static bool TryParseToByte([NotNull] this string source, IFormatProvider formatProvider, out byte result, NumberStyles styles = NumberStyles.Integer)
            => byte.TryParse(source, styles, formatProvider, out result);
		

		/// <summary>Shortcut for <see cref="short.TryParse(string, out short)" /> with the out value discarded.</summary>
        /// <remarks>
        ///     It would be inefficient to use this to test before parsing, use <see cref="TryParseToShort(string)" /> and check that the returned value is null or <see cref="TryParseToShort(string, out short)" /> if
        ///     you intend to get the value.
        /// </remarks>
        /// <param name="source">The string to parse to an integer</param>
        /// <returns></returns>
		[ContractAnnotation("source:null=>false")]
        public static bool IsToShort([CanBeNull]this string source)
        {
            if (source.IsNullOrWhitespace()) return false;

            short unused;
            return short.TryParse(source, out unused);
        }
		
		/// <summary>Directly calls <see cref="short.TryParse(string, out short)" />, and boxes the return into a <see cref="Nullable" /> <see cref="int" />.</summary>
        /// <param name="source">A string containing a number to convert</param>
        /// <returns>The converted number or <see langword="null" /> if the conversion failed</returns>
        public static short? TryParseToShort([NotNull] this string source)
        {
            Util.ThrowIfSourceNull(source);
            short result;
            return short.TryParse(source, out result) ? result as short? : null;
        }
		
		
        /// <summary>Directly calls <see cref="short.TryParse(string, out short)" />.</summary>
        /// <param name="source">A string containing a number to convert</param>
        /// <param name="result">The result of the conversion operation</param>
        /// <returns><see langword="true" /> if the conversion succeeded; otherwise <see langword="false" /></returns>
        public static bool TryParseToShort([NotNull] this string source, out short result) => short.TryParse(source, out result);
		
        /// <summary>Shortcut for <see cref="short.TryParse(string, NumberStyles, IFormatProvider, out short)" /> with the out value discarded.</summary>
        /// <remarks>
        ///     It would be inefficient to use this to test before parsing, use <see cref="TryParseToShort(string)" /> and check that the returned value is null or <see cref="TryParseToShort(string, out short)" /> if
        ///     you intend to get the value.
        /// </remarks>
        /// <param name="source">The string to parse to an integer</param>
		/// <param name="formatProvider">An object that supplies culture-specific formatting information about <paramref name="source"/></param>
        /// <param name="styles">A bitwise combination of enumeration values that indicates the style elements that can be present in s. A typical value to specify is <see cref="NumberStyles.Integer"/>.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"><paramref name="formatProvider"/> is <see langword="null" />.</exception>
		[ContractAnnotation("source:null=>false; formatProvider:null=>halt")]
        public static bool IsToShort([CanBeNull] this string source, [NotNull] IFormatProvider formatProvider, NumberStyles styles = NumberStyles.Integer)
        {
            if (string.IsNullOrWhiteSpace(source)) return false;
            if (formatProvider == null) throw new ArgumentNullException(nameof(formatProvider));

            short unused;
            return short.TryParse(source, styles, formatProvider, out unused);
        }		

        /// <summary>Directly calls <see cref="short.TryParse(string, out short)" />, and boxes the return into a <see cref="Nullable" /> <see cref="int" />.</summary>
        /// <param name="source">A string containing a number to convert</param>
        /// <param name="formatProvider">An object that supplies culture-specific formatting information about <paramref name="source" /></param>
        /// <param name="styles">
        ///     A bitwise combination of enumeration values that indicates the style elements that can be present in s. A typical value to specify is
        ///     <see cref="NumberStyles.Integer" />.
        /// </param>
        /// <returns>The converted number or <see langword="null" /> if the conversion failed</returns>
        public static short? TryParseToShort([NotNull]this string source, [NotNull] IFormatProvider formatProvider, NumberStyles styles = NumberStyles.Integer)
        {
            Util.ThrowIfSourceNull(source);
            short result;
            return short.TryParse(source, styles, formatProvider, out result) ? result as short? : null;
        }

        /// <summary>Directly calls <see cref="short.TryParse(string, out short)" />.</summary>
        /// <param name="source">A string containing a number to convert</param>
        /// <param name="result">The result of the conversion operation if it was successful</param>
        /// <param name="formatProvider">An object that supplies culture-specific formatting information about <paramref name="source" /></param>
        /// <param name="styles">
        ///     A bitwise combination of enumeration values that indicates the style elements that can be present in s. A typical value to specify is
        ///     <see cref="NumberStyles.Integer" />.
        /// </param>
        /// <returns><see langword="true" /> if the conversion succeeded; otherwise <see langword="false" /></returns>
        public static bool TryParseToShort([NotNull] this string source, IFormatProvider formatProvider, out short result, NumberStyles styles = NumberStyles.Integer)
            => short.TryParse(source, styles, formatProvider, out result);
		

		/// <summary>Shortcut for <see cref="SByte.TryParse(string, out SByte)" /> with the out value discarded.</summary>
        /// <remarks>
        ///     It would be inefficient to use this to test before parsing, use <see cref="TryParseToSByte(string)" /> and check that the returned value is null or <see cref="TryParseToSByte(string, out SByte)" /> if
        ///     you intend to get the value.
        /// </remarks>
        /// <param name="source">The string to parse to an integer</param>
        /// <returns></returns>
		[ContractAnnotation("source:null=>false")]
        public static bool IsToSByte([CanBeNull]this string source)
        {
            if (source.IsNullOrWhitespace()) return false;

            SByte unused;
            return SByte.TryParse(source, out unused);
        }
		
		/// <summary>Directly calls <see cref="SByte.TryParse(string, out SByte)" />, and boxes the return into a <see cref="Nullable" /> <see cref="int" />.</summary>
        /// <param name="source">A string containing a number to convert</param>
        /// <returns>The converted number or <see langword="null" /> if the conversion failed</returns>
        public static SByte? TryParseToSByte([NotNull] this string source)
        {
            Util.ThrowIfSourceNull(source);
            SByte result;
            return SByte.TryParse(source, out result) ? result as SByte? : null;
        }
		
		
        /// <summary>Directly calls <see cref="SByte.TryParse(string, out SByte)" />.</summary>
        /// <param name="source">A string containing a number to convert</param>
        /// <param name="result">The result of the conversion operation</param>
        /// <returns><see langword="true" /> if the conversion succeeded; otherwise <see langword="false" /></returns>
        public static bool TryParseToSByte([NotNull] this string source, out SByte result) => SByte.TryParse(source, out result);
		
        /// <summary>Shortcut for <see cref="SByte.TryParse(string, NumberStyles, IFormatProvider, out SByte)" /> with the out value discarded.</summary>
        /// <remarks>
        ///     It would be inefficient to use this to test before parsing, use <see cref="TryParseToSByte(string)" /> and check that the returned value is null or <see cref="TryParseToSByte(string, out SByte)" /> if
        ///     you intend to get the value.
        /// </remarks>
        /// <param name="source">The string to parse to an integer</param>
		/// <param name="formatProvider">An object that supplies culture-specific formatting information about <paramref name="source"/></param>
        /// <param name="styles">A bitwise combination of enumeration values that indicates the style elements that can be present in s. A typical value to specify is <see cref="NumberStyles.Integer"/>.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"><paramref name="formatProvider"/> is <see langword="null" />.</exception>
		[ContractAnnotation("source:null=>false; formatProvider:null=>halt")]
        public static bool IsToSByte([CanBeNull] this string source, [NotNull] IFormatProvider formatProvider, NumberStyles styles = NumberStyles.Integer)
        {
            if (string.IsNullOrWhiteSpace(source)) return false;
            if (formatProvider == null) throw new ArgumentNullException(nameof(formatProvider));

            SByte unused;
            return SByte.TryParse(source, styles, formatProvider, out unused);
        }		

        /// <summary>Directly calls <see cref="SByte.TryParse(string, out SByte)" />, and boxes the return into a <see cref="Nullable" /> <see cref="int" />.</summary>
        /// <param name="source">A string containing a number to convert</param>
        /// <param name="formatProvider">An object that supplies culture-specific formatting information about <paramref name="source" /></param>
        /// <param name="styles">
        ///     A bitwise combination of enumeration values that indicates the style elements that can be present in s. A typical value to specify is
        ///     <see cref="NumberStyles.Integer" />.
        /// </param>
        /// <returns>The converted number or <see langword="null" /> if the conversion failed</returns>
        public static SByte? TryParseToSByte([NotNull]this string source, [NotNull] IFormatProvider formatProvider, NumberStyles styles = NumberStyles.Integer)
        {
            Util.ThrowIfSourceNull(source);
            SByte result;
            return SByte.TryParse(source, styles, formatProvider, out result) ? result as SByte? : null;
        }

        /// <summary>Directly calls <see cref="SByte.TryParse(string, out SByte)" />.</summary>
        /// <param name="source">A string containing a number to convert</param>
        /// <param name="result">The result of the conversion operation if it was successful</param>
        /// <param name="formatProvider">An object that supplies culture-specific formatting information about <paramref name="source" /></param>
        /// <param name="styles">
        ///     A bitwise combination of enumeration values that indicates the style elements that can be present in s. A typical value to specify is
        ///     <see cref="NumberStyles.Integer" />.
        /// </param>
        /// <returns><see langword="true" /> if the conversion succeeded; otherwise <see langword="false" /></returns>
        public static bool TryParseToSByte([NotNull] this string source, IFormatProvider formatProvider, out SByte result, NumberStyles styles = NumberStyles.Integer)
            => SByte.TryParse(source, styles, formatProvider, out result);
		
	}

}

namespace Diagonactic.StringExtensions
{
	public static class NumericConversionExtensions {
	

		/// <summary>Shortcut for <see cref="bool.TryParse(string, out bool)" /> with the out value discarded.</summary>
        /// <remarks>
        ///     It would be inefficient to use this to test before parsing, use <see cref="TryParseBool(string)" /> and check that the returned value is null or <see cref="TryParseBool(string, out bool)" /> if
        ///     you intend to get the value.
        /// </remarks>
        /// <param name="source">The string to parse to an integer</param>
        /// <returns></returns>
		[ContractAnnotation("source:null=>false")]
        public static bool IsBool([CanBeNull]this string source)
        {
            if (source.IsNullOrWhitespace()) return false;

            bool unused;
            return bool.TryParse(source, out unused);
        }
		
		/// <summary>Directly calls <see cref="bool.TryParse(string, out bool)" />, and boxes the return into a <see cref="Nullable" /> <see cref="int" />.</summary>
        /// <param name="source">A string containing a number to convert</param>
        /// <returns>The converted number or <see langword="null" /> if the conversion failed</returns>
        public static bool? TryParseBool([NotNull] this string source)
        {
            Util.ThrowIfSourceNull(source);
            bool result;
            return bool.TryParse(source, out result) ? result as bool? : null;
        }
		
		
        /// <summary>Directly calls <see cref="bool.TryParse(string, out bool)" />.</summary>
        /// <param name="source">A string containing a number to convert</param>
        /// <param name="result">The result of the conversion operation</param>
        /// <returns><see langword="true" /> if the conversion succeeded; otherwise <see langword="false" /></returns>
        public static bool TryParseBool([NotNull] this string source, out bool result) => bool.TryParse(source, out result);
		

		/// <summary>Shortcut for <see cref="long.TryParse(string, out long)" /> with the out value discarded.</summary>
        /// <remarks>
        ///     It would be inefficient to use this to test before parsing, use <see cref="TryParseLong(string)" /> and check that the returned value is null or <see cref="TryParseLong(string, out long)" /> if
        ///     you intend to get the value.
        /// </remarks>
        /// <param name="source">The string to parse to an integer</param>
        /// <returns></returns>
		[ContractAnnotation("source:null=>false")]
        public static bool IsLong([CanBeNull]this string source)
        {
            if (source.IsNullOrWhitespace()) return false;

            long unused;
            return long.TryParse(source, out unused);
        }
		
		/// <summary>Directly calls <see cref="long.TryParse(string, out long)" />, and boxes the return into a <see cref="Nullable" /> <see cref="int" />.</summary>
        /// <param name="source">A string containing a number to convert</param>
        /// <returns>The converted number or <see langword="null" /> if the conversion failed</returns>
        public static long? TryParseLong([NotNull] this string source)
        {
            Util.ThrowIfSourceNull(source);
            long result;
            return long.TryParse(source, out result) ? result as long? : null;
        }
		
		
        /// <summary>Directly calls <see cref="long.TryParse(string, out long)" />.</summary>
        /// <param name="source">A string containing a number to convert</param>
        /// <param name="result">The result of the conversion operation</param>
        /// <returns><see langword="true" /> if the conversion succeeded; otherwise <see langword="false" /></returns>
        public static bool TryParseLong([NotNull] this string source, out long result) => long.TryParse(source, out result);
		
        /// <summary>Shortcut for <see cref="long.TryParse(string, NumberStyles, IFormatProvider, out long)" /> with the out value discarded.</summary>
        /// <remarks>
        ///     It would be inefficient to use this to test before parsing, use <see cref="TryParseLong(string)" /> and check that the returned value is null or <see cref="TryParseLong(string, out long)" /> if
        ///     you intend to get the value.
        /// </remarks>
        /// <param name="source">The string to parse to an integer</param>
		/// <param name="formatProvider">An object that supplies culture-specific formatting information about <paramref name="source"/></param>
        /// <param name="styles">A bitwise combination of enumeration values that indicates the style elements that can be present in s. A typical value to specify is <see cref="NumberStyles.Integer"/>.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"><paramref name="formatProvider"/> is <see langword="null" />.</exception>
		[ContractAnnotation("source:null=>false; formatProvider:null=>halt")]
        public static bool IsLong([CanBeNull] this string source, [NotNull] IFormatProvider formatProvider, NumberStyles styles = NumberStyles.Integer)
        {
            if (string.IsNullOrWhiteSpace(source)) return false;
            if (formatProvider == null) throw new ArgumentNullException(nameof(formatProvider));

            long unused;
            return long.TryParse(source, styles, formatProvider, out unused);
        }		

        /// <summary>Directly calls <see cref="long.TryParse(string, out long)" />, and boxes the return into a <see cref="Nullable" /> <see cref="int" />.</summary>
        /// <param name="source">A string containing a number to convert</param>
        /// <param name="formatProvider">An object that supplies culture-specific formatting information about <paramref name="source" /></param>
        /// <param name="styles">
        ///     A bitwise combination of enumeration values that indicates the style elements that can be present in s. A typical value to specify is
        ///     <see cref="NumberStyles.Integer" />.
        /// </param>
        /// <returns>The converted number or <see langword="null" /> if the conversion failed</returns>
        public static long? TryParseLong([NotNull]this string source, [NotNull] IFormatProvider formatProvider, NumberStyles styles = NumberStyles.Integer)
        {
            Util.ThrowIfSourceNull(source);
            long result;
            return long.TryParse(source, styles, formatProvider, out result) ? result as long? : null;
        }

        /// <summary>Directly calls <see cref="long.TryParse(string, out long)" />.</summary>
        /// <param name="source">A string containing a number to convert</param>
        /// <param name="result">The result of the conversion operation if it was successful</param>
        /// <param name="formatProvider">An object that supplies culture-specific formatting information about <paramref name="source" /></param>
        /// <param name="styles">
        ///     A bitwise combination of enumeration values that indicates the style elements that can be present in s. A typical value to specify is
        ///     <see cref="NumberStyles.Integer" />.
        /// </param>
        /// <returns><see langword="true" /> if the conversion succeeded; otherwise <see langword="false" /></returns>
        public static bool TryParseLong([NotNull] this string source, IFormatProvider formatProvider, out long result, NumberStyles styles = NumberStyles.Integer)
            => long.TryParse(source, styles, formatProvider, out result);
		

		/// <summary>Shortcut for <see cref="DateTime.TryParse(string, out DateTime)" /> with the out value discarded.</summary>
        /// <remarks>
        ///     It would be inefficient to use this to test before parsing, use <see cref="TryParseDateTime(string)" /> and check that the returned value is null or <see cref="TryParseDateTime(string, out DateTime)" /> if
        ///     you intend to get the value.
        /// </remarks>
        /// <param name="source">The string to parse to an integer</param>
        /// <returns></returns>
		[ContractAnnotation("source:null=>false")]
        public static bool IsDateTime([CanBeNull]this string source)
        {
            if (source.IsNullOrWhitespace()) return false;

            DateTime unused;
            return DateTime.TryParse(source, out unused);
        }
		
		/// <summary>Directly calls <see cref="DateTime.TryParse(string, out DateTime)" />, and boxes the return into a <see cref="Nullable" /> <see cref="int" />.</summary>
        /// <param name="source">A string containing a number to convert</param>
        /// <returns>The converted number or <see langword="null" /> if the conversion failed</returns>
        public static DateTime? TryParseDateTime([NotNull] this string source)
        {
            Util.ThrowIfSourceNull(source);
            DateTime result;
            return DateTime.TryParse(source, out result) ? result as DateTime? : null;
        }
		
		
        /// <summary>Directly calls <see cref="DateTime.TryParse(string, out DateTime)" />.</summary>
        /// <param name="source">A string containing a number to convert</param>
        /// <param name="result">The result of the conversion operation</param>
        /// <returns><see langword="true" /> if the conversion succeeded; otherwise <see langword="false" /></returns>
        public static bool TryParseDateTime([NotNull] this string source, out DateTime result) => DateTime.TryParse(source, out result);
		
        /// <summary>Shortcut for <see cref="DateTime.TryParse(string, IFormatProvider, DateTimeStyles, out DateTime)" /> with the out value discarded.</summary>
        /// <remarks>
        ///     It would be inefficient to use this to test before parsing, use <see cref="TryParseDateTime(string)" /> and check that the returned value is null or <see cref="TryParseDateTime(string, out DateTime)" /> if
        ///     you intend to get the value.
        /// </remarks>
        /// <param name="source">The string to parse to an integer</param>
		/// <param name="formatProvider">An object that supplies culture-specific formatting information about <paramref name="source"/></param>
        /// <param name="styles">A bitwise combination of enumeration values that indicates the style elements that can be present in s. A typical value to specify is <see cref="DateTimeStyles.None"/>.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"><paramref name="formatProvider"/> is <see langword="null" />.</exception>
		[ContractAnnotation("source:null=>false; formatProvider:null=>halt")]
        public static bool IsDateTime([CanBeNull] this string source, [NotNull] IFormatProvider formatProvider, DateTimeStyles styles = DateTimeStyles.None)
        {
            if (string.IsNullOrWhiteSpace(source)) return false;
            if (formatProvider == null) throw new ArgumentNullException(nameof(formatProvider));

            DateTime unused;
            return DateTime.TryParse(source, formatProvider, styles, out unused);
        }		

        /// <summary>Directly calls <see cref="DateTime.TryParse(string, out DateTime)" />, and boxes the return into a <see cref="Nullable" /> <see cref="int" />.</summary>
        /// <param name="source">A string containing a number to convert</param>
        /// <param name="formatProvider">An object that supplies culture-specific formatting information about <paramref name="source" /></param>
        /// <param name="styles">
        ///     A bitwise combination of enumeration values that indicates the style elements that can be present in s. A typical value to specify is
        ///     <see cref="DateTimeStyles.None" />.
        /// </param>
        /// <returns>The converted number or <see langword="null" /> if the conversion failed</returns>
        public static DateTime? TryParseDateTime([NotNull]this string source, [NotNull] IFormatProvider formatProvider, DateTimeStyles styles = DateTimeStyles.None)
        {
            Util.ThrowIfSourceNull(source);
            DateTime result;
            return DateTime.TryParse(source, formatProvider, styles, out result) ? result as DateTime? : null;
        }

        /// <summary>Directly calls <see cref="DateTime.TryParse(string, out DateTime)" />.</summary>
        /// <param name="source">A string containing a number to convert</param>
        /// <param name="result">The result of the conversion operation if it was successful</param>
        /// <param name="formatProvider">An object that supplies culture-specific formatting information about <paramref name="source" /></param>
        /// <param name="styles">
        ///     A bitwise combination of enumeration values that indicates the style elements that can be present in s. A typical value to specify is
        ///     <see cref="DateTimeStyles.None" />.
        /// </param>
        /// <returns><see langword="true" /> if the conversion succeeded; otherwise <see langword="false" /></returns>
        public static bool TryParseDateTime([NotNull] this string source, IFormatProvider formatProvider, out DateTime result, DateTimeStyles styles = DateTimeStyles.None)
            => DateTime.TryParse(source, formatProvider, styles, out result);
		

		/// <summary>Shortcut for <see cref="double.TryParse(string, out double)" /> with the out value discarded.</summary>
        /// <remarks>
        ///     It would be inefficient to use this to test before parsing, use <see cref="TryParseDouble(string)" /> and check that the returned value is null or <see cref="TryParseDouble(string, out double)" /> if
        ///     you intend to get the value.
        /// </remarks>
        /// <param name="source">The string to parse to an integer</param>
        /// <returns></returns>
		[ContractAnnotation("source:null=>false")]
        public static bool IsDouble([CanBeNull]this string source)
        {
            if (source.IsNullOrWhitespace()) return false;

            double unused;
            return double.TryParse(source, out unused);
        }
		
		/// <summary>Directly calls <see cref="double.TryParse(string, out double)" />, and boxes the return into a <see cref="Nullable" /> <see cref="int" />.</summary>
        /// <param name="source">A string containing a number to convert</param>
        /// <returns>The converted number or <see langword="null" /> if the conversion failed</returns>
        public static double? TryParseDouble([NotNull] this string source)
        {
            Util.ThrowIfSourceNull(source);
            double result;
            return double.TryParse(source, out result) ? result as double? : null;
        }
		
		
        /// <summary>Directly calls <see cref="double.TryParse(string, out double)" />.</summary>
        /// <param name="source">A string containing a number to convert</param>
        /// <param name="result">The result of the conversion operation</param>
        /// <returns><see langword="true" /> if the conversion succeeded; otherwise <see langword="false" /></returns>
        public static bool TryParseDouble([NotNull] this string source, out double result) => double.TryParse(source, out result);
		
        /// <summary>Shortcut for <see cref="double.TryParse(string, NumberStyles, IFormatProvider, out double)" /> with the out value discarded.</summary>
        /// <remarks>
        ///     It would be inefficient to use this to test before parsing, use <see cref="TryParseDouble(string)" /> and check that the returned value is null or <see cref="TryParseDouble(string, out double)" /> if
        ///     you intend to get the value.
        /// </remarks>
        /// <param name="source">The string to parse to an integer</param>
		/// <param name="formatProvider">An object that supplies culture-specific formatting information about <paramref name="source"/></param>
        /// <param name="styles">A bitwise combination of enumeration values that indicates the style elements that can be present in s. A typical value to specify is <see cref="NumberStyles.Float"/>.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"><paramref name="formatProvider"/> is <see langword="null" />.</exception>
		[ContractAnnotation("source:null=>false; formatProvider:null=>halt")]
        public static bool IsDouble([CanBeNull] this string source, [NotNull] IFormatProvider formatProvider, NumberStyles styles = NumberStyles.Float)
        {
            if (string.IsNullOrWhiteSpace(source)) return false;
            if (formatProvider == null) throw new ArgumentNullException(nameof(formatProvider));

            double unused;
            return double.TryParse(source, styles, formatProvider, out unused);
        }		

        /// <summary>Directly calls <see cref="double.TryParse(string, out double)" />, and boxes the return into a <see cref="Nullable" /> <see cref="int" />.</summary>
        /// <param name="source">A string containing a number to convert</param>
        /// <param name="formatProvider">An object that supplies culture-specific formatting information about <paramref name="source" /></param>
        /// <param name="styles">
        ///     A bitwise combination of enumeration values that indicates the style elements that can be present in s. A typical value to specify is
        ///     <see cref="NumberStyles.Float" />.
        /// </param>
        /// <returns>The converted number or <see langword="null" /> if the conversion failed</returns>
        public static double? TryParseDouble([NotNull]this string source, [NotNull] IFormatProvider formatProvider, NumberStyles styles = NumberStyles.Float)
        {
            Util.ThrowIfSourceNull(source);
            double result;
            return double.TryParse(source, styles, formatProvider, out result) ? result as double? : null;
        }

        /// <summary>Directly calls <see cref="double.TryParse(string, out double)" />.</summary>
        /// <param name="source">A string containing a number to convert</param>
        /// <param name="result">The result of the conversion operation if it was successful</param>
        /// <param name="formatProvider">An object that supplies culture-specific formatting information about <paramref name="source" /></param>
        /// <param name="styles">
        ///     A bitwise combination of enumeration values that indicates the style elements that can be present in s. A typical value to specify is
        ///     <see cref="NumberStyles.Float" />.
        /// </param>
        /// <returns><see langword="true" /> if the conversion succeeded; otherwise <see langword="false" /></returns>
        public static bool TryParseDouble([NotNull] this string source, IFormatProvider formatProvider, out double result, NumberStyles styles = NumberStyles.Float)
            => double.TryParse(source, styles, formatProvider, out result);
		

		/// <summary>Shortcut for <see cref="float.TryParse(string, out float)" /> with the out value discarded.</summary>
        /// <remarks>
        ///     It would be inefficient to use this to test before parsing, use <see cref="TryParseFloat(string)" /> and check that the returned value is null or <see cref="TryParseFloat(string, out float)" /> if
        ///     you intend to get the value.
        /// </remarks>
        /// <param name="source">The string to parse to an integer</param>
        /// <returns></returns>
		[ContractAnnotation("source:null=>false")]
        public static bool IsFloat([CanBeNull]this string source)
        {
            if (source.IsNullOrWhitespace()) return false;

            float unused;
            return float.TryParse(source, out unused);
        }
		
		/// <summary>Directly calls <see cref="float.TryParse(string, out float)" />, and boxes the return into a <see cref="Nullable" /> <see cref="int" />.</summary>
        /// <param name="source">A string containing a number to convert</param>
        /// <returns>The converted number or <see langword="null" /> if the conversion failed</returns>
        public static float? TryParseFloat([NotNull] this string source)
        {
            Util.ThrowIfSourceNull(source);
            float result;
            return float.TryParse(source, out result) ? result as float? : null;
        }
		
		
        /// <summary>Directly calls <see cref="float.TryParse(string, out float)" />.</summary>
        /// <param name="source">A string containing a number to convert</param>
        /// <param name="result">The result of the conversion operation</param>
        /// <returns><see langword="true" /> if the conversion succeeded; otherwise <see langword="false" /></returns>
        public static bool TryParseFloat([NotNull] this string source, out float result) => float.TryParse(source, out result);
		
        /// <summary>Shortcut for <see cref="float.TryParse(string, NumberStyles, IFormatProvider, out float)" /> with the out value discarded.</summary>
        /// <remarks>
        ///     It would be inefficient to use this to test before parsing, use <see cref="TryParseFloat(string)" /> and check that the returned value is null or <see cref="TryParseFloat(string, out float)" /> if
        ///     you intend to get the value.
        /// </remarks>
        /// <param name="source">The string to parse to an integer</param>
		/// <param name="formatProvider">An object that supplies culture-specific formatting information about <paramref name="source"/></param>
        /// <param name="styles">A bitwise combination of enumeration values that indicates the style elements that can be present in s. A typical value to specify is <see cref="NumberStyles.Float"/>.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"><paramref name="formatProvider"/> is <see langword="null" />.</exception>
		[ContractAnnotation("source:null=>false; formatProvider:null=>halt")]
        public static bool IsFloat([CanBeNull] this string source, [NotNull] IFormatProvider formatProvider, NumberStyles styles = NumberStyles.Float)
        {
            if (string.IsNullOrWhiteSpace(source)) return false;
            if (formatProvider == null) throw new ArgumentNullException(nameof(formatProvider));

            float unused;
            return float.TryParse(source, styles, formatProvider, out unused);
        }		

        /// <summary>Directly calls <see cref="float.TryParse(string, out float)" />, and boxes the return into a <see cref="Nullable" /> <see cref="int" />.</summary>
        /// <param name="source">A string containing a number to convert</param>
        /// <param name="formatProvider">An object that supplies culture-specific formatting information about <paramref name="source" /></param>
        /// <param name="styles">
        ///     A bitwise combination of enumeration values that indicates the style elements that can be present in s. A typical value to specify is
        ///     <see cref="NumberStyles.Float" />.
        /// </param>
        /// <returns>The converted number or <see langword="null" /> if the conversion failed</returns>
        public static float? TryParseFloat([NotNull]this string source, [NotNull] IFormatProvider formatProvider, NumberStyles styles = NumberStyles.Float)
        {
            Util.ThrowIfSourceNull(source);
            float result;
            return float.TryParse(source, styles, formatProvider, out result) ? result as float? : null;
        }

        /// <summary>Directly calls <see cref="float.TryParse(string, out float)" />.</summary>
        /// <param name="source">A string containing a number to convert</param>
        /// <param name="result">The result of the conversion operation if it was successful</param>
        /// <param name="formatProvider">An object that supplies culture-specific formatting information about <paramref name="source" /></param>
        /// <param name="styles">
        ///     A bitwise combination of enumeration values that indicates the style elements that can be present in s. A typical value to specify is
        ///     <see cref="NumberStyles.Float" />.
        /// </param>
        /// <returns><see langword="true" /> if the conversion succeeded; otherwise <see langword="false" /></returns>
        public static bool TryParseFloat([NotNull] this string source, IFormatProvider formatProvider, out float result, NumberStyles styles = NumberStyles.Float)
            => float.TryParse(source, styles, formatProvider, out result);
		

		/// <summary>Shortcut for <see cref="decimal.TryParse(string, out decimal)" /> with the out value discarded.</summary>
        /// <remarks>
        ///     It would be inefficient to use this to test before parsing, use <see cref="TryParseDecimal(string)" /> and check that the returned value is null or <see cref="TryParseDecimal(string, out decimal)" /> if
        ///     you intend to get the value.
        /// </remarks>
        /// <param name="source">The string to parse to an integer</param>
        /// <returns></returns>
		[ContractAnnotation("source:null=>false")]
        public static bool IsDecimal([CanBeNull]this string source)
        {
            if (source.IsNullOrWhitespace()) return false;

            decimal unused;
            return decimal.TryParse(source, out unused);
        }
		
		/// <summary>Directly calls <see cref="decimal.TryParse(string, out decimal)" />, and boxes the return into a <see cref="Nullable" /> <see cref="int" />.</summary>
        /// <param name="source">A string containing a number to convert</param>
        /// <returns>The converted number or <see langword="null" /> if the conversion failed</returns>
        public static decimal? TryParseDecimal([NotNull] this string source)
        {
            Util.ThrowIfSourceNull(source);
            decimal result;
            return decimal.TryParse(source, out result) ? result as decimal? : null;
        }
		
		
        /// <summary>Directly calls <see cref="decimal.TryParse(string, out decimal)" />.</summary>
        /// <param name="source">A string containing a number to convert</param>
        /// <param name="result">The result of the conversion operation</param>
        /// <returns><see langword="true" /> if the conversion succeeded; otherwise <see langword="false" /></returns>
        public static bool TryParseDecimal([NotNull] this string source, out decimal result) => decimal.TryParse(source, out result);
		
        /// <summary>Shortcut for <see cref="decimal.TryParse(string, NumberStyles, IFormatProvider, out decimal)" /> with the out value discarded.</summary>
        /// <remarks>
        ///     It would be inefficient to use this to test before parsing, use <see cref="TryParseDecimal(string)" /> and check that the returned value is null or <see cref="TryParseDecimal(string, out decimal)" /> if
        ///     you intend to get the value.
        /// </remarks>
        /// <param name="source">The string to parse to an integer</param>
		/// <param name="formatProvider">An object that supplies culture-specific formatting information about <paramref name="source"/></param>
        /// <param name="styles">A bitwise combination of enumeration values that indicates the style elements that can be present in s. A typical value to specify is <see cref="NumberStyles.Float"/>.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"><paramref name="formatProvider"/> is <see langword="null" />.</exception>
		[ContractAnnotation("source:null=>false; formatProvider:null=>halt")]
        public static bool IsDecimal([CanBeNull] this string source, [NotNull] IFormatProvider formatProvider, NumberStyles styles = NumberStyles.Float)
        {
            if (string.IsNullOrWhiteSpace(source)) return false;
            if (formatProvider == null) throw new ArgumentNullException(nameof(formatProvider));

            decimal unused;
            return decimal.TryParse(source, styles, formatProvider, out unused);
        }		

        /// <summary>Directly calls <see cref="decimal.TryParse(string, out decimal)" />, and boxes the return into a <see cref="Nullable" /> <see cref="int" />.</summary>
        /// <param name="source">A string containing a number to convert</param>
        /// <param name="formatProvider">An object that supplies culture-specific formatting information about <paramref name="source" /></param>
        /// <param name="styles">
        ///     A bitwise combination of enumeration values that indicates the style elements that can be present in s. A typical value to specify is
        ///     <see cref="NumberStyles.Float" />.
        /// </param>
        /// <returns>The converted number or <see langword="null" /> if the conversion failed</returns>
        public static decimal? TryParseDecimal([NotNull]this string source, [NotNull] IFormatProvider formatProvider, NumberStyles styles = NumberStyles.Float)
        {
            Util.ThrowIfSourceNull(source);
            decimal result;
            return decimal.TryParse(source, styles, formatProvider, out result) ? result as decimal? : null;
        }

        /// <summary>Directly calls <see cref="decimal.TryParse(string, out decimal)" />.</summary>
        /// <param name="source">A string containing a number to convert</param>
        /// <param name="result">The result of the conversion operation if it was successful</param>
        /// <param name="formatProvider">An object that supplies culture-specific formatting information about <paramref name="source" /></param>
        /// <param name="styles">
        ///     A bitwise combination of enumeration values that indicates the style elements that can be present in s. A typical value to specify is
        ///     <see cref="NumberStyles.Float" />.
        /// </param>
        /// <returns><see langword="true" /> if the conversion succeeded; otherwise <see langword="false" /></returns>
        public static bool TryParseDecimal([NotNull] this string source, IFormatProvider formatProvider, out decimal result, NumberStyles styles = NumberStyles.Float)
            => decimal.TryParse(source, styles, formatProvider, out result);
		
	}
}
