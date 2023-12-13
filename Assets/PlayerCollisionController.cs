using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        CapsuleCollider capcap = GetComponent<CapsuleCollider>();
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "ShadowWall")
        {
            Debug.Log("shadow");
        }
        else
        {
            Debug.Log("sshs");
        }
    }
}
