using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{

    private bool isHoldingItem;
    private RaycastHit pickedUpItem;
    private float ogDistance;

    [Header("ItemPickupCheck")]
    public LayerMask canBePickedUp;
    public Transform forwardDirection;


    // Start is called before the first frame update
    void Start()
    {
        isHoldingItem = false;
    }

    // Update is called once per frame
    void Update()
    {
        /*
         * Shoot a ray to detect if object is within a certain distance. 
         * If so:
         * - snap item to in front
         * - freeze rotation
         * - Make child of object to inherit rotation
         */
        if (isHoldingItem) {
            // Check if object transform has exceeded a certain boundary. If so, drop it
            float currDistance = Vector3.Distance(Camera.main.transform.position, pickedUpItem.transform.position);
            if (Mathf.Abs(ogDistance - currDistance) > 0.05f) {
                ToggleItemPickup();
            }
		}

        Debug.DrawRay(transform.position, forwardDirection.forward * 2.0f, Color.green);
        if (Input.GetKeyDown(KeyCode.E)) {
            if (isHoldingItem) {
                // Drop item in pickedUpImem
                ToggleItemPickup();
            } else {
                Ray gravityRay = new Ray(transform.position, forwardDirection.forward);          
                if (Physics.Raycast(gravityRay, out pickedUpItem, 2.0f, canBePickedUp)) {
                    // Move item to in front of camera
                    ogDistance = Vector3.Distance(Camera.main.transform.position, pickedUpItem.transform.position);
                    ToggleItemPickup();
				}
            }
        }
    }

    void ToggleItemPickup() {
        if (Equals(pickedUpItem, null)) {
            return;
		} else {
            // Create shorthand variables
            Rigidbody itemRb = pickedUpItem.rigidbody;
            Transform itemTransform = pickedUpItem.transform;

            // Flip boolean variables
            itemRb.freezeRotation ^= true;
            itemRb.useGravity ^= true;
            isHoldingItem ^= true;

            // Set parent
            if (itemTransform.parent == null) {
                itemTransform.parent = Camera.main.transform;
            } else {
                itemTransform.parent = null;
            }

            // Reset drag
            itemRb.drag = (itemRb.drag == 0) ? 500 : 0;
        }
	}
}
