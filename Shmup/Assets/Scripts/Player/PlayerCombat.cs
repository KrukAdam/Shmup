using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    [SerializeField] private int life = 3;
    [SerializeField] private Bullet bullet;
    [SerializeField] private Transform bulletsParent;
    [SerializeField] private Transform respPosition;
    [Space]
    [SerializeField] private Transform startPosition;

    private int _currentLife;

    private void Awake()
    {
        _currentLife = life;
    }

    private void Start()
    {
        ResetCombat();
        GameManager.Instance.OnStartNewGame += ResetCombat;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    private void OnDestroy()
    {
        GameManager.Instance.OnStartNewGame -= ResetCombat;
    }

    private void ResetCombat()
    {
        _currentLife = life;
        GameManager.Instance.RefreshLife(_currentLife);
        transform.position = startPosition.position;
    }

    private void Shoot()
    {
        var newBullet = Instantiate(bullet, bulletsParent);
        newBullet.transform.position = respPosition.position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == Consts.LayerEnemy)
        {
            _currentLife--;
            GameManager.Instance.RefreshLife(_currentLife);
        }
    }
}
