﻿// Copyright (c) Wiesław Šoltés. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
using System;
using Core2D;
using SD = System.Diagnostics;

namespace Core2D.Log.Trace
{
    /// <summary>
    /// Trace message logger.
    /// </summary>
    public sealed class TraceLog : ILog
    {
        private readonly IServiceProvider _serviceProvider;

        private const string InformationPrefix = "Information: ";
        private const string WarningPrefix = "Warning: ";
        private const string ErrorPrefix = "Error: ";

        private string _lastMessage;
        private SD.TraceListener _listener;
        private System.IO.Stream _stream;

        /// <summary>
        /// Initializes a new instance of the <see cref="TraceLog"/> class.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        public TraceLog(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        /// <inheritdoc/>
        public string LastMessage => _lastMessage;

        private void SetLastMessage(string message) => _lastMessage = message;

        /// <inheritdoc/>
        public void Initialize(string path)
        {
            try
            {
                Close();

                _stream = new System.IO.FileStream(path, System.IO.FileMode.Append);
                _listener = new SD.TextWriterTraceListener(_stream, "listener");

                SD.Trace.Listeners.Add(_listener);
            }
            catch (Exception ex)
            {
                SD.Debug.WriteLine(ex.Message);
                SD.Debug.WriteLine(ex.StackTrace);
            }
        }

        /// <inheritdoc/>
        public void Close()
        {
            try
            {
                SD.Trace.Flush();

                if (_listener != null)
                {
                    _listener.Dispose();
                    _listener = null;
                }

                if (_stream != null)
                {
                    _stream.Dispose();
                    _stream = null;
                }
            }
            catch (Exception ex)
            {
                SD.Debug.WriteLine(ex.Message);
                SD.Debug.WriteLine(ex.StackTrace);
            }
        }

        /// <inheritdoc/>
        public void LogInformation(string message)
        {
            SD.Trace.TraceInformation(message);
            Console.WriteLine(message);
            SetLastMessage(InformationPrefix + message);
        }

        /// <inheritdoc/>
        public void LogInformation(string format, params object[] args)
        {
            SD.Trace.TraceInformation(format, args);
            Console.WriteLine(format, args);
            SetLastMessage(InformationPrefix + string.Format(format, args));
        }

        /// <inheritdoc/>
        public void LogWarning(string message)
        {
            SD.Trace.TraceWarning(message);
            Console.WriteLine(message);
            SetLastMessage(WarningPrefix + message);
        }

        /// <inheritdoc/>
        public void LogWarning(string format, params object[] args)
        {
            SD.Trace.TraceWarning(format, args);
            Console.WriteLine(format, args);
            SetLastMessage(WarningPrefix + string.Format(format, args));
        }

        /// <inheritdoc/>
        public void LogError(string message)
        {
            SD.Trace.TraceError(message);
            Console.WriteLine(message);
            SetLastMessage(ErrorPrefix + message);
        }

        /// <inheritdoc/>
        public void LogError(string format, params object[] args)
        {
            SD.Trace.TraceError(format, args);
            Console.WriteLine(format, args);
            SetLastMessage(ErrorPrefix + string.Format(format, args));
        }

        /// <inheritdoc/>
        public void LogException(Exception ex)
        {
            LogError($"{ex.Message}{Environment.NewLine}{ex.StackTrace}");
            if (ex.InnerException != null)
            {
                LogException(ex.InnerException);
            }
        }

        /// <summary>
        /// Dispose resources.
        /// </summary>
        public void Dispose()
        {
            Close();
        }
    }
}
