// using System;
using NUnit.Framework.Constraints;
using UnityEngine;

public class enemyController : MonoBehaviour
{

    [SerializeField]
    float enemySpeed = 1f;


    [SerializeField]
    GameObject enemyPrefab;

    [SerializeField]
    GameObject boomPrefab;




    void Start()
    {
        Vector2 position = new();

        position.x = Random.Range(-10, +10);
        // position.y = Random.Range(-4, +4);

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



    }
    
       void OnTriggerEnter2D(Collider2D collision)
    {
        Instantiate(boomPrefab, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }

}
