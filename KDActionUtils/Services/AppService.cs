// <copyright file="AppService.cs" company="KinsonDigital">
// Copyright (c) KinsonDigital. All rights reserved.
// </copyright>

using System.Diagnostics.CodeAnalysis;

namespace KDActionUtils.Services;

/// <inheritdoc/>
[ExcludeFromCodeCoverage]
public class AppService : IAppService
{
    private readonly IConsoleService<ConsoleContext> consoleService;

    /// <summary>
    /// Initializes a new instance of the <see cref="AppService"/> class.
    /// </summary>
    /// <param name="consoleService">Writes to the console.</param>
    public AppService(IConsoleService<ConsoleContext> consoleService) => this.consoleService = consoleService;

    /// <inheritdoc/>
    public void Exit(int code)
    {
        this.consoleService.WriteLine($"Exit Code: {code}");
        Environment.Exit(code);
    }

    /// <inheritdoc/>
    public void ExitWithNoError() => Exit(0);

    /// <inheritdoc/>
    public void ExitWithException(Exception exception)
    {
        this.consoleService.BlankLine();
        this.consoleService.WriteError(exception.Message);
        this.consoleService.BlankLine();
        Exit(exception.HResult);
    }
}
