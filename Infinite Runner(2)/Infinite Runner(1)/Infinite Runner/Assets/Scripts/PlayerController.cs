using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Lanes")]
    [SerializeField] private float laneOffset = 2f;
    [SerializeField, Min(1)] private int laneCount = 3;
    [SerializeField] private float laneSwitchSpeed = 14f;

    [Header("Jump")]
    [SerializeField] private float jumpVelocity = 8f;
    [SerializeField] private float gravity = -25f;

    [Header("Ground Check")]
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float groundCheckDistance = 1.1f;

    private int _laneIndex;
    private float _y;
    private float _yVel;
    private Vector2 _prevMove;
    private bool _isGrounded;

    void Awake()
    {
        if (TryGetComponent(out Rigidbody rb))
        {
            rb.isKinematic = true;
            rb.useGravity = false;
        }
    }

    public void Move(InputAction.CallbackContext ctx)
    {
        if (GameManager.Instance.IsGameOver) return;

        Vector2 v = ctx.ReadValue<Vector2>();
        if (v.x > 0.5f && _prevMove.x <= 0.5f) ChangeLane(+1);
        else if (v.x < -0.5f && _prevMove.x >= -0.5f) ChangeLane(-1);
        if (v.y > 0.5f && _prevMove.y <= 0.5f && _isGrounded) _yVel = jumpVelocity;
        _prevMove = v;
    }

    private void ChangeLane(int delta)
    {
        int half = laneCount / 2;
        _laneIndex = Mathf.Clamp(_laneIndex + delta, -half, half);
    }

    void Update()
    {
        if (GameManager.Instance.IsGameOver) return;

        // Ground check — floor (y <= 0) or walkable surface below
        bool onFloor = _y <= 0f && _yVel <= 0f;
        bool onSurface = Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit, groundCheckDistance, groundLayer);
        _isGrounded = onFloor || onSurface;

        // Gravity
        _yVel += gravity * Time.deltaTime;
        _y += _yVel * Time.deltaTime;

        // Land
        if (_isGrounded && _yVel <= 0f)
        {
            _y = onSurface ? hit.point.y : 0f;
            _yVel = 0f;
        }

        // Clamp below floor
        if (_y < 0f) { _y = 0f; _yVel = 0f; }

        Vector3 pos = transform.position;
        pos.x = Mathf.MoveTowards(pos.x, _laneIndex * laneOffset, laneSwitchSpeed * Time.deltaTime);
        pos.y = _y;
        pos.z = 0f;
        transform.position = pos;
    }
}