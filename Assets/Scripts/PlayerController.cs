using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    float speed = 0.2f;

    [SerializeField]
    GameObject boltPrefab;

    float timeSinceLastShot = 0;
    [SerializeField]
    float timeBetweenShots = 0.7f;

    float currentHp = 0;
    [SerializeField]
    float MaxHP = 3;

    [SerializeField]
    Slider hpSlider;

    void Start()
    {
        currentHp = MaxHP;
        hpSlider.maxValue = MaxHP;
        hpSlider.value = currentHp;
    }

    void Update()
    {
        float inputX = Input.GetAxisRaw("Horizontal");
        float inputY = Input.GetAxisRaw("Vertical");

        Vector2 movement = Vector2.right * inputX
                        + Vector2.up * inputY;

        transform.Translate(movement * speed * Time.deltaTime);

        //===============================================================================================
        // skjuta
        //-----------------------------------------------------------------------------------------------

        timeSinceLastShot += Time.deltaTime;

        if (Input.GetAxisRaw("Fire1") > 0 && timeSinceLastShot > timeBetweenShots)
        {
            //======================================================
            //Ljud vid skot
            //------------------------------------------------------
            AudioSource speaker = GetComponent<AudioSource>();
            speaker.Play();
    

            Instantiate(boltPrefab, transform.position, Quaternion.identity);
            timeSinceLastShot = 0;
        }



    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        //================================================================
        //Hälsa på skäppet
        //----------------------------------------------------------------
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "redBolt")
        {
            currentHp -= 1;
            hpSlider.value = currentHp;

            if (currentHp <= 0)
            {
                print("GAME OVER");
                SceneManager.LoadScene("Gameover");
            }
        }
        if (currentHp == 0)
        {

            Destroy(this.gameObject);
        }

    }
}
