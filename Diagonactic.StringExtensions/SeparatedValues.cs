using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using static Diagonactic.Enums.Flag;

namespace Diagonactic.StringExtensions
{
    /// <summary>
    /// How to handle spaces with separated values
    /// </summary>
    [Flags]
    public enum SeparatorSpaceFlags : byte
    {
        /// <summary>
        /// Do not add spaces to each entry
        /// </summary>
        None = 0,
        /// <summary>
        /// Add a space after the separator always
        /// </summary>
        AddSpaceAfter = F1,
        /// <summary>
        /// Adds a space before the separator always
        /// </summary>
        AddSpaceBefore = F2,
    }

    [Flags]
    public enum EntryFlags : byte
    {
        /// <summary>
        /// Don't perform any extra normalization on the parsed entries
        /// </summary>
        None = 0,
        /// <summary>
        /// Remove any entries that are empty. If <see cref="TrimEntries"/> is also included, entries who's values when trimmed are empty are also removed.
        /// </summary>
        RemoveEmptyEntries = F1,
        /// <summary>
        /// Trim entries of whitespace from the beginning and end of the parsed value
        /// </summary>
        TrimEntries = F2
    }

    
    /// <summary>
    /// An immutable helper class for managing strings with values and separators
    /// </summary>
    public class SeparatedValues
    {
        protected readonly string[] m_separators;
        private readonly SeparatorSpaceFlags m_spaceFlags;
        /// <summary>
        /// Internal field containing normalized values
        /// </summary>
        protected readonly string m_normalizedValue;
        /// <summary>
        /// Internal field containing the items
        /// </summary>
        protected readonly string[] m_items;
        /// <summary>
        /// An immutable list of items represented by the value
        /// </summary>
        public virtual IReadOnlyList<string> Items => m_items;
        /// <summary>
        /// The separated value string with normalization applied (if constructor specified normlization rules)
        /// </summary>
        public virtual string Value => m_normalizedValue;


        private string[] GetSeparator(string separator, SeparatorSpaceFlags spaceFlags, out string spacedSeparator)
        {
            spacedSeparator = (spaceFlags.IsFlagSet(SeparatorSpaceFlags.AddSpaceBefore) ? " " : null) + separator + (spaceFlags.IsFlagSet(SeparatorSpaceFlags.AddSpaceAfter) ? " " : null);
            return spaceFlags.AreAnyFlagsSet(SeparatorSpaceFlags.AddSpaceAfter, SeparatorSpaceFlags.AddSpaceBefore) ? new[] { separator, spacedSeparator } : new[] { separator };
        }


        /// <summary>
        /// Creates a new instance of the SeparatedValues class
        /// </summary>
        /// <remarks>
        /// All values are trimmed if <paramref name="removeEmptyEntriesAndTrim"/>
        /// </remarks>
        /// <param name="source">The string to parse into a list</param>
        /// <param name="separator">The separator to use for detecting list elements (do not include space)</param>
        /// <param name="spaceFlags">Should the separator include a space when parsing and when creatnig the <see cref="Value"/></param>
        /// <param name="removeEmptyEntriesAndTrim">Should empty entries be removed from the separated list</param>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> or <paramref name="separator"/> is <see langword="null" />.</exception>
        public SeparatedValues([NotNull] string source, [NotNull] string separator = ",", SeparatorSpaceFlags spaceFlags = SeparatorSpaceFlags.AddSpaceAfter,
                               EntryFlags entryFlags = EntryFlags.RemoveEmptyEntries | EntryFlags.TrimEntries)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (separator == null) throw new ArgumentNullException(nameof(separator));
            m_spaceFlags = spaceFlags;

            string spacedSeparator;
            var separators = GetSeparator(separator, spaceFlags, out spacedSeparator);
            m_separators = separators;
            string[] split = source.Split(separators, entryFlags.IsFlagSet(EntryFlags.RemoveEmptyEntries) ? StringSplitOptions.RemoveEmptyEntries : StringSplitOptions.None);
            var entries = entryFlags.IsFlagSet(EntryFlags.TrimEntries) ? split.Select(x => x.Trim()) : split;
            split = entryFlags.IsFlagSet(EntryFlags.RemoveEmptyEntries) ? entries.Where(x => !x.IsNullOrWhitespace()).ToArray() : entries.ToArray();
            m_items = split;
            m_normalizedValue = string.Join(spacedSeparator, split);
        }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>
        /// A string that represents the current object.
        /// </returns>
        public override string ToString()
        {
            return Value;
        }
    }

    /// <summary>
    /// A helper class for handling separated value strings where a suffix should be appended to each entry
    /// </summary>
    public class SuffixedSeparatedValues : SeparatedValues
    {
        private readonly string[] m_suffixedItems;
        private readonly string[] m_allValues;
        private readonly string m_suffixedNormalizedValue;

        /// <summary>
        /// Creates a new instance of the <see cref="SeparatedValues"/> with values that contain a required suffix
        /// </summary>
        /// <remarks>
        /// The suffix will be appended to all entries if it is not present and empty entries will be trimmed/removed.
        /// </remarks>
        /// <param name="source">The string to parse for values</param>
        /// <param name="suffix"></param>
        /// <param name="separator"></param>
        public SuffixedSeparatedValues([NotNull] string source, string suffix, [NotNull] string separator = ",", SeparatorSpaceFlags spaceFlags = SeparatorSpaceFlags.AddSpaceAfter) : base(source, separator, spaceFlags)
        {
            int joinSepIndex = m_separators.Length - 1;
            if (m_items.Any(x => !x.EndsWith(suffix)))
            {
                m_suffixedItems = m_items.Select(x => x.EndsWith(suffix) ? x : x + suffix).ToArray();
                m_suffixedNormalizedValue = string.Join(m_separators[joinSepIndex], m_suffixedItems);
            }
            else
            {
                m_suffixedItems = m_items;
                m_suffixedNormalizedValue = m_normalizedValue;
            }
            m_allValues = new string[m_suffixedItems.Length * 2];
            Array.Copy(m_suffixedItems, m_allValues, m_suffixedItems.Length);
            var unSuffixed = new string[m_suffixedItems.Length];

            for (int i = 0; i < unSuffixed.Length; i++)
                unSuffixed[i] = m_suffixedItems[i].LeftOf(suffix);

            Array.Copy(unSuffixed, 0, m_allValues, m_suffixedItems.Length, m_suffixedItems.Length);
        }

        /// <summary>
        /// A separated string with all items suffixed and separated by the separator and a space
        /// </summary>
        public override string Value => m_suffixedNormalizedValue;
        /// <summary>
        /// A list of items that is normalized to include the suffix on every entry
        /// </summary>
        public override IReadOnlyList<string> Items => m_suffixedItems;
        /// <summary>
        /// A list of items that includes both a suffixed and unsuffixed version of the list
        /// </summary>
        public IReadOnlyList<string> CompareItems => m_allValues;
    }
}