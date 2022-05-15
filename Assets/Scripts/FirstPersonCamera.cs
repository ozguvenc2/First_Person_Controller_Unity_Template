using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FirstPersonCamera : MonoBehaviour
{
    // The camera attached to the player.
    public Camera playerCamera;

    // Container variables for the mouse delta values each frame.
    public float deltaX;
    public float deltaY;

    // Container variables for the player's rotation around the X and Y axes.
    public float xRot; // Rotation around the x-axis in degrees.
    public float yRot; // Rotation around the y-axis in degrees.

    // Add a modifier to change mouse sensitivty.
    [Range(0.0f, 2.0f)]
    public float mouseSensitivity;

    




    // Start is called before the first frame update
    void Start()
    {
        playerCamera = Camera.main; // Set player camera.
        Cursor.visible = false; // Hide the cursor.

        // Set mouse sensitivty to 1 as default.
        mouseSensitivity = 1;
    }

    // Update is called once per frame
    void Update()
    {
        // Keep track of the player's x and y rottion.
        yRot += deltaX * Time.deltaTime * 60 * mouseSensitivity;
        xRot -= deltaY * Time.deltaTime * 60 * mouseSensitivity;

        // Keep the player's x rottion clamped [-90,90] degrees.
        xRot = Mathf.Clamp(xRot, -90f, 90f);

        // Rotate the camera around the x-axis.
        playerCamera.transform.localRotation = Quaternion.Euler(xRot, 0, 0);
        transform.rotation = Quaternion.Euler(0, yRot, 0);
    }

    // OnCameraLook event handler
    public void OnCameraLook(InputValue value)
    {
        // Reading the mouse deltas as a vector 2 (deltaX is the x component and deltaY is the y component)
        Vector2 inputVector = value.Get<Vector2>();
        deltaX = inputVector.x;
        deltaY = inputVector.y;
    }
}
