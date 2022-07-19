// <copyright file="GitHubConsoleService.cs" company="KinsonDigital">
// Copyright (c) KinsonDigital. All rights reserved.
// </copyright>

using System.Diagnostics.CodeAnalysis;

namespace KDActionUtils.Services;

/// <summary>
/// Provides functionality for writing to a GitHub action console.
/// </summary>
[ExcludeFromCodeCoverage]
public class GitHubConsoleService : ConsoleService
{
    /// <inheritdoc/>
    public override ConsoleContext ConsoleContext { get; set; } = ConsoleContext.GitHubAction;

    /// <inheritdoc/>
    /// <exception cref="ArgumentOutOfRangeException">
    ///     Thrown if the <see cref="IConsoleService{T}.ConsoleContext"/> is an invalid value.
    /// </exception>
    public override void StartGroup(string name)
        => Console.WriteLine($"::group::{(string.IsNullOrEmpty(name) ? "Group" : name)}");

    /// <inheritdoc/>
    public override void EndGroup() => Console.WriteLine("::endgroup::");

    /// <inheritdoc/>
    public override void WriteError(string value) => Console.WriteLine($"::error::{value}");
}
