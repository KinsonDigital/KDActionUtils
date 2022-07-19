// <copyright file="GitHubConsoleService.cs" company="KinsonDigital">
// Copyright (c) KinsonDigital. All rights reserved.
// </copyright>

using System.Diagnostics.CodeAnalysis;

namespace KDActionUtils.Services;

#pragma warning disable SA1515

/// <summary>
/// Provides functionality for writing to a GitHub action console.
/// </summary>
[ExcludeFromCodeCoverage]
// ReSharper disable UnusedType.Global
public class GitHubConsoleService : ConsoleService
// ReSharper restore UnusedType.Global
{
    private bool prevPrintWasWrite;

    /// <inheritdoc/>
    public override ConsoleContext ConsoleContext { get; set; } = ConsoleContext.GitHubAction;

    /// <inheritdoc/>
    public override void Write(string value)
    {
        base.Write(value);
        this.prevPrintWasWrite = true;
    }

    /// <inheritdoc/>
    public override void WriteLine(string value)
    {
        base.WriteLine(value);
        this.prevPrintWasWrite = false;
    }

    /// <inheritdoc/>
    public override void WriteLine(uint tabs, string value)
    {
        base.WriteLine(tabs, value);
        this.prevPrintWasWrite = false;
    }

    /// <inheritdoc/>
    public override void BlankLine()
    {
        base.BlankLine();
        this.prevPrintWasWrite = false;
    }

    /// <inheritdoc/>
    /// <exception cref="ArgumentOutOfRangeException">
    ///     Thrown if the <see cref="IConsoleService{T}.ConsoleContext"/> is an invalid value.
    /// </exception>
    public override void StartGroup(string name)
    {
        var newlinePrefix = this.prevPrintWasWrite ? Environment.NewLine : string.Empty;
        Console.WriteLine($"{newlinePrefix}::group::{(string.IsNullOrEmpty(name) ? "Group" : name)}");
        this.prevPrintWasWrite = false;
    }

    /// <inheritdoc/>
    public override void EndGroup()
    {
        var newlinePrefix = this.prevPrintWasWrite ? Environment.NewLine : string.Empty;
        Console.WriteLine($"{newlinePrefix}::endgroup::");
    }

    /// <inheritdoc/>
    public override void WriteError(string value)
    {
        var newlinePrefix = this.prevPrintWasWrite ? Environment.NewLine : string.Empty;
        Console.WriteLine($"{newlinePrefix}::error::{value}");
        this.prevPrintWasWrite = false;
    }
}
