using UnityEngine;

public class BuildingsGrid : MonoBehaviour
{
    [SerializeField] private Vector2Int _gridSize = new(10, 10);

    private Building[,] _grid;
    private Building _activeBuilding;
    private Camera _camera;

    private void Awake()
    {
        _grid = new Building[_gridSize.x, _gridSize.y];
        _camera = Camera.main;
    }

    public void StartPlacingBuilding(Building buildingPrefab)
    {
        if (_activeBuilding != null)
        { 
            Destroy(_activeBuilding.gameObject);
        }

        _activeBuilding =  Instantiate(buildingPrefab);
    }

    private void Update()
    {
        if(_activeBuilding != null)
        {
            var groundPlane = new Plane(Vector3.up, Vector3.zero);
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

            if(groundPlane.Raycast(ray, out float position)) 
            { 
                Vector3 worldPosition = ray.GetPoint(position);
                _activeBuilding.transform.position = worldPosition;
            }
        }
    }
}
