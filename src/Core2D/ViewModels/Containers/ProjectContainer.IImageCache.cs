﻿using System.Collections.Generic;
using System.Linq;
using Core2D.Renderer;

namespace Core2D.Containers
{
    /// <summary>
    /// Project image cache implementation.
    /// </summary>
    public partial class ProjectContainer : ObservableObject, IImageCache
    {
        private IDictionary<string, byte[]> _images = new Dictionary<string, byte[]>();

        private IEnumerable<IImageKey> GetKeys() => _images.Select(i => new ImageKey() { Key = i.Key }).ToList();

        /// <inheritdoc/>
        public IEnumerable<IImageKey> Keys => GetKeys();

        /// <inheritdoc/>
        public string AddImageFromFile(string path, byte[] bytes)
        {
            var name = System.IO.Path.GetFileName(path);
            var key = "Images\\" + name;

            if (_images.Keys.Contains(key))
            {
                return key;
            }

            _images.Add(key, bytes);
            Notify(nameof(Keys));
            return key;
        }

        /// <inheritdoc/>
        public void AddImage(string key, byte[] bytes)
        {
            if (_images.Keys.Contains(key))
            {
                return;
            }

            _images.Add(key, bytes);
            Notify(nameof(Keys));
        }

        /// <inheritdoc/>
        public byte[] GetImage(string key)
        {
            if (_images.TryGetValue(key, out byte[] bytes))
            {
                return bytes;
            }
            else
            {
                return null;
            }
        }

        /// <inheritdoc/>
        public void RemoveImage(string key)
        {
            _images.Remove(key);
            Notify(nameof(Keys));
        }

        /// <inheritdoc/>
        public void PurgeUnusedImages(ICollection<string> used)
        {
            foreach (var kvp in _images.ToList())
            {
                if (!used.Contains(kvp.Key))
                {
                    _images.Remove(kvp.Key);
                }
            }
            Notify(nameof(Keys));
        }
    }
}
