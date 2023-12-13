using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Laser : MonoBehaviour
{
    [SerializeField] private LineRenderer lineRenderer;
    [SerializeField] private float laserDistance;
    [SerializeField] private LayerMask ignoreMask;
    [SerializeField] private UnityEvent onHitTarget;


    private RaycastHit rayHit;
    private Ray ray;
    private int previousSceneIndex;

    private void Start()
    {
        lineRenderer.positionCount = 2;
        previousSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    // Update is called once per frame
    void Update()
    {
        ray = new(transform.position, transform.forward);

        if(Physics.Raycast(ray, out rayHit, laserDistance, ~ignoreMask))
        {
            lineRenderer.SetPosition(0, transform.position);
            lineRenderer.SetPosition(1, rayHit.point);

            
            if (rayHit.collider.tag == "Player")
            {
                PlayerPrefs.SetInt("PreviousSceneIndex", previousSceneIndex);

                //Load game over screen
                SceneManager.LoadScene("GameOver");
            }
        }

        else
        {
            lineRenderer.SetPosition(0, transform.position);
            lineRenderer.SetPosition(1, transform.position + transform.forward * laserDistance);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, ray.direction * laserDistance);

        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(rayHit.point, 0.23f);
    }
}
