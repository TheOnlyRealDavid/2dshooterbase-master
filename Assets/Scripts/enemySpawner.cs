using UnityEngine;

public class enemySpawner : MonoBehaviour
{

    [SerializeField]
    GameObject enemyPrefab;

 float timeSinceLastEnemy = 0;
    [SerializeField]
    float timeBetweenEnemys = 0.7f;

    void Update()
    {


        

         //====================================================================
        //Enemy spawn rate
        //--------------------------------------------------------------------

       
         timeSinceLastEnemy += Time.deltaTime;
        if (timeSinceLastEnemy > timeBetweenEnemys)
        {

            Instantiate(enemyPrefab);
            timeSinceLastEnemy = 0;
        }
        
       
    }
}
