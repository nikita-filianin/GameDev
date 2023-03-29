﻿using Player;
using Unity.Burst;
using UnityEngine;
using UnityEngine.EventSystems;

public class ExternalDevicesInputReader : IEntityInputSource
{
    public float HorizontalDirection => Input.GetAxisRaw("Horizontal");
    public bool Jump { get; private set; }
    
        public void OnUpdate()
        {
           if (!IsPointerOverUi() && Input.GetButtonDown("Jump"))
               Jump = true;
        }

        private bool IsPointerOverUi() => !EventSystem.current.IsPointerOverGameObject();
        public void ResetOneTimeActions()
        {
            Jump = false; 
        }
}