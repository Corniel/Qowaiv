﻿// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------

#define NoComparisonOperators
#define NotGetHashCodeStruct
namespace Qowaiv.Financial
{
    using System;

    public partial struct InternationalBankAccountNumber
    {
#if !NotField
        private InternationalBankAccountNumber(string value) => m_Value = value;
        /// <summary>The inner value of the IBAN.</summary>
        private string m_Value;
#endif
#if !NotIsEmpty
        /// <summary>Returns true if the  IBAN is empty, otherwise false.</summary>
        public bool IsEmpty() => m_Value == default;
#endif
#if !NotIsUnknown
        /// <summary>Returns true if the  IBAN is unknown, otherwise false.</summary>
        public bool IsUnknown() => m_Value == Unknown.m_Value;
#endif
#if !NotIsEmptyOrUnknown
        /// <summary>Returns true if the  IBAN is empty or unknown, otherwise false.</summary>
        public bool IsEmptyOrUnknown() => IsEmpty() || IsUnknown();
#endif
    }
}

namespace Qowaiv.Financial
{
    using System;

    public partial struct InternationalBankAccountNumber : IEquatable<InternationalBankAccountNumber>
    {
        /// <inheritdoc/>
        public override bool Equals(object obj) => obj is InternationalBankAccountNumber other && Equals(other);
#if !NotEqualsSvo
        /// <summary>Returns true if this instance and the other IBAN are equal, otherwise false.</summary>
        /// <param name = "other">The <see cref = "InternationalBankAccountNumber"/> to compare with.</param>
        public bool Equals(InternationalBankAccountNumber other) => m_Value == other.m_Value;
#if !NotGetHashCodeStruct
        /// <inheritdoc/>
        public override int GetHashCode() => m_Value.GetHashCode();
#endif
#if !NotGetHashCodeClass
        /// <inheritdoc/>
        public override int GetHashCode() => m_Value is null ? 0 : m_Value.GetHashCode();
#endif
#endif
        /// <summary>Returns true if the left and right operand are equal, otherwise false.</summary>
        /// <param name = "left">The left operand.</param>
        /// <param name = "right">The right operand</param>
        public static bool operator !=(InternationalBankAccountNumber left, InternationalBankAccountNumber right) => !(left == right);
        /// <summary>Returns true if the left and right operand are not equal, otherwise false.</summary>
        /// <param name = "left">The left operand.</param>
        /// <param name = "right">The right operand</param>
        public static bool operator ==(InternationalBankAccountNumber left, InternationalBankAccountNumber right) => left.Equals(right);
    }
}

namespace Qowaiv.Financial
{
    using System;
    using System.Collections.Generic;

    public partial struct InternationalBankAccountNumber : IComparable, IComparable<InternationalBankAccountNumber>
    {
        /// <inheritdoc/>
        public int CompareTo(object obj)
        {
            if (obj is null)
            {
                return 1;
            }
            else if (obj is InternationalBankAccountNumber other)
            {
                return CompareTo(other);
            }
            else
            {
                throw new ArgumentException($"Argument must be {GetType().Name}.", nameof(obj));
            }
        }

#if !NotEqualsSvo
        /// <inheritdoc/>
        public int CompareTo(InternationalBankAccountNumber other) => Comparer<string>.Default.Compare(m_Value, other.m_Value);
#endif
#if !NoComparisonOperators
        /// <summary>Returns true if the left operator is less then the right operator, otherwise false.</summary>
        public static bool operator <(InternationalBankAccountNumber l, InternationalBankAccountNumber r) => l.CompareTo(r) < 0;
        /// <summary>Returns true if the left operator is greater then the right operator, otherwise false.</summary>
        public static bool operator>(InternationalBankAccountNumber l, InternationalBankAccountNumber r) => l.CompareTo(r) > 0;
        /// <summary>Returns true if the left operator is less then or equal the right operator, otherwise false.</summary>
        public static bool operator <=(InternationalBankAccountNumber l, InternationalBankAccountNumber r) => l.CompareTo(r) <= 0;
        /// <summary>Returns true if the left operator is greater then or equal the right operator, otherwise false.</summary>
        public static bool operator >=(InternationalBankAccountNumber l, InternationalBankAccountNumber r) => l.CompareTo(r) >= 0;
#endif
    }
}

namespace Qowaiv.Financial
{
    using System;
    using System.Runtime.Serialization;

    public partial struct InternationalBankAccountNumber : ISerializable
    {
        /// <summary>Initializes a new instance of the IBAN based on the serialization info.</summary>
        /// <param name = "info">The serialization info.</param>
        /// <param name = "context">The streaming context.</param>
        private InternationalBankAccountNumber(SerializationInfo info, StreamingContext context)
        {
            Guard.NotNull(info, nameof(info));
            m_Value = (string)info.GetValue("Value", typeof(string));
        }

        /// <summary>Adds the underlying property of the IBAN to the serialization info.</summary>
        /// <param name = "info">The serialization info.</param>
        /// <param name = "context">The streaming context.</param>
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context) => Guard.NotNull(info, nameof(info)).AddValue("Value", m_Value);
    }
}

namespace Qowaiv.Financial
{
    using System.Globalization;
    using System.Xml;
    using System.Xml.Schema;
    using System.Xml.Serialization;

    public partial struct InternationalBankAccountNumber : IXmlSerializable
    {
        /// <summary>Gets the <see href = "XmlSchema"/> to XML (de)serialize the IBAN.</summary>
        /// <remarks>
        /// Returns null as no schema is required.
        /// </remarks>
        XmlSchema IXmlSerializable.GetSchema() => null;
        /// <summary>Reads the IBAN from an <see href = "XmlReader"/>.</summary>
        /// <param name = "reader">An XML reader.</param>
        void IXmlSerializable.ReadXml(XmlReader reader)
        {
            Guard.NotNull(reader, nameof(reader));
            var xml = reader.ReadElementString();
#if !NotCultureDependent
            var val = Parse(xml, CultureInfo.InvariantCulture);
#else
            var val = Parse(xml);
#endif
#if !NotField
            m_Value = val.m_Value;
#endif
            OnReadXml(val);
        }

        partial void OnReadXml(InternationalBankAccountNumber other);
        /// <summary>Writes the IBAN to an <see href = "XmlWriter"/>.</summary>
        /// <remarks>
        /// Uses <see cref = "ToXmlString()"/>.
        /// </remarks>
        /// <param name = "writer">An XML writer.</param>
        void IXmlSerializable.WriteXml(XmlWriter writer) => Guard.NotNull(writer, nameof(writer)).WriteString(ToXmlString());
    }
}

namespace Qowaiv.Financial
{
    using System;
    using System.Globalization;
    using Qowaiv.Json;

    public partial struct InternationalBankAccountNumber
    {
        /// <summary>Creates the IBAN from a JSON string.</summary>
        /// <param name = "json">
        /// The JSON string to deserialize.
        /// </param>
        /// <returns>
        /// The deserialized IBAN.
        /// </returns>
        
#if !NotCultureDependent
        public static InternationalBankAccountNumber FromJson(string json) => Parse(json, CultureInfo.InvariantCulture);
#else
        public static InternationalBankAccountNumber FromJson(string json) => Parse(json);
#endif
    }
}

namespace Qowaiv.Financial
{
    using System;
    using System.Globalization;

    public partial struct InternationalBankAccountNumber : IFormattable
    {
        /// <summary>Returns a <see cref = "string "/> that represents the IBAN.</summary>
        public override string ToString() => ToString(CultureInfo.CurrentCulture);
        /// <summary>Returns a formatted <see cref = "string "/> that represents the IBAN.</summary>
        /// <param name = "format">
        /// The format that describes the formatting.
        /// </param>
        public string ToString(string format) => ToString(format, CultureInfo.CurrentCulture);
        /// <summary>Returns a formatted <see cref = "string "/> that represents the IBAN.</summary>
        /// <param name = "provider">
        /// The format provider.
        /// </param>
        public string ToString(IFormatProvider provider) => ToString(string.Empty, provider);
    }
}

namespace Qowaiv.Financial
{
    using System;
    using System.Globalization;

    public partial struct InternationalBankAccountNumber
    {
#if !NotCultureDependent
        /// <summary>Converts the <see cref = "string "/> to <see cref = "InternationalBankAccountNumber"/>.</summary>
        /// <param name = "s">
        /// A string containing the IBAN to convert.
        /// </param>
        /// <returns>
        /// The parsed IBAN.
        /// </returns>
        /// <exception cref = "FormatException">
        /// <paramref name = "s"/> is not in the correct format.
        /// </exception>
        public static InternationalBankAccountNumber Parse(string s) => Parse(s, CultureInfo.CurrentCulture);
        /// <summary>Converts the <see cref = "string "/> to <see cref = "InternationalBankAccountNumber"/>.</summary>
        /// <param name = "s">
        /// A string containing the IBAN to convert.
        /// </param>
        /// <param name = "formatProvider">
        /// The specified format provider.
        /// </param>
        /// <returns>
        /// The parsed IBAN.
        /// </returns>
        /// <exception cref = "FormatException">
        /// <paramref name = "s"/> is not in the correct format.
        /// </exception>
        public static InternationalBankAccountNumber Parse(string s, IFormatProvider formatProvider) => TryParse(s, formatProvider, out InternationalBankAccountNumber val) ? val : throw new FormatException(QowaivMessages.FormatExceptionInternationalBankAccountNumber);
        /// <summary>Converts the <see cref = "string "/> to <see cref = "InternationalBankAccountNumber"/>.</summary>
        /// <param name = "s">
        /// A string containing the IBAN to convert.
        /// </param>
        /// <returns>
        /// The IBAN if the string was converted successfully, otherwise default.
        /// </returns>
        public static InternationalBankAccountNumber TryParse(string s) => TryParse(s, null, out InternationalBankAccountNumber val) ? val : default;
        /// <summary>Converts the <see cref = "string "/> to <see cref = "InternationalBankAccountNumber"/>.
        /// A return value indicates whether the conversion succeeded.
        /// </summary>
        /// <param name = "s">
        /// A string containing the IBAN to convert.
        /// </param>
        /// <param name = "result">
        /// The result of the parsing.
        /// </param>
        /// <returns>
        /// True if the string was converted successfully, otherwise false.
        /// </returns>
        public static bool TryParse(string s, out InternationalBankAccountNumber result) => TryParse(s, null, out result);
#else
        /// <summary>Converts the <see cref="string"/> to <see cref="InternationalBankAccountNumber"/>.</summary>
        /// <param name="s">
        /// A string containing the IBAN to convert.
        /// </param>
        /// <returns>
        /// The parsed IBAN.
        /// </returns>
        /// <exception cref="FormatException">
        /// <paramref name="s"/> is not in the correct format.
        /// </exception>
        public static InternationalBankAccountNumber Parse(string s)
            => TryParse(s, out InternationalBankAccountNumber val)
            ? val
            : throw new FormatException(QowaivMessages.FormatExceptionInternationalBankAccountNumber);

        /// <summary>Converts the <see cref="string"/> to <see cref="InternationalBankAccountNumber"/>.</summary>
        /// <param name="s">
        /// A string containing the IBAN to convert.
        /// </param>
        /// <returns>
        /// The IBAN if the string was converted successfully, otherwise default.
        /// </returns>
        public static InternationalBankAccountNumber TryParse(string s) => TryParse(s, out InternationalBankAccountNumber val) ? val : default;
#endif
    }
}

namespace Qowaiv.Financial
{
    using System;
    using System.Globalization;

    public partial struct InternationalBankAccountNumber
    {
#if !NotCultureDependent
        /// <summary>Returns true if the value represents a valid IBAN.</summary>
        /// <param name = "val">
        /// The <see cref = "string "/> to validate.
        /// </param>
        public static bool IsValid(string val) => IsValid(val, (IFormatProvider)null);
        /// <summary>Returns true if the value represents a valid IBAN.</summary>
        /// <param name = "val">
        /// The <see cref = "string "/> to validate.
        /// </param>
        /// <param name = "formatProvider">
        /// The <see cref = "IFormatProvider"/> to interpret the <see cref = "string "/> value with.
        /// </param>
        public static bool IsValid(string val, IFormatProvider formatProvider) => !string.IsNullOrWhiteSpace(val) && TryParse(val, formatProvider, out _);
#else
        /// <summary>Returns true if the value represents a valid IBAN.</summary>
        /// <param name="val">
        /// The <see cref="string"/> to validate.
        /// </param>
        public static bool IsValid(string val)
            => !string.IsNullOrWhiteSpace(val)
            && TryParse(val, out _);
#endif
    }
}