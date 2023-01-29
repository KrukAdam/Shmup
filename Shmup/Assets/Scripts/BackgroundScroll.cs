using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class BackgroundScroll : MonoBehaviour
{

    [SerializeField] private float speed;

    private float speedModifier = 100;
    private Renderer _bgRenderer;
    private Vector2 _scroll = new();

    private void Awake()
    {
        _bgRenderer = GetComponent<Renderer>();
        _scroll = Vector2.zero;
    }

    private void Update()
    {
        _scroll.x = (speed + Time.deltaTime) / speedModifier;
        _bgRenderer.material.mainTextureOffset += _scroll;
    }

}
