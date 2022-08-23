// <copyright file="MoqExtensions.cs" company="KinsonDigital">
// Copyright (c) KinsonDigital. All rights reserved.
// </copyright>

using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;
using Moq;

namespace KDActionUtilsTests.Helpers;

/// <summary>
/// Provides extensions to the <see cref="Moq"/> library for ease of use and readability purposes.
/// </summary>
[ExcludeFromCodeCoverage]
public static class MoqExtensions
{
    /// <summary>
    /// Verifies that a specific invocation matching the given expression was only performed on the mock exactly one time.
    /// Use in conjunction with the default <see cref="MockBehavior.Loose"/>.
    /// </summary>
    /// <param name="mock">The mock object to extend.</param>
    /// <param name="expression">Expression to verify.</param>
    /// <typeparam name="T">Type to mock, which can be an interface, a class, or a delegate.</typeparam>
    /// <exception cref="MockException">
    ///   The invocation was called when it was expected not to be called.
    /// </exception>
    public static void VerifyOnce<T>(this Mock<T> mock, Expression<Action<T>> expression)
        where T : class
        => mock.Verify(expression, Times.Once);
}
