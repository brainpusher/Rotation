using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    [SerializeField] private Camera cameraMain;
    [SerializeField] private float zoomMinFovValue = 1f;
    [SerializeField] private float zoomMaxFovValue = 8f;
    [SerializeField] private float zoomSlowdownMultiplier = 0.01f;

    private void Awake()
    {
        zoomMaxFovValue = cameraMain.fieldOfView;
    }

    private void Update()
    {
        if (Input.touchCount == 2)
        {
            float difference = GetValueBetweenTwoFingers();
            Zoom(difference * zoomSlowdownMultiplier);
        }

        Zoom(Input.GetAxis("Mouse ScrollWheel"));
    }

    private void Zoom(float increment)
    {
        float newFieldOfView = cameraMain.fieldOfView - increment;
        cameraMain.fieldOfView = Mathf.Clamp(newFieldOfView, zoomMinFovValue, zoomMaxFovValue);
    }

    private float GetValueBetweenTwoFingers()
    {
        Touch firstTouch = Input.GetTouch(0);
        Touch secondTouch = Input.GetTouch(1);

        Vector2 firstTouchPreviousPosition = firstTouch.position - firstTouch.deltaPosition;
        Vector2 secondTouchPreviousPosition = secondTouch.position - secondTouch.deltaPosition;

        float previousMagnitude = (firstTouchPreviousPosition - secondTouchPreviousPosition).magnitude;
        float currentMagnitude = (firstTouch.position - secondTouch.position).magnitude;
        float difference = currentMagnitude - previousMagnitude;
        return difference;
    }
}
