using UnityEngine;

namespace WindowSystem.Files
{
    
    [CreateAssetMenu(fileName = nameof(WindowConfig), menuName = nameof(WindowConfig))]
    public class WindowConfig : ScriptableObject
    {
        public string FileName => _fileName;
        public Sprite Icon => _icon;
        public Sprite TaskbarIcon => _taskbarIcon;
        
        [SerializeField] private string _fileName;
        [SerializeField] private Sprite _icon;
        [SerializeField] private Sprite _taskbarIcon;

    }
}