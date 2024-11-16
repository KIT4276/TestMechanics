using UnityEngine;

public class Building : MonoBehaviour
{
    [SerializeField] private Vector2Int _cellSize = Vector2Int.one;
    [SerializeField] private Color _color_1;
    [SerializeField] private Color _color_2;

    private void OnDrawGizmosSelected()
    {
        for (int x = 0; x < _cellSize.x; x++)
        {
            for (int y = 0; y < _cellSize.y; y++)
            {
                if ((x + y) % 2 == 0)
                    Gizmos.color = _color_1;
                else
                    Gizmos.color = _color_2;

                Gizmos.DrawCube(transform.position + new Vector3(x, 0, y), new Vector3(1, 0.1f, 1));
            }
        }
    }
}
