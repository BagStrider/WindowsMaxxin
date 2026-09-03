using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using WindowSystem.Windows;

namespace WindowSystem.Files
{
    public class FileView : MonoBehaviour
    {
        public WindowView Window => _window;
        
        [SerializeField] private Button _button;
        [SerializeField] protected WindowView _window;

        [SerializeField] private Image _icon;
        [SerializeField] private TMP_Text _name;

        private void Awake()
        {
            _window.Hide();
        }

        protected virtual void OnEnable()
        {
            _button.onClick.AddListener(OpenFile);
        }
        protected virtual void OnDisable()
        {
            _button.onClick.RemoveListener(OpenFile);
        }

        public void SetIcon(Sprite sprite) => _icon.sprite = sprite;
        public void SetName(string name) => _name.text = name;
        public void SetWindow(WindowView window) => _window = window;
        
        private void OpenFile()
        {
            _window.Show();
        }
    }
}