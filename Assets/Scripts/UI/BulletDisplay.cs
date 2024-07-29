using TMPro;
using UnityEngine;

public class BulletDisplay : MonoBehaviour
{
    private const char Divider = '/';

    [SerializeField] private PlayerShooter _shooter;
    [SerializeField] private TextMeshProUGUI _text;

    private void OnEnable()
    {
        _shooter.BulletsValueChanged += UpdateValue;
    }

    private void OnDisable()
    {
        _shooter.BulletsValueChanged -= UpdateValue;
    }

    private void UpdateValue(int bulletsInMagazine, int bulletsInInventory)
    {
        _text.text = $"{bulletsInMagazine}{Divider}{bulletsInInventory}";
    }
}
