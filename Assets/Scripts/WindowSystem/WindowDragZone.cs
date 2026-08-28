using UnityEngine;
using UnityEngine.EventSystems;

namespace WindowSystem
{
    public class WindowDragZone : MonoBehaviour, IDragHandler
    {
        [SerializeField] private RectTransform _windowRectTransform;
        [SerializeField] private bool _dragable = true;
        private Canvas _canvas;

        private void Awake()
        {
            _canvas = GetComponentInParent<Canvas>();
        }

        public void OnDrag(PointerEventData eventData)
        {
            if (!_dragable) return;

            float scaleFactor = _canvas != null ? _canvas.scaleFactor : 1f;
            _windowRectTransform.anchoredPosition += eventData.delta / scaleFactor;
        }
    }
}