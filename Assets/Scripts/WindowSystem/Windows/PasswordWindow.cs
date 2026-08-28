using System;
using TMPro;
using UnityEngine;

namespace WindowSystem.Windows
{
    public class PasswordWindow : WindowView
    {
        public event Action<string> OnInput;
        
        [SerializeField] private TMP_InputField _input;

        protected override void OnEnable()
        {
            base.OnEnable();
            _input.onValueChanged.AddListener(OnInputChanged);
        }
        protected override void OnDisable()
        {
            base.OnDisable();
            _input.onValueChanged.RemoveListener(OnInputChanged);
        }

        private void OnInputChanged(string value)
        {
            OnInput?.Invoke(value);
        }
    }
}