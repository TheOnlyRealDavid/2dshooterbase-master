using UnityEngine;

public class followController : MonoBehaviour
{

    [SerializeField]
    GameObject target;

    void Start()
    {
        
    }

    void Update()
    {
        Vector3 pOS = transform.position;

        pOS.x = target.transform.position.x;

        transform.position = pOS;
    }
}