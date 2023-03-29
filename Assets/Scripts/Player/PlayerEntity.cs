using Cinemachine;
using Core.Enums;
using Core.Tools;
using UnityEngine;
using UnityEngine.UIElements;

namespace Player
{

    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerEntity : MonoBehaviour
    {
        [Header("HorizontalMovement")]
        [SerializeField] private float _horizontalSpeed;
        [SerializeField] private Direction _direction;
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
        private float _startJumpVerticalPosition;

        // Start is called before the first frame update
       private void Start()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _endLvlCamera.enabled = true;
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
       public void MoveHorizontally(float direction)
        {
            SetDirection(direction);
            Vector2 velocity = _rigidbody.velocity;
            velocity.x = direction * _horizontalSpeed;
            _rigidbody.velocity = velocity;
        }


        private void SetDirection(float direction)
        {
            if ((_direction == Direction.Right && direction < 0) ||
            (_direction == Direction.Left && direction > 0))
            Flip();
        }

        private void Flip()
        {
            transform.Rotate(0, 180, 0);
            _direction = _direction == Direction.Right ? Direction.Left : Direction.Right;
            foreach (var cameraPair in _cameras.DirectionalCameras)
                cameraPair.Value.enabled = cameraPair.Key == _direction;
        }
    }
}

