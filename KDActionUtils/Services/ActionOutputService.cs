// <copyright file="ActionOutputService.cs" company="KinsonDigital">
// Copyright (c) KinsonDigital. All rights reserved.
// </copyright>

using KDActionUtils.Exceptions;

namespace KDActionUtils.Services;

/// <inheritdoc/>
public class ActionOutputService : IActionOutputService
{
    private readonly IConsoleService<ConsoleContext> consoleService;

    /// <summary>
    /// Initializes a new instance of the <see cref="ActionOutputService"/> class.
    /// </summary>
    /// <param name="consoleService">Writes to the console.</param>
    public ActionOutputService(IConsoleService<ConsoleContext> consoleService) => this.consoleService = consoleService;

    /// <inheritdoc/>
    public void SetOutputValue(string name, string value)
    {
        if (string.IsNullOrEmpty(name))
        {
            throw new NullOrEmptyStringArgumentException($"The parameter '{nameof(name)}' must not be null or empty.");
        }

        this.consoleService.WriteLine($"::set-output name={name}::{value}");
    }
}
