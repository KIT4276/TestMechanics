using UnityEngine;

public class Building : MonoBehaviour
{
    [SerializeField] private Vector2 _cellSize = Vector2Int.one;
    [SerializeField] private Color _color;
    [Space]
    [SerializeField] private Material _okMaterial;
    [SerializeField] private Material _noOkMaterial;
    [SerializeField] private Material _flyingMaterial;
    [SerializeField] private MeshRenderer[] _meshRenderer;

    public void OkMAterial()
    {
        Debug.Log("OkMAterial");

        foreach (var renderer in _meshRenderer)
        {
            renderer.material = _okMaterial;
            Debug.Log(renderer.material.name);
        }
    }

    public void NoOkMAterial()
    {
        Debug.Log("NoOkMAterial");
        foreach (var renderer in _meshRenderer)
        {
            renderer.material = _noOkMaterial;
            Debug.Log(renderer.material.name);
        }
    }

    public void FlyingManerial()
    {
        Debug.Log("FlyingManerial");
        foreach (var renderer in _meshRenderer)
        {
            renderer.material = _flyingMaterial;
            Debug.Log(renderer.material.name);
        }
    }

    public Vector2 CellSize { get => _cellSize;}

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
}
