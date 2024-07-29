using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private WeaponName _name;
    [SerializeField] private Transform _muzzleEndPoint;
    [SerializeField] private int _bulletsInInventory;
    [SerializeField] private int _maxMagazineCapacity;
    [SerializeField] private float _damage;
    [SerializeField] private ParticleSystem _shotEffect;

    [Header("Audio")]
    [SerializeField] private AudioSource _audio;
    [SerializeField] private AudioClip _shot;
    [SerializeField] private AudioClip _reload;

    private int _bulletsInMagazine;

    public WeaponName Name => _name;
    public int BulletsInMagazine => _bulletsInMagazine;
    public int BulletsInInventory => _bulletsInInventory;

    private void Awake()
    {
        _bulletsInMagazine = _maxMagazineCapacity;
    }

    public void Shoot()
    {
        if (_bulletsInMagazine > 0)
        {
            _audio.PlayOneShot(_shot);
            _shotEffect.Play();
            _bulletsInMagazine--;
            Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.collider.gameObject.TryGetComponent(out EnemyHealth enemy))
                {
                    enemy.TakeDamage(_damage);
                }
            }
        }
    }

    public void Reload()
    {
        _audio.clip = _reload;
        _audio.Play();

        if (_bulletsInInventory > 0)
        {
            int bulletsToLoad = _maxMagazineCapacity - _bulletsInMagazine;

            if (_bulletsInInventory >= bulletsToLoad)
            {
                _bulletsInInventory -= bulletsToLoad;
            }
            else
            {
                bulletsToLoad = _bulletsInInventory;
                _bulletsInInventory = 0;
            }

            _bulletsInMagazine += bulletsToLoad;
        }
    }
}
