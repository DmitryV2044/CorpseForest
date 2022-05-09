using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float speed;
    SpriteRenderer sr;
    private Vector2 moveinput;
    public Joystick joystick;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    public void Move()
    {
        moveinput = new Vector2(joystick.Horizontal * speed * Time.deltaTime, joystick.Vertical * speed * Time.deltaTime);

        transform.Translate(moveinput);

        sr.flipX = joystick.Horizontal > 0 ? false : true;
    }
}
