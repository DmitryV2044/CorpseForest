using UnityEngine;

public class GetItems : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "bullets")
        {
            Destroy(collision.gameObject);
        }
    }
}
