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

    //==========================================
    // Hur ofta bossen kommer skjuta
    //------------------------------------------
    float TidenSedanSkot = 0;
    [SerializeField]
    float TidenMellanSkot = 0.5f;

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

        //===================================
        // Bossen skjuter
        //-----------------------------------

        TidenSedanSkot += Time.deltaTime;

        if (TidenSedanSkot > TidenMellanSkot)
        {
            AudioSource speaker = GetComponent<AudioSource>();
            speaker.Play();

            Instantiate(RedBoltPrefab, transform.position, Quaternion.identity);
            TidenSedanSkot = 0;
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
