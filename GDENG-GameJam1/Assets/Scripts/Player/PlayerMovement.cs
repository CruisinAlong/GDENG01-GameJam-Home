using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotationSpeed = 720f;
    public Transform cameraTransform;
    public Vector3 cameraOffset = new Vector3(0, 2, -4);

    private void Start()
    {
        if (cameraTransform == null)
        {
            // Try to find the main camera if not assigned
            cameraTransform = Camera.main.transform;
        }
    }

    private void Update()
    {
        // Get input
        float horizontal = Input.GetAxis("Horizontal"); // A/D or Left/Right arrows
        float vertical = Input.GetAxis("Vertical");     // W/S or Up/Down arrows

        // Only rotate around the Y axis (player's own up axis) with A/D
        if (Mathf.Abs(horizontal) > 0.01f)
        {
            float yRotation = horizontal * rotationSpeed * Time.deltaTime;
            transform.Rotate(Vector3.up, yRotation, Space.Self);
        }

        // Move forward/backward in the direction the player is facing (W/S)
        if (Mathf.Abs(vertical) > 0.01f)
        {
            Vector3 moveDir = transform.forward * vertical;
            transform.position += moveDir.normalized * moveSpeed * Time.deltaTime;
        }

        // Camera follows the player's back at all costs
        if (cameraTransform != null)
        {
            cameraTransform.position = transform.position + transform.rotation * cameraOffset;
            cameraTransform.LookAt(transform.position);
        }
    }
}
