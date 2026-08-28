using TMPro;
using UnityEngine;

namespace WindowSystem.Windows
{
    public class TextWindow : WindowView
    {
        [SerializeField] private TMP_Text _text;
        
        public void SetText(string text) => _text.text = text;
    }
}