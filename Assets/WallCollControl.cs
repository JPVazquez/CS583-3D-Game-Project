using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCollControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        MeshCollider mc = GetComponent<MeshCollider>();
    }


    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.tag);
    }


}
