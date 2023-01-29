using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMoveController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 0;

    private Vector2 _movement = Vector2.zero;
    private string _vertical = "Vertical";
    private Rigidbody2D _rb2d;

    private void Awake()
    {
        _rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        _movement.y = Input.GetAxisRaw(_vertical);
    }

    private void FixedUpdate()
    {
        _rb2d.MovePosition(_rb2d.position + _movement * moveSpeed * Time.fixedDeltaTime);
    }
}
