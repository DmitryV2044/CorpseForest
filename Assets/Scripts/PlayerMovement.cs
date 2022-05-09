using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField][Range(1,10)] private float _speed;
    private SpriteRenderer _spriteRenderer;
    private Vector2 _moveInput;

    public Joystick MovementJoystick;

    // Start is called before the first frame update
    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        _moveInput = new Vector2(MovementJoystick.Horizontal * _speed * Time.deltaTime, MovementJoystick.Vertical * _speed * Time.deltaTime);

        transform.Translate(_moveInput);

        _spriteRenderer.flipX = MovementJoystick.Horizontal > 0 ? false : true;
    }
}
