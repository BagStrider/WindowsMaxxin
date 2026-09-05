using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using WindowSystem.Files;
using WindowSystem.Taskbar;
using Button = UnityEngine.UI.Button;

namespace WindowSystem.Windows
{
    public class WindowView : MonoBehaviour,IPointerDownHandler
    {
        public event Action<WindowView> OnClosed;
        public event Action<WindowView> OnOpened;
        public event Action<WindowView> OnHided;

        public WindowConfig Config => _config;
        public bool IsOpen => gameObject.activeSelf;
        
        [SerializeField] private WindowConfig _config;
        [SerializeField] private Button _closeButton;
        [SerializeField] private Button _hideButton;
        [SerializeField] private TMP_Text _title;
        [SerializeField] private RectTransform _rectTransform;

        private WindowsMediator _mediator;

        private void Awake()
        {
            if(!_config) return;

            _title.text = _config.FileName;
        }

        protected virtual void OnEnable()
        {
            _closeButton.onClick.AddListener(Close);
            _hideButton.onClick.AddListener(Hide);
        }
        protected virtual void OnDisable()
        {
            _closeButton.onClick.RemoveListener(Close);
            _hideButton.onClick.RemoveListener(Hide);
        }
        
        public virtual void Show()
        {
            if(gameObject.activeSelf) return;
            
            gameObject.SetActive(true);
            OnOpened?.Invoke(this);
            _mediator?.NotifyWindowOpened(this);
        }
        public void Hide()
        {
            if(!gameObject.activeSelf) return;
            
            gameObject.SetActive(false);
            OnHided?.Invoke(this);
        }

        public void Close()
        {
            if(!gameObject.activeSelf) return;
            
            gameObject.SetActive(false);
            OnClosed?.Invoke(this);
            _mediator?.NotifyWindowClosed(this);
        }

        public void SetTitle(string title) => _title.text = title;
        public void OnPointerDown(PointerEventData eventData)
        {
            _rectTransform.SetAsLastSibling();
        }

        public void SetMediator(WindowsMediator mediator) => _mediator =  mediator;
    }
}