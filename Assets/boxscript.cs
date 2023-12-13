using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class boxscript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "shadow")
        {
            print("test2");

            //Invoke("loadNextLevel", 1f);
        }
    }


    private void loadNextLevel()
    {

    }
}
