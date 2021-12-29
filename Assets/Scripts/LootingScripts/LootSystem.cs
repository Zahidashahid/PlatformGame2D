using UnityEngine;
[System.Serializable]
public class ItemToSpawn
{
    public GameObject item;
    public float spawnRate;
    [HideInInspector] public float minSpawnProb, maxSpawnProb;
}

public class  LootSystem: MonoBehaviour
{
    public ItemToSpawn[] itemToSpawn;
     //int index;
    
    void Start()
    {
        
        for (int i = 0; i < itemToSpawn.Length; i++)
        {

            if (i == 0)
            {
                itemToSpawn[i].minSpawnProb = 0;
                itemToSpawn[i].maxSpawnProb = itemToSpawn[i].spawnRate - 1;
            }
            else
            {
                itemToSpawn[i].minSpawnProb = itemToSpawn[i - 1].maxSpawnProb + 1;
                itemToSpawn[i].maxSpawnProb = itemToSpawn[i].minSpawnProb + itemToSpawn[i].spawnRate - 1;
            }
        }

    }


 

    public void Spawnner(Transform t)
    {
        float randomNum = Random.Range(0, 100);
       /* Debug.Log("Here transform " + t);
        Debug.Log("position " + t.position);*/
        for (int index = 0; index < itemToSpawn.Length; index++)
        {
            if (randomNum >= itemToSpawn[index].minSpawnProb && randomNum <= itemToSpawn[index].maxSpawnProb)
            {

                Debug.Log(randomNum + " " + itemToSpawn[index].item.name);
                Instantiate(itemToSpawn[index].item, t.position, Quaternion.identity);
                
                break;
            }
            else if(randomNum >= itemToSpawn[itemToSpawn.Length -1].minSpawnProb && randomNum <= itemToSpawn[itemToSpawn.Length - 1].maxSpawnProb)
            {
                Debug.Log(randomNum + " No Gifts this time"  );
                break;
            }
        }
    }
   
}


