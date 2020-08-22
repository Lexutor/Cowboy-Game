using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("References")]
    public Camera playerCamera;

    [Header("General")]
    public float gravityScale = -20f;

    [Header("Movent")]
    public float walkSpeed = 5f;
    public float runSpeed = 10f;

    [Header("Rotation")]
    public float rotationSensibility = 100f;

    [Header("Jump")]
    public float jumpScale = 1.9f;

    private float camera_V;
    Vector3 moveInput = Vector3.zero;
    Vector3 rotationInput = Vector3.zero;
    CharacterController characterController;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        Look();
        Move();
    }
    //movimiento del personaje
    private void Move()
    {
        if (characterController.isGrounded)
        {
            //solo movimiento de izquierda a derecha
            moveInput = new Vector3(Input.GetAxis("Horizontal"), 0f, 0);
            moveInput = Vector3.ClampMagnitude(moveInput, 1f);
            /*
            if (Input.GetButton("Sprint"))
            {
                moveInput = transform.TransformDirection(moveInput) * runSpeed;
            }
            else
            {
                moveInput = transform.TransformDirection(moveInput) * walkSpeed;
            }
            
            if (Input.GetButtonDown("Jump"))
            {
                moveInput.y = Mathf.Sqrt(jumpScale * -2f * gravityScale);
            }
            */
        }

        moveInput.y += gravityScale * Time.deltaTime;
        characterController.Move(moveInput * Time.deltaTime);
    }   
    //movimiento de la camara
    private void Look()
    {

        rotationInput.x = Input.GetAxis("Mouse X") * rotationSensibility * Time.deltaTime;
        rotationInput.y = Input.GetAxis("Mouse Y") * rotationSensibility * Time.deltaTime;

        camera_V = camera_V + rotationInput.y;
        camera_V = Mathf.Clamp(camera_V, -70, 70);

        transform.Rotate(Vector3.up * rotationInput.x);
        playerCamera.transform.localRotation = Quaternion.Euler(-camera_V, 0f, 0f);
    }
}
