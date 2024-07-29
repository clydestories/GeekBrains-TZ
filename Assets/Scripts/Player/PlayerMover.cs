using UnityEngine;

[RequireComponent (typeof(Rigidbody))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _movementSpeed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _groundCheckRadius;
    [SerializeField] private float _maxGroundCheckDistance;
    [SerializeField] private LayerMask _GroundCheckLayers;

    private Rigidbody _rigidbody;
    private bool _isGrounded = false;

    public bool IsGrounded => _isGrounded;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        CheckGround();
    }

    public void Move(Vector3 inputDirection)
    {
        Vector3 movementDirection = inputDirection.x * transform.right + inputDirection.z * transform.forward;
        movementDirection *= _movementSpeed;
        movementDirection.y = _rigidbody.velocity.y;
        _rigidbody.velocity = movementDirection;
    }

    public void Jump()
    {
        if (_isGrounded)
        {
            _rigidbody.velocity = Vector3.up * _jumpForce;
        }
    }

    private void CheckGround()
    {
        RaycastHit[] hits = Physics.CapsuleCastAll
            (
                transform.position + Vector3.up,
                transform.position,
                _groundCheckRadius,
                Vector3.down,
                _maxGroundCheckDistance,
                _GroundCheckLayers
            );

        if (hits.Length > 0)
        {
            _isGrounded = true;
        }
        else
        {
            _isGrounded = false;
        }
    }
}
