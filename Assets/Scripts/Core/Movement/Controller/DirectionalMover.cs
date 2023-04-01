﻿using Core.Enums;
using Core.Movement.Data;
using UnityEngine;

namespace Core.Movement.Controller
{
    public class DirectionalMover
    {
        private readonly Rigidbody2D _rigidbody;
        private readonly Transform _transform;
        private readonly DirectionalMovementData _directionalMovementData;
        
        
        public Direction Direction { get; private set; }
        
        public DirectionalMover(Rigidbody2D rigidbody,  DirectionalMovementData directionalMovementData)
        {
            _rigidbody = rigidbody;
            _transform = _rigidbody.transform;
            _directionalMovementData = directionalMovementData;
        }
        public void MoveHorizontally(float direction)
        {
            SetDirection(direction);
            Vector2 velocity = _rigidbody.velocity;
            velocity.x = direction * _directionalMovementData.HorizontalSpeed;
            _rigidbody.velocity = velocity;
        }
        private void SetDirection(float direction)
        {
            if ((Direction == Direction.Right && direction < 0) ||
                (Direction == Direction.Left && direction > 0))
                Flip();
        }

        private void Flip()
        {
            _transform.Rotate(0, 180, 0);
            Direction = Direction == Direction.Right ? Direction.Left : Direction.Right;
        }
    }
}