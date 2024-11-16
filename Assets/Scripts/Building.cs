using UnityEngine;

public class Building : MonoBehaviour
{
    [SerializeField] private Vector2 _cellSize = Vector2Int.one;
    [SerializeField] private Color _color;
    [Space]
    //[SerializeField] private Material _okMaterial;
    //[SerializeField] private Material _noOkMaterial;           // for 3D
    //[SerializeField] private Material _flyingMaterial;
    //[SerializeField] private MeshRenderer[] _meshRenderers;

    [SerializeField] private Sprite _okSprite;
    [SerializeField] private Sprite _noOkSprite;              // for 2D
    [SerializeField] private Sprite _flyingSprite;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Transform _spriteTransform;
    private Transform _camera;

    private void Awake()
    {
        _camera = Camera.main.transform;
    }

    public void OkMAterial()
    {
        //foreach (var renderer in _meshRenderers)     // for 3D
        //    renderer.material = _okMaterial;

        _spriteRenderer.sprite = _okSprite;            // for 2D
        _spriteRenderer.color = new(255, 255, 255, 255);
    }

    public void NoOkMAterial()
    {
        //foreach (var renderer in _meshRenderers)     // for 3D
        //    renderer.material = _noOkMaterial;


        _spriteRenderer.sprite = _noOkSprite;          // for 2D
        _spriteRenderer.color = new(255, 255, 255, 50);
    }

    public void FlyingManerial()
    {
        //foreach (var renderer in _meshRenderers)    // for 3D
        //    renderer.material = _flyingMaterial;

        _spriteRenderer.sprite = _flyingSprite;        // for 2D
        _spriteRenderer.color = new(255, 255, 255, 50);
    }

    public Vector2 CellSize { get => _cellSize; }

    private void OnDrawGizmosSelected()
    {
        for (int x = 0; x < _cellSize.x; x++)
        {
            for (int y = 0; y < _cellSize.y; y++)
            {
                Gizmos.color = _color;

                Gizmos.DrawCube(transform.position + new Vector3(x, 0, y), new Vector3(1, 0.1f, 1));
            }
        }
    }

    private void Update()
    {
       
        //_spriteTransform.LookAt(_camera);
    }
}
