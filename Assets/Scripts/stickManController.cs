using UnityEngine;



public class stickManController : MonoBehaviour
{

    [SerializeField]
    GameObject GroundChecker;

    [SerializeField]
    LayerMask groundLayer;

    [SerializeField]
    float jumpforce = 20;

    [SerializeField]
    float speed = 5;

    void Update() // så ofta den kan
    {
        float inputX = Input.GetAxisRaw("Horizontal");
        Vector2 movement = Vector2.right * inputX;
        transform.Translate(movement * speed * Time.deltaTime);
    }



    void FixedUpdate() // 300 ggr/sek
    {
        bool isGrounded = Physics2D.OverlapCircle(
            GroundChecker.transform
            .position, 0.1f, groundLayer
        );

        if (Input.GetAxisRaw("Jump") > 0 && isGrounded == true)
        {
            Rigidbody2D rb = GetComponent<Rigidbody2D>();

            rb.AddForce(Vector2.up * jumpforce, ForceMode2D.Impulse);
        }
    }
}
