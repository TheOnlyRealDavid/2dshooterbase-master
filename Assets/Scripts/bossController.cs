using UnityEditor;
using UnityEngine;

public class bossController : MonoBehaviour
{

    float bossCurentHp = 0;
    [SerializeField]
    float bossMaxHp = 10;

    [SerializeField]
    GameObject boomPrefab;

    GameObject player;

    [SerializeField]
    float bossSpeed = 2.5f;

    [SerializeField]
    GameObject RedBoltPrefab;

    void Start()
    {
        bossCurentHp = bossMaxHp;
        player = GameObject.Find("Ship");
    }

    void Update()
    {

        if (player.transform.position.x <= this.gameObject.transform.position.x)
        {
            transform.Translate(Vector2.left * bossSpeed * Time.deltaTime);
        }
        else if (player.transform.position.x >= this.gameObject.transform.position.x)
        {
            transform.Translate(Vector2.right * bossSpeed * Time.deltaTime);
        }


    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        //================================================================
        //Hälsa på boss skäppet
        //----------------------------------------------------------------
        if (collision.gameObject.tag == "bolt")
        {
            bossCurentHp -= 1;

            if (bossCurentHp <= 0)
            {
                print("Boss Down");
            }
        }
        if (bossCurentHp == 0)
        {
            Instantiate(boomPrefab, transform.position, Quaternion.identity);
            Destroy(this.gameObject);

        }

    }
}
