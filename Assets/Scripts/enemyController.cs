// using System;
// using System;
using NUnit.Framework.Constraints;
using UnityEditor;
using UnityEngine;

public class enemyController : MonoBehaviour
{

    [SerializeField]
    float enemySpeed = 1f;


    [SerializeField]
    GameObject enemyPrefab;

    [SerializeField]
    GameObject boomPrefab;



    [SerializeField]
    GameObject bossPrefab;

    static int bossCountdown = 0; //varje fiende skepp som spawnar äe ju en kopia av prefaben och static gör så att varje kopia delar på variabel så det räknas upp till 10 tilsammans




    void Start()
    {
        Vector2 position = new();

        position.x = Random.Range(-10, +10);

        position.y = Camera.main.orthographicSize + 1;


        transform.position = position;
    }


    void Update()
    {
    

            //==========================================================================
            //åker nedåt
            //--------------------------------------------------------------------------

            Vector2 movement = Vector2.down * enemySpeed * Time.deltaTime;
            transform.Translate(movement);






        //====================================================================
        // Försviner efter ett tag
        //--------------------------------------------------------------------

        if (transform.position.y < -Camera.main.orthographicSize - 1)
        {
            Destroy(this.gameObject);
        }

        //====================================================================
        // Förstör fiende skeppen när bossen har spawnat
        //--------------------------------------------------------------------

        if (bossCountdown == 10)
        {
            Destroy(enemyPrefab);
        }

    
    }



    void OnTriggerEnter2D(Collider2D collision)
    {
        Instantiate(boomPrefab, transform.position, Quaternion.identity);
        Destroy(this.gameObject);

        bossCountdown += 1;
        if (bossCountdown >= 10)
        {
            Instantiate(bossPrefab);
            // bossCountdown = 0;
            print("BossSpawn");
        }
    }
    

}
