using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 0;

    private Vector2 _movement = Vector2.right;
    private Rigidbody2D _rb2d;

    private void Awake()
    {
        _rb2d = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        GameManager.Instance.OnStartNewGame += DestroyBullet;
    }

    private void OnDestroy()
    {
        GameManager.Instance.OnStartNewGame -= DestroyBullet;
    }

    private void FixedUpdate()
    {
        _rb2d.MovePosition(_rb2d.position + _movement * moveSpeed * Time.fixedDeltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        DestroyBullet();
    }

    private void DestroyBullet()
    {
        Destroy(gameObject);
    }
}
