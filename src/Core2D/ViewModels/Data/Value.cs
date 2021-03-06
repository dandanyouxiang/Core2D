﻿using System.Collections.Generic;

namespace Core2D.Data
{
    /// <summary>
    /// Record value.
    /// </summary>
    public class Value : ObservableObject, IValue
    {
        private string _content;

        /// <inheritdoc/>
        public string Content
        {
            get => _content;
            set => Update(ref _content, value);
        }

        /// <inheritdoc/>
        public override object Copy(IDictionary<object, object> shared)
        {
            return new Value()
            {
                Name = this.Name,
                Content = this.Content
            };
        }

        /// <summary>
        /// Check whether the <see cref="Content"/> property has changed from its default value.
        /// </summary>
        /// <returns>Returns true if the property has changed; otherwise, returns false.</returns>
        public virtual bool ShouldSerializeContent() => !string.IsNullOrWhiteSpace(_content);
    }
}
