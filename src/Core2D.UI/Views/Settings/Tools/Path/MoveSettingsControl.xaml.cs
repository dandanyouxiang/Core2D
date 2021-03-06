﻿using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Core2D.UI.Views.Settings.Tools.Path
{
    /// <summary>
    /// Interaction logic for <see cref="MoveSettingsControl"/> xaml.
    /// </summary>
    public class MoveSettingsControl : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MoveSettingsControl"/> class.
        /// </summary>
        public MoveSettingsControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Initialize the Xaml components.
        /// </summary>
        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
