﻿using System.Collections.Generic;
using System.ComponentModel;

namespace Core2D.Common.UnitTests
{
    public class PropertyChangedObserver
    {
        public List<string> PropertyNames { get; } = new List<string>();

        public PropertyChangedObserver(INotifyPropertyChanged observable)
        {
            observable.PropertyChanged += (sender, e) => PropertyNames.Add(e.PropertyName);
        }
    }
}
