﻿using System.ComponentModel;

namespace Avalonia.Rendering
{
    /// <summary>
    /// Manages configurable diagnostics that can be displayed by a renderer.
    /// </summary>
    public class RendererDiagnostics : INotifyPropertyChanged
    {
        private RendererDebugOverlays _debugOverlays;
        private LayoutPassTiming _lastLayoutPassTiming;
        private string? _renderedFramesPath;

        private static PropertyChangedEventArgs s_debugOverlaysChangedEventArgs = new(nameof(DebugOverlays));
        private static PropertyChangedEventArgs s_lastLayoutPassTimingChangedEventArgs =
            new(nameof(LastLayoutPassTiming));

        private static PropertyChangedEventArgs? s_renderedFramesPathChangedEventArgs = new(nameof(RenderedFramesPath));
        
        /// <summary>
        /// Gets or sets which debug overlays are displayed by the renderer.
        /// </summary>
        public RendererDebugOverlays DebugOverlays
        {
            get => _debugOverlays;
            set
            {
                if (_debugOverlays != value)
                {
                    _debugOverlays = value;
                    OnPropertyChanged(s_debugOverlaysChangedEventArgs ??= new(nameof(DebugOverlays)));
                }
            }
        }

        public string? RenderedFramesPath
        {
            get => _renderedFramesPath;
            set
            {
                if (_renderedFramesPath != value)
                {
                    _renderedFramesPath = value;
                    OnPropertyChanged(new(nameof(RenderedFramesPath)));
                }
            }
        }

        /// <summary>
        /// Gets or sets the last layout pass timing that the renderer may display.
        /// </summary>
        internal LayoutPassTiming LastLayoutPassTiming
        {
            get => _lastLayoutPassTiming;
            set
            {
                if (!_lastLayoutPassTiming.Equals(value))
                {
                    _lastLayoutPassTiming = value;
                    OnPropertyChanged(s_lastLayoutPassTimingChangedEventArgs ??= new(nameof(LastLayoutPassTiming)));
                }
            }
        }

        /// <inheritdoc />
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// Called when a property changes on the object.
        /// </summary>
        /// <param name="args">The property change details.</param>
        protected virtual void OnPropertyChanged(PropertyChangedEventArgs args)
            => PropertyChanged?.Invoke(this, args);
    }
}
