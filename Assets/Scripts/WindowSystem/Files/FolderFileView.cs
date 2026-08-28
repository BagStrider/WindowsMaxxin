using System.Collections.Generic;
using UnityEngine;
using WindowSystem.Windows;

namespace WindowSystem.Files
{
    public class FolderFileView : FileView
    {
        [SerializeField] private List<FileView> _files = new ();

        protected override void OnEnable()
        {
            base.OnEnable();
            _window.OnClosed += OnWindowClosedHandle;
        }
        protected override void OnDisable()
        {
            base.OnDisable();
            _window.OnClosed -= OnWindowClosedHandle;
        }

        private void OnWindowClosedHandle(WindowView window)
        {
            CloseAllFiles();
        }
        
        public void CloseAllFiles()
        {
            foreach (var file in _files)
                file.Window.Hide();
        }
    }
}