﻿using UnityEngine;

namespace VarVarGamejam.Player
{
    public interface IPlayerBehaviour
    {
        public void Enable();
        public void Disable();
        public void OnMouseMove(Vector2 mousePos);
        public void OnKeyboardInput(Vector2 input);
        public Vector2 Movement { get; }
        public GameObject TargetCamera { get; }
    }
}
