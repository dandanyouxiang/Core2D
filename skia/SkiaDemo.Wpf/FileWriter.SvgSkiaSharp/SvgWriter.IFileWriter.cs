﻿// Copyright (c) Wiesław Šoltés. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
using System;
using Core2D.Interfaces;
using Core2D.Project;
using Core2D.Renderer;
using Core2D.Shape;
using Renderer.SkiaSharp;

namespace FileWriter.SvgSkiaSharp
{
    /// <summary>
    /// Svg file writer.
    /// </summary>
    public partial class SvgWriter : IFileWriter
    {
        /// <inheritdoc/>
        string IFileWriter.Name { get; } = "Svg (SkiaSharp)";

        /// <inheritdoc/>
        string IFileWriter.Extension { get; } = "svg";

        /// <inheritdoc/>
        void IFileWriter.Save(string path, object item, object options)
        {
            if (string.IsNullOrEmpty(path) || item == null)
                return;

            var ic = options as IImageCache;
            if (options == null)
                return;

            IProjectExporter exporter = this;

            var renderer = new SkiaRenderer(true, 96.0);
            renderer.State.DrawShapeState.Flags = ShapeStateFlags.Printable;
            renderer.State.ImageCache = ic;

            if (item is XContainer)
            {
                exporter.Save(path, item as XContainer, renderer);
            }
            else if (item is XDocument)
            {
                throw new NotSupportedException("Saving documents as svg drawing is not supported.");
            }
            else if (item is XProject)
            {
                throw new NotSupportedException("Saving projects as svg drawing is not supported.");
            }
        }
    }
}
