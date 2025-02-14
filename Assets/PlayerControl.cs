using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float mouseSensitivity = 2f;
    public float jumpForce = 7f;
    public Transform groundCheck;
    public LayerMask groundMask;

    private Rigidbody _rb;
    private float _rotationX ;
    private bool _isGrounded;
    private Camera _mainCamera;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        _mainCamera = Camera.main;

    }

    void Update()
    {
        Rotate();
    }

    void FixedUpdate()
    {
        Move();
        Jump();
    }

    void Move()
    {
        var moveX = Input.GetAxis("Horizontal");
        var moveZ = Input.GetAxis("Vertical");

        Vector3 moveDirection = (transform.right * moveX + transform.forward * moveZ).normalized * moveSpeed;
        moveDirection.y = _rb.linearVelocity.y; 

        _rb.linearVelocity = moveDirection;  
    }


     void Rotate()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        transform.Rotate(Vector3.up * mouseX);

        _rotationX -= mouseY;
        _rotationX = Mathf.Clamp(_rotationX, -90f, 90f);

        if (!ReferenceEquals(_mainCamera, null))
            _mainCamera.transform.localRotation = Quaternion.Euler(_rotationX, 0f, 0f);
    }

    void Jump()
    {
        _isGrounded = Physics.CheckSphere(groundCheck.position, 0.2f, groundMask);

        if (_isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            _rb.linearVelocity = new Vector3(_rb.linearVelocity.x, jumpForce, _rb.linearVelocity.z);
        }
    }
}