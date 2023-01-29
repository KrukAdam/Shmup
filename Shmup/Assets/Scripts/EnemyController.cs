using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 0;

    private Vector2 movement = Vector2.left;
    private Rigidbody2D _rb2d;

    private void Awake()
    {
        _rb2d = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        GameManager.Instance.OnStartNewGame += DestrotEnemy;
    }


    private void OnDestroy()
    {
        GameManager.Instance.OnStartNewGame -= DestrotEnemy;
    }


    private void FixedUpdate()
    {
        _rb2d.MovePosition(_rb2d.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == Consts.LayerBullet)
        {
            GameManager.Instance.AddScore();
        }

        DestrotEnemy();
    }

    private void DestrotEnemy()
    {
        Destroy(gameObject);
    }

}
