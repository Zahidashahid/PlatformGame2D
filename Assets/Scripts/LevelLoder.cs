using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelLoder : MonoBehaviour
{

    public int iLevelToLoad;
    public string sLevelToLoad;
    public bool useIntegerToLoadLevel = false ;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("collision " , collision);
        GameObject collisionGameObject = collision.gameObject;
        if (collisionGameObject.name == "Player")
        {
            LoadScene();
        } 
        if (collisionGameObject.CompareTag("Cherry"))
        {
            Debug.Log("Cherry Eaten");
            Destroy(collision.gameObject); 
        }
    }
    void LoadScene()
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
