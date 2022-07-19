// <copyright file="AssertExtensions.cs" company="KinsonDigital">
// Copyright (c) KinsonDigital. All rights reserved.
// </copyright>

using System.Diagnostics.CodeAnalysis;
using Xunit;
using Xunit.Sdk;

namespace KDActionUtilsTests.Helpers;

/// <summary>
/// Provides helper methods for the <see cref="Xunit"/>'s <see cref="Assert"/> class.
/// </summary>
[ExcludeFromCodeCoverage]
// ReSharper disable once ClassNeverInstantiated.Global
public class AssertExtensions : Assert
{
    private const string TableFlip = "(╯'□')╯︵┻━┻  ";

    /// <summary>
    /// Verifies that all items in the collection pass when executed against the given action.
    /// </summary>
    /// <typeparam name="T">The type of object to be verified.</typeparam>
    /// <param name="collection">The 2-dimensional collection.</param>
    /// <param name="width">The width of the first dimension.</param>
    /// <param name="height">The height of the second dimension.</param>
    /// <param name="action">The action to test each item against.</param>
    /// <remarks>
    ///     The last 2 <see langword="in"/> parameters T2 and T3 of type <see langword="int"/> of the <paramref name="action"/>
    ///     is the X and Y location within the <paramref name="collection"/> that failed the assertion.
    /// </remarks>
    public static void All<T>(T[,] collection, uint width, uint height, Action<T, int, int> action)
    {
        var actionInvoked = false;

        for (var y = 0; y < height; y++)
        {
            for (var x = 0; x < width; x++)
            {
                actionInvoked = true;
                action(collection[x, y], x, y);
            }
        }

        var userMessage = TableFlip;
        userMessage += $"{TableFlip}No assertions were actually made in {nameof(AssertExtensions)}.{nameof(All)}<T>.";
        userMessage += "  Are there any items?";

        Assert.True(actionInvoked, userMessage);
    }

    /// <summary>
    /// Verifies that all items in the collection pass when executed against the given action.
    /// </summary>
    /// <typeparam name="T">The type of object to be verified.</typeparam>
    /// <param name="collection">The collection.</param>
    /// <param name="action">The action to test each item against.</param>
    public static void All<T>(T[] collection, Action<T, int> action)
    {
        var actionInvoked = false;

        for (var i = 0; i < collection.Length; i++)
        {
            actionInvoked = true;
            action(collection[i], i);
        }

        var userMessage = TableFlip;
        userMessage += $"No assertions were actually made in {nameof(AssertExtensions)}.{nameof(All)}<T>.";
        userMessage += "  Are there any items?";

        Assert.True(actionInvoked, userMessage);
    }

    /// <summary>
    /// Verifies that the two integers are equivalent.
    /// </summary>
    /// <param name="expected">The expected <see langword="int"/> value.</param>
    /// <param name="actual">The actual <see langword="int"/> value.</param>
    /// <param name="message">The message to be shown about the failed assertion.</param>
    public static void EqualWithMessage(int expected, int actual, string message)
    {
        var assertException = new AssertActualExpectedException(expected, actual, $"{TableFlip}{message}");
        try
        {
            Equal(expected, actual);
        }
        catch (Exception)
        {
            throw assertException;
        }
    }
}
