using UnityEngine;

public class Looker : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Camera _camera;
    [SerializeField] private float _minRotationX;
    [SerializeField] private float _maxRotationX;

    private float _fullSpinAngle = 360;
    private float _maxPositiveRateAngle = 180;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void Look(Vector2 viewChange)
    {
        _camera.transform.Rotate(Vector3.right * -viewChange.y);
        _player.transform.Rotate(Vector3.up * viewChange.x);

        Vector3 currentRotation = _camera.transform.rotation.eulerAngles;

        if (currentRotation.x > _maxPositiveRateAngle)
        {
            currentRotation.x -= _fullSpinAngle;
        }

        currentRotation.x = Mathf.Clamp(currentRotation.x, _minRotationX, _maxRotationX);

        _camera.transform.rotation = Quaternion.Euler(currentRotation);
    }
}
