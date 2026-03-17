using System;
using System.Collections.Generic;
using System.Timers;

namespace Yoga.Client.Services
{
    public class ToastService
    {
        public event Action? OnChange;
        private readonly List<ToastInstance> _toasts = new();
        public IReadOnlyList<ToastInstance> Toasts => _toasts;

        public void ShowInfo(string title, string message) => ShowToast(ToastLevel.Info, title, message);
        public void ShowSuccess(string title, string message) => ShowToast(ToastLevel.Success, title, message);
        public void ShowWarning(string title, string message) => ShowToast(ToastLevel.Warning, title, message);
        public void ShowError(string title, string message) => ShowToast(ToastLevel.Error, title, message);

        private void ShowToast(ToastLevel level, string title, string message)
        {
            var toast = new ToastInstance(level, title, message);
            _toasts.Add(toast);
            OnChange?.Invoke();

            var timer = new System.Timers.Timer(5000);
            timer.Elapsed += (sender, args) =>
            {
                RemoveToast(toast);
                timer.Dispose();
            };
            timer.Start();
        }

        public void RemoveToast(ToastInstance toast)
        {
            if (_toasts.Remove(toast))
            {
                OnChange?.Invoke();
            }
        }
    }

    public class ToastInstance
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public ToastLevel Level { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.Now;

        public ToastInstance(ToastLevel level, string title, string message)
        {
            Level = level;
            Title = title;
            Message = message;
        }
    }

    public enum ToastLevel
    {
        Info,
        Success,
        Warning,
        Error
    }
}