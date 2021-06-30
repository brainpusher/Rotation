using UnityEngine;

public class ModelRotator : MonoBehaviour
{
    [SerializeField] private Collider objectCollider;
    [SerializeField] private float sensitivity = 2f;

    private Vector3 _mouseReference;
    private Vector3 _mouseOffset;
    private Vector3 _rotation = Vector3.zero;
    
    private  Vector3 _centerPosition = Vector3.one;

    private void Awake()
    {
        _centerPosition = objectCollider.bounds.center;
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            _mouseReference = Input.mousePosition;
        }

        if (Input.touchCount == 1)
        {
            if (Input.GetMouseButton(0))
            {
                _mouseOffset = (Input.mousePosition - _mouseReference);
                _rotation.y = -(_mouseOffset.x + _mouseOffset.y) * sensitivity * Time.deltaTime;

                transform.RotateAround(_centerPosition, Vector3.up, _rotation.y);
                _mouseReference = Input.mousePosition;
            }
        }
    }
}