using UnityEngine;

public class BuildingsGrid : MonoBehaviour
{
    [SerializeField] private Vector2Int _gridSize = new(10, 10);

    // private readonly Building[,] _grid;
    private Building _activeBuilding;
    private Camera _camera;

    private Plane _groundPlane;
    private Ray _ray;
    private Vector3 _worldPosition;
    private int _int_X;
    private int _int_Z;
    private bool _available;
    private Material _material;

    private void Awake()
    {
        //_grid = new Building[_gridSize.x, _gridSize.y];
        _camera = Camera.main;
        _groundPlane = new Plane(Vector3.up, Vector3.zero);
    }

    public void StartPlacingBuilding(Building buildingPrefab)
    {
        if (_activeBuilding != null)
        {
            Destroy(_activeBuilding.gameObject);
        }

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


        if (Input.GetMouseButtonDown(0))
        {
            if (_available)
            {
                _activeBuilding.OkMAterial();
                _activeBuilding = null;
            }
            else
                Debug.Log("NONONO!");
        }
    }

    private void FindPosition(float position)
    {
        _worldPosition = _ray.GetPoint(position);

        _int_X = Mathf.RoundToInt(_worldPosition.x);
        _int_Z = Mathf.RoundToInt(_worldPosition.z);
    }

    private void IsAvailable()
    {
        if (_int_X < (/*transform.position.x +*/ _activeBuilding.CellSize.x / 2)
            || _int_X > (_gridSize.x - _activeBuilding.CellSize.x)
            || _int_Z < (/*transform.position.z +*/ _activeBuilding.CellSize.y/2)
            || _int_Z > (_gridSize.y - _activeBuilding.CellSize.y))
            _available = false;
        else
            _available = true;
    }
}
