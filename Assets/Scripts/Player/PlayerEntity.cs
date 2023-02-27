using UnityEngine;

namespace Player
{

    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerEntity : MonoBehaviour
    {
        [Header("HorizontalMovement")]
        [SerializeField] private float _horizontalSpeed;
        [SerializeField] private bool _faceRight;

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
        }

       private void Update()
       {
           _isTouchingGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, 
               groundLayer);
           if (Input.GetButtonDown("Jump") && _isTouchingGround)
           {
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
            if ((_faceRight && direction < 0) ||
            (!_faceRight && direction > 0))
            Flip();
        }

        private void Flip()
        {
            transform.Rotate(0, 180, 0);
            _faceRight = !_faceRight;
        }
    }
}

