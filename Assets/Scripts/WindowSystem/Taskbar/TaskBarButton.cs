using UnityEngine;
using UnityEngine.UI;
using WindowSystem.Windows;

namespace WindowSystem.Taskbar
{
    public class TaskBarButton : MonoBehaviour
    {
        [SerializeField] private Button _button;
        [SerializeField] private Image _icon;
        [SerializeField] private WindowView _window;
        
        private void OnEnable()
        {
            _button.onClick.AddListener(ToggleWindow);
        }
        private void OnDisable()
        {
            _button.onClick.RemoveListener(ToggleWindow);
        }

        public void SetWindow(WindowView window) => _window = window;
        public void SetIcon(Sprite icon) => _icon.sprite = icon;
        
        private void ToggleWindow()
        {
            if(_window == null) return;
            
            if (_window.IsOpen)
            {
                _window.Hide();
            }
            else
            {
                _window.Show();
            }
        }
    }
}