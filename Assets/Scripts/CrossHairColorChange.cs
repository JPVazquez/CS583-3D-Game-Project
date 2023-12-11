using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrossHairColorChange : MonoBehaviour
{
    public float raycastLength = 10f;
    private RawImage crosshair;
    public Color defaultColor = Color.white;
    public Color wallCloseColor = Color.green;

    // Start is called before the first frame update
    void Start()
    {
        crosshair = GetComponent<RawImage>();
    }

    // Update is called once per frame
    void Update()
    {
        // Create a ray from the center of the screen
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));

        RaycastHit hit;

        // Perform the raycast with the specified length
        if (!Physics.Raycast(ray, out hit, raycastLength, GetComponentInParent<PlayerMovement>().groundCheck))
        {
            crosshair.color = defaultColor;
        }

        else
        {
            crosshair.color = wallCloseColor;
        }
    }
}
