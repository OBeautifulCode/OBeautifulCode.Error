﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ErrorCodeExtensionsTest.cs" company="OBeautifulCode">
//   Copyright (c) OBeautifulCode 2018. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace OBeautifulCode.Exception.Recipes.Test
{
    using System;
    using System.Collections;
    using System.Diagnostics.CodeAnalysis;

    using FakeItEasy;

    using FluentAssertions;

    using Xunit;

    public static class ErrorCodeExtensionsTest
    {
        [Fact]
        public static void AddErrorCode__Should_throw_ArgumentNullException___When_parameter_exception_is_null()
        {
            // Arrange
            var errorCode = A.Dummy<string>();

            // Act
            var actual = Record.Exception(() => ErrorCodeExtensions.AddErrorCode(null, errorCode));

            // Assert
            actual.Should().BeOfType<ArgumentNullException>();
            actual.Message.Should().Contain("exception");
        }

        [Fact]
        [SuppressMessage("Microsoft.Usage", "CA2208:InstantiateArgumentExceptionsCorrectly", Justification = "For testing purposes only.")]
        public static void AddErrorCode__Should_throw_ArgumentNullException___When_parameter_errorCode_is_null()
        {
            // Arrange
            var exception = new ArgumentException();

            // Act
            var actual = Record.Exception(() => exception.AddErrorCode(null));

            // Assert
            actual.Should().BeOfType<ArgumentNullException>();
            actual.Message.Should().Contain("errorCode");
        }

        [Fact]
        [SuppressMessage("Microsoft.Usage", "CA2208:InstantiateArgumentExceptionsCorrectly", Justification = "For testing purposes only.")]
        public static void AddErrorCode__Should_throw_ArgumentException___When_parameter_errorCode_is_white_space()
        {
            // Arrange
            var errorCode = "  \r\n  ";
            var exception = new ArgumentException();

            // Act
            var actual = Record.Exception(() => exception.AddErrorCode(errorCode));

            // Assert
            actual.Should().BeOfType<ArgumentException>();
            actual.Message.Should().Contain("errorCode");
            actual.Message.Should().Contain("white space");
        }

        [Fact]
        [SuppressMessage("Microsoft.Usage", "CA2208:InstantiateArgumentExceptionsCorrectly", Justification = "For testing purposes only.")]
        public static void AddErrorCode__Should_throw_ArgumentNullException___When_parameter_dataKeyForErrorCode_is_null()
        {
            // Arrange
            var errorCode = A.Dummy<string>();
            var exception = new ArgumentException();

            // Act
            var actual = Record.Exception(() => exception.AddErrorCode(errorCode, dataKeyForErrorCode: null));

            // Assert
            actual.Should().BeOfType<ArgumentNullException>();
            actual.Message.Should().Contain("dataKeyForErrorCode");
        }

        [Fact]
        [SuppressMessage("Microsoft.Usage", "CA2208:InstantiateArgumentExceptionsCorrectly", Justification = "For testing purposes only.")]
        public static void AddErrorCode__Should_throw_ArgumentException___When_parameter_dataKeyForErrorCode_is_white_space()
        {
            // Arrange
            var errorCode = A.Dummy<string>();
            var exception = new ArgumentException();

            // Act
            var actual = Record.Exception(() => exception.AddErrorCode(errorCode, dataKeyForErrorCode: "  \r\n  "));

            // Assert
            actual.Should().BeOfType<ArgumentException>();
            actual.Message.Should().Contain("dataKeyForErrorCode");
            actual.Message.Should().Contain("white space");
        }

        [Fact]
        [SuppressMessage("Microsoft.Usage", "CA2208:InstantiateArgumentExceptionsCorrectly", Justification = "For testing purposes only.")]
        public static void AddErrorCode__Should_throw_ArgumentNullException___When_parameter_dataKeyForErrorCodesVector_is_null()
        {
            // Arrange
            var errorCode = A.Dummy<string>();
            var exception = new ArgumentException();

            // Act
            var actual = Record.Exception(() => exception.AddErrorCode(errorCode, dataKeyForErrorCodesVector: null));

            // Assert
            actual.Should().BeOfType<ArgumentNullException>();
            actual.Message.Should().Contain("dataKeyForErrorCodesVector");
        }

        [Fact]
        [SuppressMessage("Microsoft.Usage", "CA2208:InstantiateArgumentExceptionsCorrectly", Justification = "For testing purposes only.")]
        public static void AddErrorCode__Should_throw_ArgumentException___When_parameter_dataKeyForErrorCodesVector_is_white_space()
        {
            // Arrange
            var errorCode = A.Dummy<string>();
            var exception = new ArgumentException();

            // Act
            var actual = Record.Exception(() => exception.AddErrorCode(errorCode, dataKeyForErrorCodesVector: "  \r\n  "));

            // Assert
            actual.Should().BeOfType<ArgumentException>();
            actual.Message.Should().Contain("dataKeyForErrorCodesVector");
            actual.Message.Should().Contain("white space");
        }

        [Fact]
        [SuppressMessage("Microsoft.Usage", "CA2208:InstantiateArgumentExceptionsCorrectly", Justification = "For testing purposes only.")]
        public static void AddErrorCode__Should_throw_ArgumentOutOfRangeException___When_parameter_dataKeyForErrorCodesVector_equals_dataKeyForErrorCode()
        {
            // Arrange
            var errorCode = A.Dummy<string>();
            var exception = new ArgumentException();
            var key = A.Dummy<string>();

            // Act
            var actual = Record.Exception(() => exception.AddErrorCode(errorCode, dataKeyForErrorCode: key, dataKeyForErrorCodesVector: key));

            // Assert
            actual.Should().BeOfType<ArgumentOutOfRangeException>();
            actual.Message.Should().Contain("dataKeyForErrorCode cannot equal dataKeyForErrorCodesVector");
            actual.Message.Should().Contain(key);
        }

        [Fact]
        public static void AddErrorCode__Should_throw_ArgumentNullException___When_parameter_exception_Data_is_null()
        {
            // Arrange
            var errorCode = A.Dummy<string>();
            var exception = new ExceptionWithNoData();

            // Act
            var actual = Record.Exception(() => exception.AddErrorCode(errorCode));

            // Assert
            actual.Should().BeOfType<ArgumentNullException>();
            actual.Message.Should().Contain("exception.Data");
        }

        [Fact]
        [SuppressMessage("Microsoft.Usage", "CA2208:InstantiateArgumentExceptionsCorrectly", Justification = "For testing purposes only.")]
        public static void AddErrorCode__Should_throw_ArgumentException___When_parameter_exception_Data_already_contains_ExceptionDataKeyForErrorCode()
        {
            // Arrange
            var errorCode = " a good code ";
            var exception = new ArgumentException();
            exception.Data[ErrorCodeConstants.ExceptionDataKeyForErrorCode] = A.Dummy<object>();

            // Act
            var actual = Record.Exception(() => exception.AddErrorCode(errorCode));

            // Assert
            actual.Should().BeOfType<ArgumentException>();
            actual.Message.Should().Contain("exception.Data.Keys");
            actual.Message.Should().Contain(ErrorCodeConstants.ExceptionDataKeyForErrorCode);
        }

        [Fact]
        [SuppressMessage("Microsoft.Usage", "CA2208:InstantiateArgumentExceptionsCorrectly", Justification = "For testing purposes only.")]
        public static void AddErrorCode__Should_throw_ArgumentException___When_parameter_exception_Data_already_contains_ExceptionDataKeyForErrorCodesVector()
        {
            // Arrange
            var errorCode = " a good code";
            var exception = new ArgumentException();
            exception.Data[ErrorCodeConstants.ExceptionDataKeyForErrorCodesVector] = A.Dummy<object>();

            // Act
            var actual = Record.Exception(() => exception.AddErrorCode(errorCode));

            // Assert
            actual.Should().BeOfType<ArgumentException>();
            actual.Message.Should().Contain("exception.Data.Keys");
            actual.Message.Should().Contain(ErrorCodeConstants.ExceptionDataKeyForErrorCodesVector);
        }

        [Fact]
        [SuppressMessage("Microsoft.Usage", "CA2208:InstantiateArgumentExceptionsCorrectly", Justification = "For testing purposes only.")]
        public static void AddErrorCode__Should_not_throw___When_all_parameters_are_valid()
        {
            // Arrange
            var errorCode = " a good code ";
            var exception = new ArgumentException();

            // Act
            var actual = Record.Exception(() => exception.AddErrorCode(errorCode));

            // Assert
            actual.Should().BeNull();
        }

        [Fact]
        public static void GetErrorCode___Should_throw_ArgumentNullException___When_parameter_exception_is_null()
        {
            // Arrange, Act
            var actual = Record.Exception(() => ErrorCodeExtensions.GetErrorCode(null));

            // Assert
            actual.Should().BeOfType<ArgumentNullException>();
            actual.Message.Should().Contain("exception");
        }

        [Fact]
        [SuppressMessage("Microsoft.Usage", "CA2208:InstantiateArgumentExceptionsCorrectly", Justification = "For testing purposes only.")]
        public static void GetErrorCode___Should_throw_ArgumentNullException___When_parameter_dataKeyForErrorCode_is_null()
        {
            // Arrange
            var exception = new ArgumentException();

            // Act
            var actual = Record.Exception(() => exception.GetErrorCode(dataKeyForErrorCode: null));

            // Assert
            actual.Should().BeOfType<ArgumentNullException>();
            actual.Message.Should().Contain("dataKeyForErrorCode");
        }

        [Fact]
        [SuppressMessage("Microsoft.Usage", "CA2208:InstantiateArgumentExceptionsCorrectly", Justification = "For testing purposes only.")]
        public static void GetErrorCode___Should_throw_ArgumentException___When_parameter_dataKeyForErrorCode_is_white_space()
        {
            // Arrange
            var exception = new ArgumentException();

            // Act
            var actual = Record.Exception(() => exception.GetErrorCode(dataKeyForErrorCode: " \r\n  "));

            // Assert
            actual.Should().BeOfType<ArgumentException>();
            actual.Message.Should().Contain("dataKeyForErrorCode");
            actual.Message.Should().Contain("white space");
        }

        [Fact]
        public static void GetErrorCode___Should_return_null___When_parameter_exception_Data_is_null()
        {
            // Arrange,
            var exception = new ExceptionWithNoData();

            // Act
            var actual = exception.GetErrorCode();

            // Assert
            actual.Should().BeNull();
        }

        [Fact]
        [SuppressMessage("Microsoft.Usage", "CA2208:InstantiateArgumentExceptionsCorrectly", Justification = "For testing purposes only.")]
        public static void GetErrorCode___Should_return_null___When_error_code_was_not_added_to_exception()
        {
            // Arrange,
            var exception = new ArgumentException();

            // Act
            var actual = exception.GetErrorCode();

            // Assert
            actual.Should().BeNull();
        }

        [Fact]
        [SuppressMessage("Microsoft.Usage", "CA2208:InstantiateArgumentExceptionsCorrectly", Justification = "For testing purposes only.")]
        public static void GetErrorCode___Should_return_error_code___When_error_code_was_added_to_exception()
        {
            // Arrange,
            var exception = new ArgumentException();
            var expected = "this-is-an-ERROR_CODE";
            exception.AddErrorCode(expected);

            // Act
            var actual = exception.GetErrorCode();

            // Assert
            actual.Should().Be(expected);
        }

        [Fact]
        [SuppressMessage("Microsoft.Usage", "CA2208:InstantiateArgumentExceptionsCorrectly", Justification = "For testing purposes only.")]
        public static void GetErrorCode___Should_return_error_code___When_error_code_was_added_to_exception_and_retrieved_from_exception_using_custom_dataKeyForErrorCode()
        {
            // Arrange,
            var exception = new ArgumentException();
            var dataKeyForErrorCode = A.Dummy<string>();
            var expected = "this-is-an-ERROR_CODE";
            exception.AddErrorCode(expected, dataKeyForErrorCode: dataKeyForErrorCode);

            // Act
            var actual = exception.GetErrorCode(dataKeyForErrorCode);

            // Assert
            actual.Should().Be(expected);
        }

        [Fact]
        public static void GetErrorCodesVector___Should_throw_ArgumentNullException___When_parameter_exception_is_null()
        {
            // Arrange, Act
            var actual = Record.Exception(() => ErrorCodeExtensions.GetErrorCodesVector(null));

            // Assert
            actual.Should().BeOfType<ArgumentNullException>();
            actual.Message.Should().Contain("exception");
        }

        [Fact]
        [SuppressMessage("Microsoft.Usage", "CA2208:InstantiateArgumentExceptionsCorrectly", Justification = "For testing purposes only.")]
        public static void GetErrorCodesVector___Should_throw_ArgumentNullException___When_parameter_dataKeyForErrorCodesVector_is_null()
        {
            // Arrange
            var exception = new ArgumentException();

            // Act
            var actual = Record.Exception(() => exception.GetErrorCodesVector(dataKeyForErrorCodesVector: null));

            // Assert
            actual.Should().BeOfType<ArgumentNullException>();
            actual.Message.Should().Contain("dataKeyForErrorCodesVector");
        }

        [Fact]
        [SuppressMessage("Microsoft.Usage", "CA2208:InstantiateArgumentExceptionsCorrectly", Justification = "For testing purposes only.")]
        public static void GetErrorCodesVector___Should_throw_ArgumentException___When_parameter_dataKeyForErrorCodesVector_is_white_space()
        {
            // Arrange
            var exception = new ArgumentException();

            // Act
            var actual = Record.Exception(() => exception.GetErrorCodesVector(dataKeyForErrorCodesVector: " \r\n  "));

            // Assert
            actual.Should().BeOfType<ArgumentException>();
            actual.Message.Should().Contain("dataKeyForErrorCodesVector");
            actual.Message.Should().Contain("white space");
        }

        [Fact]
        public static void GetErrorCodesVector___Should_return_null___When_parameter_exception_Data_is_null()
        {
            // Arrange,
            var exception = new ExceptionWithNoData();

            // Act
            var actual = exception.GetErrorCodesVector();

            // Assert
            actual.Should().BeNull();
        }

        [Fact]
        [SuppressMessage("Microsoft.Usage", "CA2208:InstantiateArgumentExceptionsCorrectly", Justification = "For testing purposes only.")]
        public static void GetErrorCodesVector___Should_return_null___When_error_code_was_not_added_to_exception_and_no_InnerException_nor_InnerExceptions()
        {
            // Arrange,
            var exception = new ArgumentException();

            // Act
            var actual = exception.GetErrorCodesVector();

            // Assert
            actual.Should().BeNull();
        }

        [Fact]
        [SuppressMessage("Microsoft.Usage", "CA2208:InstantiateArgumentExceptionsCorrectly", Justification = "For testing purposes only.")]
        public static void GetErrorCodesVector___Should_return_error_code_of_exception___When_error_code_was_added_to_exception_and_no_InnerException_nor_InnerExceptions()
        {
            // Arrange,
            var exception = new ArgumentException();
            var errorCode = A.Dummy<string>();
            exception.AddErrorCode(errorCode);

            // Act
            var actual = exception.GetErrorCodesVector();

            // Assert
            actual.Should().Be(errorCode);
        }

        [Fact]
        [SuppressMessage("Microsoft.Usage", "CA2208:InstantiateArgumentExceptionsCorrectly", Justification = "For testing purposes only.")]
        public static void GetErrorCodesVector___Should_return_error_code_of_exception___When_error_code_was_added_to_and_retrieved_from_exception_using_custom_dataKeyForErrorCodesVector()
        {
            // Arrange,
            var exception = new ArgumentException();
            var dataKeyForErrorCodesVector = A.Dummy<string>();
            var errorCode = A.Dummy<string>();
            exception.AddErrorCode(errorCode, dataKeyForErrorCodesVector: dataKeyForErrorCodesVector);

            // Act
            var actual = exception.GetErrorCodesVector(dataKeyForErrorCodesVector);

            // Assert
            actual.Should().Be(errorCode);
        }

        [Fact]
        [SuppressMessage("Microsoft.Usage", "CA2208:InstantiateArgumentExceptionsCorrectly", Justification = "For testing purposes only.")]
        public static void GetErrorCodesVector___Should_return_vector___When_there_are_InnerException_and_InnerExceptions()
        {
            // Arrange
            var exceptionF = new ArgumentException().AddErrorCode("ErrorF");
            var exceptionE = new AggregateException(exceptionF).AddErrorCode("ErrorE");
            var exceptionD = new ArgumentException().AddErrorCode("ErrorD");
            var exceptionC = new ArgumentException(A.Dummy<string>(), exceptionD).AddErrorCode("ErrorC");
            var exceptionG = new ArgumentException().AddErrorCode("ErrorG");
            var exceptionB = new AggregateException(exceptionC, exceptionE, exceptionG).AddErrorCode("ErrorB");
            var exceptionA = new ArgumentException(A.Dummy<string>(), exceptionB).AddErrorCode("ErrorA");

            var expected = "ErrorA -> ErrorB -> [ErrorC -> ErrorD, ErrorE -> ErrorF, ErrorG]";

            // Act
            var actual = exceptionA.GetErrorCodesVector();

            // Assert
            actual.Should().Be(expected);
        }

        [Fact]
        [SuppressMessage("Microsoft.Usage", "CA2208:InstantiateArgumentExceptionsCorrectly", Justification = "For testing purposes only.")]
        public static void GetErrorCodesVector___Should_return_vector___When_there_are_InnerException_and_InnerExceptions_but_not_all_have_error_codes_scenario_1()
        {
            // Arrange
            var exceptionF = new ArgumentException().AddErrorCode("ErrorF");
            var exceptionE = new AggregateException(exceptionF).AddErrorCode("ErrorE");
            var exceptionD = new ArgumentException().AddErrorCode("ErrorD");
            var exceptionC = new ArgumentException(A.Dummy<string>(), exceptionD).AddErrorCode("ErrorC");
            var exceptionG = new ArgumentException().AddErrorCode("ErrorG");
            var exceptionB = new AggregateException(exceptionC, exceptionE, exceptionG);
            var exceptionA = new ArgumentException(A.Dummy<string>(), exceptionB).AddErrorCode("ErrorA");

            var expected = "ErrorA -> [ErrorC -> ErrorD, ErrorE -> ErrorF, ErrorG]";

            // Act
            var actual = exceptionA.GetErrorCodesVector();

            // Assert
            actual.Should().Be(expected);
        }

        [Fact]
        [SuppressMessage("Microsoft.Usage", "CA2208:InstantiateArgumentExceptionsCorrectly", Justification = "For testing purposes only.")]
        public static void GetErrorCodesVector___Should_return_vector___When_there_are_InnerException_and_InnerExceptions_but_not_all_have_error_codes_scenario_2()
        {
            // Arrange
            var exceptionF = new ArgumentException();
            var exceptionE = new AggregateException(exceptionF).AddErrorCode("ErrorE");
            var exceptionD = new ArgumentException().AddErrorCode("ErrorD");
            var exceptionC = new ArgumentException(A.Dummy<string>(), exceptionD);
            var exceptionG = new ArgumentException();
            var exceptionB = new AggregateException(exceptionC, exceptionE, exceptionG).AddErrorCode("ErrorB");
            var exceptionA = new ArgumentException(A.Dummy<string>(), exceptionB).AddErrorCode("ErrorA");

            var expected = "ErrorA -> ErrorB -> [ErrorD, ErrorE]";

            // Act
            var actual = exceptionA.GetErrorCodesVector();

            // Assert
            actual.Should().Be(expected);
        }

        [Fact]
        [SuppressMessage("Microsoft.Usage", "CA2208:InstantiateArgumentExceptionsCorrectly", Justification = "For testing purposes only.")]
        public static void GetErrorCodesVector___Should_return_vector___When_there_are_InnerException_and_InnerExceptions_but_not_all_have_error_codes_scenario_3()
        {
            // Arrange
            var exceptionF = new ArgumentException();
            var exceptionE = new AggregateException(exceptionF).AddErrorCode("ErrorE");
            var exceptionD = new ArgumentException();
            var exceptionC = new ArgumentException(A.Dummy<string>(), exceptionD);
            var exceptionG = new ArgumentException();
            var exceptionB = new AggregateException(exceptionC, exceptionE, exceptionG).AddErrorCode("ErrorB");
            var exceptionA = new ArgumentException(A.Dummy<string>(), exceptionB).AddErrorCode("ErrorA");

            var expected = "ErrorA -> ErrorB -> ErrorE";

            // Act
            var actual = exceptionA.GetErrorCodesVector();

            // Assert
            actual.Should().Be(expected);
        }

        [Fact]
        [SuppressMessage("Microsoft.Usage", "CA2208:InstantiateArgumentExceptionsCorrectly", Justification = "For testing purposes only.")]
        public static void GetErrorCodesVector___Should_return_vector___When_there_are_InnerException_and_InnerExceptions_but_not_all_have_error_codes_scenario_4()
        {
            // Arrange
            var exceptionF = new ArgumentException();
            var exceptionE = new AggregateException(exceptionF);
            var exceptionD = new ArgumentException().AddErrorCode("ErrorD");
            var exceptionC = new ArgumentException(A.Dummy<string>(), exceptionD);
            var exceptionG = new ArgumentException();
            var exceptionB = new AggregateException(exceptionC, exceptionE, exceptionG).AddErrorCode("ErrorB");
            var exceptionA = new ArgumentException(A.Dummy<string>(), exceptionB).AddErrorCode("ErrorA");

            var expected = "ErrorA -> ErrorB -> ErrorD";

            // Act
            var actual = exceptionA.GetErrorCodesVector();

            // Assert
            actual.Should().Be(expected);
        }

        [SuppressMessage("Microsoft.Usage", "CA2237:MarkISerializableTypesWithSerializable", Justification = "For testing purposes only.")]
        [SuppressMessage("Microsoft.Design", "CA1032:ImplementStandardExceptionConstructors", Justification = "For testing purposes only.")]
        [SuppressMessage("Microsoft.Design", "CA1064:ExceptionsShouldBePublic", Justification = "For testing purposes only.")]
        private class ExceptionWithNoData : Exception
        {
            public override IDictionary Data => null;
        }
    }
}
