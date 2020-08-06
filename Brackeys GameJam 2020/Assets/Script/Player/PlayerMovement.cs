using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float currentSpeed;
    public float defaultSpeed;
    public float sprintSpeed;

    public float dashDistance;

    public float mouseSensitivity;
    public float jumpHeight;
    public float raycastDistance;

    private float rotateY, rotateX;

    public Camera playerCam;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();

        PlayerRotationHorizontal();
        PlayerRotationVertical();

        if (Input.GetKey(KeyCode.LeftShift))
        {
            currentSpeed = sprintSpeed;
        }
        else
        {
            currentSpeed = defaultSpeed;
        }
    }

    private void Move()
    {
        float hAxis = Input.GetAxis("Horizontal");
        float vAxis = Input.GetAxis("Vertical");

        Vector3 playerVelocity = new Vector3(hAxis, 0, vAxis);
        playerVelocity *= currentSpeed;
        playerVelocity = transform.TransformDirection(playerVelocity);

        var velocityChange = playerVelocity - rb.velocity;

        velocityChange.y = 0;

        rb.AddForce(velocityChange, ForceMode.VelocityChange);
    }

    private void Update()
    {
        Jump();
    }
    void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if(IsGrounded())
                rb.AddForce(0, jumpHeight, 0, ForceMode.Impulse);
        }
    }

    private bool IsGrounded()
    {
        return (Physics.Raycast(transform.position, Vector3.down, raycastDistance));
    }

    void PlayerRotationHorizontal()
    {
        rotateY = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;

        transform.Rotate(0, rotateY, 0);
    }

    void PlayerRotationVertical()
    {
        rotateX -= Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        float clampedRotation = Mathf.Clamp(rotateX, -90, 90);

        playerCam.transform.rotation = Quaternion.Euler(clampedRotation, transform.eulerAngles.y, transform.eulerAngles.z);
    }
}
