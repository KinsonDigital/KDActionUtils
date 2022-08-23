// <copyright file="Enums.cs" company="KinsonDigital">
// Copyright (c) KinsonDigital. All rights reserved.
// </copyright>

namespace KDActionUtils;

/// <summary>
/// The type of console that is being used.
/// </summary>
public enum ConsoleContext
{
    /// <summary>
    /// The GitHub action output console.
    /// </summary>
    GitHubAction = 1,

    /// <summary>
    /// The standard local CLI console.
    /// </summary>
    CLI = 2,
}
