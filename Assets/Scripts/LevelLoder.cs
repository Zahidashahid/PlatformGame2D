using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelLoder : MonoBehaviour
{

    public int iLevelToLoad;
    public string sLevelToLoad;
    public bool useIntegerToLoadLevel = false ;
   
    void OnTriggerEnter2D(Collider2D collision)
    {
       // Debug.Log("collision " , collision);
        GameObject collisionGameObject = collision.gameObject;
        if (collisionGameObject.name == "Player")
        {
            LoadLevel();
        } 
       
    }
    void LoadLevel()
    {
       
        if(useIntegerToLoadLevel)
        {
            SceneManager.LoadScene(iLevelToLoad);
        }
        else
        {
            SceneManager.LoadScene(sLevelToLoad);
        }
    }
}
