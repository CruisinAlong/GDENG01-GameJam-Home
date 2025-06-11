using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 1f;
    public float rotationSpeed = 45f;
    public Transform cameraTransform;
    public Vector3 cameraOffset = new Vector3(0, 2, -4);

    public float liftSpeed = 1f; // Simple upward speed

    public GameObject mode4Object; // Assign in Inspector (the GameObject to activate in mode 4)

    public static bool isMoving = false;
    
    public LayerMask layerMask;

    private void Start()
    {
        if (cameraTransform == null)
        {
            cameraTransform = Camera.main.transform;
        }
    }

    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

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

        // Simple lift upwards with spacebar
        if (Input.GetKey(KeyCode.Space))
        {
            transform.position += Vector3.up * liftSpeed * Time.deltaTime;
        }

        // Set isMoving to true if any movement input is detected
        isMoving = Mathf.Abs(horizontal) > 0.01f || Mathf.Abs(vertical) > 0.01f;

        // Camera follows the player's back at all costs
        if (cameraTransform != null)
        {
            cameraTransform.position = transform.position + transform.rotation * cameraOffset;
            cameraTransform.LookAt(transform.position);
        }

        // Activate/deactivate the mode 4 object based on PlayerModeManager
        if (mode4Object != null)
        {
            bool shouldBeActive = PlayerModeManager.Instance != null &&
                                  PlayerModeManager.Instance.currentMode == PlayerMode.Mode4;
            if (mode4Object.activeSelf != shouldBeActive)
                mode4Object.SetActive(shouldBeActive);
        
        Debug.DrawRay(transform.position, transform.up, Color.red);
    }

    private void FixedUpdate()
    {
        bool touchGround = Physics.Raycast(transform.position, transform.up, 10f, layerMask);
        Debug.Log(touchGround);
        if (touchGround)
        {
            Debug.Log("True");
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
        }
    }
}
