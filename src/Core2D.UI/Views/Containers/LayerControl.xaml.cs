﻿using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Core2D.UI.Views.Containers
{
    /// <summary>
    /// Interaction logic for <see cref="LayerControl"/> xaml.
    /// </summary>
    public class LayerControl : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LayerControl"/> class.
        /// </summary>
        public LayerControl()
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
