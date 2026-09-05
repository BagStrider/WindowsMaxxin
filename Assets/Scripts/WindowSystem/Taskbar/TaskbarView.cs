using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using WindowSystem.Windows;

namespace WindowSystem.Taskbar
{
    public class TaskbarView : MonoBehaviour
    {
        [SerializeField] private Button _winButton;
        [SerializeField] private WindowView _startMenu;
        
        [Header("Taskbar Buttons")]
        [SerializeField] private TaskBarButton _taskBarButtonPrefab;
        [SerializeField] private Transform _buttonsContainer;

        private Dictionary<WindowView, TaskBarButton> _registeredWindows = new ();
        private WindowsMediator _mediator;
        
        private void OnEnable()
        {
            _winButton.onClick.AddListener(ToggleStartMenu);
            _mediator.OnWindowOpened += OnWindowOpenedHandle;
            _mediator.OnWindowClosed += OnwindowClosedHandle;
        }
        private void OnDisable()
        {
            _winButton.onClick.RemoveListener(ToggleStartMenu);
            _mediator.OnWindowOpened -= OnWindowOpenedHandle;
            _mediator.OnWindowClosed -= OnwindowClosedHandle;
        }

        private void OnWindowOpenedHandle(WindowView window)
        {
            if(_registeredWindows.ContainsKey(window)) return;
            
            TaskBarButton button = Instantiate(_taskBarButtonPrefab, _buttonsContainer.transform);
            button.SetWindow(window);
            button.SetIcon(window.Config.TaskbarIcon);
            
            _registeredWindows.Add(window, button);
        }
        private void OnwindowClosedHandle(WindowView window)
        {
            if (_registeredWindows.ContainsKey(window))
            {
                Destroy(_registeredWindows[window].gameObject);
                _registeredWindows.Remove(window);
            }
        }
        
        private void ToggleStartMenu()
        {
            if (_startMenu.IsOpen)
            {
                _startMenu.Hide();
            }
            else
            {
                _startMenu.Show();
            }
        }
        
        public void SetMediator(WindowsMediator mediator) => _mediator =  mediator;
    }
}
