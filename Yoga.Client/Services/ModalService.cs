using System;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;

namespace Yoga.Client.Services
{
    public class ModalService
    {
        public event Action? OnShow;
        public event Action? OnClose;

        public Type? CurrentComponentType { get; private set; }
        public Dictionary<string, object>? CurrentParameters { get; private set; }
        
        public bool IsVisible { get; private set; }

        public void Show<T>(Dictionary<string, object>? parameters = null) where T : IComponent
        {
            CurrentComponentType = typeof(T);
            CurrentParameters = parameters;
            IsVisible = true;
            OnShow?.Invoke();
        }

        public void Close()
        {
            IsVisible = false;
            CurrentComponentType = null;
            CurrentParameters = null;
            OnClose?.Invoke();
        }
    }
}
