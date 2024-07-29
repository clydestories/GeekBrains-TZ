using System;
using System.Collections.Generic;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    private const string Horizontal = nameof(Horizontal);
    private const string Vertical = nameof(Vertical);
    private const string MouseX = "Mouse X";
    private const string MouseY = "Mouse Y";

    [SerializeField] private List<KeyCode> _jumpKeys;
    [SerializeField] private List<KeyCode> _shootKeys;
    [SerializeField] private List<KeyCode> _reloadKeys;
    [SerializeField] private List<KeyCode> _firstWeaponKeys;
    [SerializeField] private List<KeyCode> _secondWeaponKeys;
    [SerializeField] private List<KeyCode> _pauseKeys;

    public event Action<Vector3> Moved;
    public event Action<Vector2> Looked;
    public event Action Jumped;
    public event Action Shot;
    public event Action Reloaded;
    public event Action Paused;
    public event Action<int> WeaponPicked;

    private void Update()
    {
        float horizontal = Input.GetAxisRaw(Horizontal);
        float vertical = Input.GetAxisRaw(Vertical);
        Moved?.Invoke(new Vector3(horizontal, 0, vertical).normalized);

        float mouseX = Input.GetAxis(MouseX);
        float mouseY = Input.GetAxis(MouseY);
        Looked?.Invoke(new Vector2(mouseX, mouseY));

        foreach (KeyCode keyCode in _jumpKeys)
        {
            if (Input.GetKeyDown(keyCode))
            {
                Jumped?.Invoke();
            }
        }

        foreach (KeyCode keyCode in _shootKeys)
        {
            if (Input.GetKeyDown(keyCode))
            {
                Shot?.Invoke();
            }
        }

        foreach (KeyCode keyCode in _reloadKeys)
        {
            if (Input.GetKeyDown(keyCode))
            {
                Reloaded?.Invoke();
            }
        }

        foreach (KeyCode keyCode in _firstWeaponKeys)
        {
            if (Input.GetKeyDown(keyCode))
            {
                WeaponPicked?.Invoke(1);
            }
        }

        foreach (KeyCode keyCode in _secondWeaponKeys)
        {
            if (Input.GetKeyDown(keyCode))
            {
                WeaponPicked?.Invoke(2);
            }
        }

        foreach (KeyCode keyCode in _pauseKeys)
        {
            if (Input.GetKeyDown(keyCode))
            {
                Paused?.Invoke();
            }
        }
    }
}
