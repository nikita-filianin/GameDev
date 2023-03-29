using Cinemachine;
using Core.Enums;
using Core.Movement.Controller;
using Core.Movement.Data;
using Core.Tools;
using UnityEngine;

namespace Player
{

    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerEntity : MonoBehaviour
    {
        [SerializeField] private DirectionalMovementData _directionalMovementData;
        
        [SerializeField] private DirectionalCameraPair _cameras;
        [SerializeField] private CinemachineVirtualCamera _endLvlCamera;
        [SerializeField] private Camera _mainCamera;
        

        [Header("Jump")]
        public Transform groundCheck;
        public float groundCheckRadius;
        public LayerMask groundLayer;
        public float jumpSpeed = 6f;
        
        private bool _isTouchingGround;
        private Rigidbody2D _rigidbody;
        private Rigidbody2D _player;

        private DirectionalMover _directionalMover;
        
       private void Start()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _endLvlCamera.enabled = true;
            _directionalMover = new DirectionalMover(_rigidbody, _directionalMovementData);
        }
       
       private void Update()
       {
           _isTouchingGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, 
               groundLayer);

           if (_mainCamera.transform.position == _endLvlCamera.transform.position)
           {
               _endLvlCamera.enabled = false;
           }
       }
       public void Jump()
       {
           if (_isTouchingGround)
           {
               _isTouchingGround = false;
               _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, jumpSpeed);
           }
       }

       public void MoveHorizontally(float direction) => _directionalMover.MoveHorizontally(direction);
       
       private void UpdateCameras()
       {
           foreach (var cameraPair in _cameras.DirectionalCameras)
           {
               cameraPair.Value.enabled = cameraPair.Key == _directionalMover.Direction;
           }
       }
    }
}

