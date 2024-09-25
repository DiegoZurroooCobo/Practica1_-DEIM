using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonCamera : MonoBehaviour
{
    public float mouseSens;
    public Transform playerTransform;

    private float mouseYRotation;
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // al hacer click en la pantalla del juego, el raton se vuelve invisible 
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSens * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSens * Time.deltaTime;
        mouseYRotation -= mouseY;

        mouseYRotation = Mathf.Clamp(mouseYRotation, -90, 90); // el clamp limita el movimiento de la camara dentro de unos limites


        //Eurelianos. Angulos normales.
        transform.localEulerAngles = Vector3.right * mouseYRotation;

        playerTransform.Rotate(Vector3.up * mouseX); 
    }
}
