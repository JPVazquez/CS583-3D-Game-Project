using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlCollider : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //private void OnTriggerEnter(Collider other) {
    //    Vector3 colliderSize = GetComponent<Collider>().bounds.size;

    //    // Calculate the top position based on the center and size
    //    float topPosition = transform.position.y + colliderSize.y / 2f;

    //    // Assuming your sphere is centered at (0, 0, 0)
    //    if (other.transform.position.y > topPosition) {
    //        // Object entered from the top half
    //        Physics.IgnoreCollision(GetComponent<Collider>(), other, true);

    //        // Do something else if needed, like playing a sound or applying a force

    //        // Assuming you want to reset collision after a certain time (e.g., 1 second)
    //        StartCoroutine(ResetCollisionAfterDelay(other, 0.5f));
    //        Debug.Log("Entered from the top half!");
    //    }
    //}

    //private System.Collections.IEnumerator ResetCollisionAfterDelay(Collider other, float delay) {
    //    yield return new WaitForSeconds(delay);

    //    // Reset collision
    //    Physics.IgnoreCollision(GetComponent<Collider>(), other, false);
    //    Debug.Log("Collision reset");
    //}
}
