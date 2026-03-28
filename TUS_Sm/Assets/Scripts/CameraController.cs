using UnityEngine;

public class NoclipCamera : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float fastSpeed = 25f;
    public float mouseSensitivity = 2f;

    private float rotationX = 0f;
    private float rotationY = 0f;

    Rigidbody rb;
    Vector2 moveInputs;
    Vector3 directions;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        Look();
        Move();
    }

    void Look()
    {
        rotationX += Input.GetAxis("Mouse X") * mouseSensitivity * 100f * Time.deltaTime;
        rotationY -= Input.GetAxis("Mouse Y") * mouseSensitivity * 100f * Time.deltaTime;

        rotationY = Mathf.Clamp(rotationY, -90f, 90f);

        transform.localRotation = Quaternion.Euler(rotationY, rotationX, 0f);
    }

    void Move()
    {
        moveInputs = Inputs.Instance.Move;
        directions = transform.forward * moveInputs.y + transform.right * moveInputs.x;

        float speed = Input.GetKey(KeyCode.LeftShift) ? fastSpeed : moveSpeed;

        if (Input.GetKey(KeyCode.E)) rb.linearVelocity += transform.up * speed * Time.deltaTime;
        if (Input.GetKey(KeyCode.Q)) rb.linearVelocity -= transform.up * speed * Time.deltaTime;

        rb.linearVelocity = directions * speed * Time.deltaTime;
    }
}