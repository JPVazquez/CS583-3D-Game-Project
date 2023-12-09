using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerControl : MonoBehaviour
{

    public bool debugMode;
    private TextMeshPro cameraDebug;
    private List<string> errorMessages;

    public float sensX;
    public float sensY;

    public Transform orientation;

    float xRotation;
    float yRotation;

    private Transform cameraPosition;


    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        cameraPosition = GetComponentInParent<AttachToPlayer>().cameraPosition;
    }

    // Update is called once per frame
    void Update()
    {
        float clampOffset = 0; //cameraPosition.transform.rotation.eulerAngles.x;
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

        yRotation += mouseX;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, clampOffset + -90f, clampOffset + 90f);

        transform.localRotation= Quaternion.Euler(xRotation, yRotation, 0);
        orientation.localRotation = Quaternion.Euler(orientation.localRotation.eulerAngles.x, yRotation, 0);

        //if (debugMode) {
        //    errorMessages = new List<string>();

        //    // Add each variable we want to display to errorMessages list and combine with newLine
        //    string cameraLocalRotation = "";
        //    string orientationRotationY = "";
        //    string xInput = "";

        //    cameraLocalRotation = "cameraLocalRotation: " + transform.rotation.eulerAngles.ToString();
        //    errorMessages.Add(cameraLocalRotation);

        //    orientationRotationY = "orientationRotationY: " + yRotation.ToString();
        //    errorMessages.Add(orientationRotationY);

        //    xInput = "clampedXRotation: " + xRotation.ToString();
        //    errorMessages.Add(xInput);

        //    cameraDebug.SetText(string.Join(System.Environment.NewLine, errorMessages));
        //}
        
    }
}
