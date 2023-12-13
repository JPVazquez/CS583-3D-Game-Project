using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class boxscript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
            if (other.name == "Creature")
            {
            Invoke("loadNextLevel", 2f);
            }

            
    }


    private void loadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
