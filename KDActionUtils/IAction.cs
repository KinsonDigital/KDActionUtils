﻿// <copyright file="IAction.cs" company="KinsonDigital">
// Copyright (c) KinsonDigital. All rights reserved.
// </copyright>

namespace KDActionUtils;

/// <summary>
/// A GitHub action to be executed.
/// </summary>
/// <typeparam name="TInputs">The action inputs.</typeparam>
/// <typeparam name="TResult">The result of the github action.</typeparam>
public interface IGitHubAction<in TInputs, out TResult> : IDisposable
{
    /// <summary>
    /// Runs the action.
    /// </summary>
    /// <param name="inputs">The inputs of the action.</param>
    /// <param name="onCompleted">Executed once the action has completed with the result of the action of type <typeparamref name="TResult"/>.</param>
    /// <param name="onError">Executed when the action runs into an error.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    /// <remarks>
    ///     The <paramref name="onCompleted"/> <see cref="Action"/> is not executed
    ///     if the <paramref name="onError"/> has been executed.
    /// </remarks>
    Task Run(TInputs inputs, Action<TResult> onCompleted, Action<Exception> onError);
}
