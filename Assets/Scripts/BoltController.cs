using UnityEngine;

public class BoltController : MonoBehaviour
{
    [SerializeField]
    float boltspeed = 4;


    void Update()
    {

        Vector2 shot = Vector2.up * boltspeed * Time.deltaTime;
        transform.Translate(shot);

        if (transform.position.y > Camera.main.orthographicSize + 1)
        {
            Destroy(this.gameObject);
        }


    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
        Destroy(this.gameObject);
        }
    }

}
