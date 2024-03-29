﻿// <copyright file="ConsoleService.cs" company="KinsonDigital">
// Copyright (c) KinsonDigital. All rights reserved.
// </copyright>

using System.Diagnostics.CodeAnalysis;

namespace KDActionUtils.Services;

/// <inheritdoc/>
[ExcludeFromCodeCoverage]
public class ConsoleService : IConsoleService<ConsoleContext>
{
    private const char GroupExpanded = '▼';

    /// <inheritdoc/>
    public virtual ConsoleContext ConsoleContext { get; set; } = ConsoleContext.CLI;

    /// <inheritdoc/>
    public virtual void Write(string value) => Console.Write(value);

    /// <inheritdoc/>
    public virtual void WriteLine(string value) => Console.WriteLine(value);

    /// <inheritdoc/>
    public virtual void WriteLine(string value, bool blankLineBefore, bool blankLineAfter)
    {
        if (blankLineBefore)
        {
            BlankLine();
        }

        WriteLine(value);

        if (blankLineAfter)
        {
            BlankLine();
        }
    }

    /// <inheritdoc/>
    public virtual void WriteLine(uint tabs, string value)
    {
        var allTabs = string.Empty;

        for (var i = 0; i < tabs; i++)
        {
            allTabs += "\t";
        }

        Console.WriteLine($"{allTabs}{value}");
    }

    /// <inheritdoc/>
    public virtual void BlankLine() => Console.WriteLine();

    /// <inheritdoc/>
    public virtual void StartGroup(string name) => Console.WriteLine($"{GroupExpanded}{(string.IsNullOrEmpty(name) ? "Group" : name)}");

    /// <inheritdoc/>
    public virtual void EndGroup() => Console.WriteLine("__");

    /// <inheritdoc/>
    public virtual void WriteGroup(string title, string content)
    {
        StartGroup(title);
        WriteLine(content);
        EndGroup();
    }

    /// <inheritdoc/>
    public virtual void WriteGroup(string title, string[] contentLines)
    {
        StartGroup(title);

        for (var i = 0; i < contentLines.Length; i++)
        {
            // Add a tab character when in debug mode
            var newContentLine = $"|{(i == contentLines.Length - 1 ? "__" : string.Empty)}\t{contentLines[i]}";
            WriteLine(newContentLine);
        }

        EndGroup();
    }

    /// <inheritdoc/>
    public virtual void WriteError(string value)
    {
        var currentClr = Console.ForegroundColor;
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"ERROR: {value}");
        Console.ForegroundColor = currentClr;
    }
}
