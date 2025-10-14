using UnityEngine;

public class bossSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject bossPrefab;

    int bossCountdown; //håller informationen om antal skepp som sprängs
    
    void Start()
    {
        bossCountdown = 0;
    }


    void Update()
    {
         //=====================================================================
        // Boss skepet spawnar
        //---------------------------------------------------------------------

        if (bossCountdown == 10)
        {
            Instantiate(bossPrefab);
            bossCountdown = 0;
        }

    }
}
