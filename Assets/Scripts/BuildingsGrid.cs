using UnityEngine;

public class BuildingsGrid : MonoBehaviour
{
    [SerializeField] private Vector2Int _gridSize = new(10, 10);

    private Building[,] _grid;
    private Building _activeBuilding;
    private Camera _camera;

    private Plane _groundPlane;
    private Ray _ray;
    private Vector3 _worldPosition;
    private int _int_X;
    private int _int_Z;
    private bool _available;

    private void Awake()
    {
        _grid = new Building[_gridSize.x, _gridSize.y];
        _camera = Camera.main;
        _groundPlane = new Plane(Vector3.up, Vector3.zero);
    }

    public void StartPlacingBuilding(Building buildingPrefab)
    {
        if (_activeBuilding != null)
            Destroy(_activeBuilding.gameObject);

        _activeBuilding = Instantiate(buildingPrefab);
    }

    private void Update()
    {
        if (_activeBuilding != null)
        {
            _ray = _camera.ScreenPointToRay(Input.mousePosition);

            if (_groundPlane.Raycast(_ray, out float position))
            {
                FindPosition(position);
                IsAvailable();
                PutABuilding();
            }
        }
    }

    private void PutABuilding()
    {
        _activeBuilding.transform.position = new Vector3(_int_X, 0, _int_Z);

        if (_available)
            _activeBuilding.FlyingManerial();
        else
            _activeBuilding.NoOkMAterial();


        if (_available && Input.GetMouseButtonDown(0))
        {
            PlaceFlyingBuilding(_int_X, _int_Z);
        }
    }

    private bool IsPlaceOccupied(int placeX, int placeY)
    {
        for (int x = 0; x < _activeBuilding.CellSize.x; x++)
        {
            for (int y = 0; y < _activeBuilding.CellSize.y; y++)
            {
                if (_grid[placeX + x, placeY + y] != null)
                    return true;

            }
        }
        return false;
    }

    private void PlaceFlyingBuilding(int placeX, int placeY)
    {
        for (int x = 0; x < _activeBuilding.CellSize.x; x++)
        {
            for (int y = 0; y < _activeBuilding.CellSize.y; y++)
            {
                _grid[placeX + x, placeY + y] = _activeBuilding;
            }
        }

        _activeBuilding.OkMAterial();
        _activeBuilding = null;
    }

    private void FindPosition(float position)
    {
        _worldPosition = _ray.GetPoint(position);

        _int_X = Mathf.RoundToInt(_worldPosition.x);
        _int_Z = Mathf.RoundToInt(_worldPosition.z);
    }

    private void IsAvailable()
    {
        if (_int_X < (transform.position.x - _gridSize.x / 2 + _activeBuilding.CellSize.x / 2)
            || _int_X > (_gridSize.x - _activeBuilding.CellSize.x)
            || _int_Z < (transform.position.z - _gridSize.x / 2 + _activeBuilding.CellSize.y / 2)
            || _int_Z > (_gridSize.y - _activeBuilding.CellSize.y)
            || IsPlaceOccupied(_int_X, _int_Z))
            _available = false;
        else 
            _available = true;
    }
}
