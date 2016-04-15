﻿// Copyright (c) Wiesław Šoltés. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
using Perspex;
using Perspex.Controls;

namespace Core2D.Perspex.Windows
{
    /// <summary>
    /// Interaction logic for <see cref="BrowserWindow"/> xaml.
    /// </summary>
    public class BrowserWindow : Window
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BrowserWindow"/> class.
        /// </summary>
        public BrowserWindow()
        {
            this.InitializeComponent();
            this.AttachDevTools();
        }

        /// <summary>
        /// Initialize the Xaml components.
        /// </summary>
        private void InitializeComponent()
        {
            this.LoadFromXaml();
        }
    }
}
