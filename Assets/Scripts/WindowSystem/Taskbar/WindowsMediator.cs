using System;
using WindowSystem.Windows;

namespace WindowSystem.Taskbar
{
    public class WindowsMediator
    {
        public event Action<WindowView> OnWindowOpened;
        public event Action<WindowView> OnWindowClosed;

        public void NotifyWindowOpened(WindowView window) => OnWindowOpened?.Invoke(window);
        public void NotifyWindowClosed(WindowView window) => OnWindowClosed?.Invoke(window);
    }
}