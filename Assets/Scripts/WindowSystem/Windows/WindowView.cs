using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using Button = UnityEngine.UI.Button;

namespace WindowSystem.Windows
{
    public class WindowView : MonoBehaviour,IPointerDownHandler
    {
        public event Action<WindowView> OnClosed;
        public event Action<WindowView> OnOpened;
        
        [SerializeField] private Button _closeButton;
        [SerializeField] private TMP_Text _title;
        [SerializeField] private RectTransform _rectTransform;


        protected virtual void OnEnable()
        {
            _closeButton.onClick.AddListener(Hide);
        }
        protected virtual void OnDisable()
        {
            _closeButton.onClick.RemoveListener(Hide);
        }
        
        public virtual void Show()
        {
            if(gameObject.activeSelf) return;
            
            gameObject.SetActive(true);
            OnOpened?.Invoke(this);
        }
        public void Hide()
        {
            if(!gameObject.activeSelf) return;
            
            gameObject.SetActive(false);
            OnClosed?.Invoke(this);
        }

        public void SetTitle(string title) => _title.text = title;
        
        public void OnPointerDown(PointerEventData eventData)
        {
            _rectTransform.SetAsLastSibling();
        }
    }
}