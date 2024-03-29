﻿// <copyright file="ActionOutputServiceTests.cs" company="KinsonDigital">
// Copyright (c) KinsonDigital. All rights reserved.
// </copyright>

using FluentAssertions;
using KDActionUtils;
using KDActionUtils.Exceptions;
using KDActionUtils.Services;
using KDActionUtilsTests.Helpers;
using Moq;
using Xunit;

namespace KDActionUtilsTests.Services;

/// <summary>
/// Tests the <see cref="ActionOutputService"/> class.
/// </summary>
public class ActionOutputServiceTests
{
    private readonly Mock<IConsoleService<ConsoleContext>> mockConsoleService;

    /// <summary>
    /// Initializes a new instance of the <see cref="ActionOutputServiceTests"/> class.
    /// </summary>
    public ActionOutputServiceTests() => this.mockConsoleService = new Mock<IConsoleService<ConsoleContext>>();

    #region Method Tests
    [Fact]
    public void SetOutputValue_WhenInvoked_SetsOutputValue()
    {
        // Arrange
        var service = CreateService();

        // Act
        service.SetOutputValue("my-output", "my-value");

        // Assert
        this.mockConsoleService.VerifyOnce(m => m.WriteLine("::set-output name=my-output::my-value"));
    }

    [Fact]
    public void SetOutputValue_WithNullOrEmptyOutputName_ThrowsException()
    {
        // Arrange
        var service = CreateService();

        // Act
        var act = () => service.SetOutputValue(null, It.IsAny<string>());

        // Assert
        act.Should()
            .Throw<NullOrEmptyStringArgumentException>()
            .WithMessage("The parameter 'name' must not be null or empty.");
    }
    #endregion

    /// <summary>
    /// Creates a new instance of <see cref="ActionOutputService"/> for the purpose of testing.
    /// </summary>
    /// <returns>The instance to test.</returns>
    private ActionOutputService CreateService() => new (this.mockConsoleService.Object);
}
