using UnityEngine;
using UnityEngine.SceneManagement;

public class bossController : MonoBehaviour
{

    float bossCurentHp = 0;
    [SerializeField]
    float bossMaxHp = 10;


    void Start()
    {
        bossCurentHp = bossMaxHp;
    }

    void Update()
    {

    }
    
     void OnTriggerEnter2D(Collider2D collision)
    {
        //================================================================
        //Hälsa på boss skäppet
        //----------------------------------------------------------------
        if (collision.gameObject.tag == "Enemy")
        {
            bossCurentHp -= 1;

            if (bossCurentHp <= 0)
            {
                print("GAME OVER");
                SceneManager.LoadScene("Gameover");
            }
        }
        if (bossCurentHp == 0)
        {

            Destroy(this.gameObject);
        }

    }
}
