using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float m_playerSpeed = 5.0f;

    [SerializeField]
    private float m_mouseSensitivity = 3.0f;

    private float yaw = 0.0f;
    private float pitch = 0.0f;

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Movement()
    {
        var c = Camera.main.transform;

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        c.position += c.forward * verticalInput * m_playerSpeed * Time.deltaTime;
        c.position += c.right * horizontalInput * m_playerSpeed * Time.deltaTime;

        if (Mouse.current.rightButton.IsPressed())
        {
            yaw += m_mouseSensitivity * Input.GetAxis("Mouse X");
            pitch -= m_mouseSensitivity * Input.GetAxis("Mouse Y");

            c.eulerAngles = new Vector3(pitch, yaw, 0.0f);
        }
    }
}
