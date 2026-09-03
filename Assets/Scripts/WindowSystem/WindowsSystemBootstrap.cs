using System.Collections.Generic;
using UnityEngine;
using WindowSystem.Taskbar;
using WindowSystem.Windows;

namespace WindowSystem
{
    public class WindowsSystemBootstrap : MonoBehaviour
    {
        [SerializeField] private List<WindowView> _windows = new ();
        [SerializeField] private TaskbarView _taskbarView;
        
        private void Awake()
        {
            WindowsMediator mediator = new WindowsMediator();

            foreach (WindowView window in _windows)
            {
                window.SetMediator(mediator);
            }
            
            _taskbarView.SetMediator(mediator);
        }
    }
}