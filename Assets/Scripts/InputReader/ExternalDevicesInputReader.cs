
using System;
using Core.Services.Updater;
using UnityEngine;
using UnityEngine.EventSystems;

namespace InputReader
{
    public class ExternalDevicesInputReader : IEntityInputSource, IDisposable
    {
        public float HorizontalDirection => Input.GetAxisRaw("Horizontal");
        public bool Jump { get; private set; }

        public ExternalDevicesInputReader()
        {
            ProjectUpdater.Instance.UpdateCalled += OnUpdate;
        }
        
        public void ResetOneTimeActions()
        {
            Jump = false;
        }
        
        public void Dispose() => ProjectUpdater.Instance.UpdateCalled -= OnUpdate;
        private void OnUpdate()
        {
            if (!IsPointerOverUi() && Input.GetButtonDown("Jump"))
                Jump = true;
        }
        private bool IsPointerOverUi() => !EventSystem.current.IsPointerOverGameObject();
    }
}