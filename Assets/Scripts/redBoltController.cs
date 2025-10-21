using UnityEngine;

public class redBoltController : MonoBehaviour
{
    [SerializeField]
    float redBoltSpeed = 4;

    void Update()
    {

        Vector2 shot = Vector2.down * redBoltSpeed * Time.deltaTime;
        transform.Translate(shot);

        if (transform.position.y > Camera.main.orthographicSize - 1) //Något fel så den inte förstörs
        {
            Destroy(this.gameObject);
        }


    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
        }
    }

}

