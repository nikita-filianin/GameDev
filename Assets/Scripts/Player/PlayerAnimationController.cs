
using UnityEngine;

namespace Player
{
    public class PlayerAnimationController : MonoBehaviour
    {
        private bool _isTouchingGround;
        private Animator _playerAnimation;
        private Rigidbody2D _player;
        
        public Transform groundCheck;
        public float groundCheckRadius;
        public LayerMask groundLayer;
        
        void Start()
        {
            _player = GetComponent<Rigidbody2D>();
            _playerAnimation = GetComponent<Animator>();
        }

        // Update is called once per frame
        void Update()
        {
            _isTouchingGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, 
                groundLayer);
            
            _playerAnimation.SetFloat("Speed", Mathf.Abs(_player.velocity.x));
            _playerAnimation.SetBool("OnGround", _isTouchingGround);
        }
    }
}
