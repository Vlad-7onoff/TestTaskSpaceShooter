using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Gun : ObjectPool
{
    [SerializeField] private LevelBoundary _levelBoundary;
    [SerializeField] private float _indentTopBoundary;
    [SerializeField] private float _cooldown;
    [SerializeField] private GameObject _bulletPrefab;

    private AudioSource _audioSource;
    private float _topBoundary;
    private bool _readyShoot = true;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        _topBoundary = _levelBoundary.RightUpCorner.y + _indentTopBoundary;
        Init(_bulletPrefab);
    }

    public void TryShoot()
    {
        if (_readyShoot && TryGetObject(out GameObject bullet))
        {
            SetBullet(bullet);
            _audioSource.Play();
            _readyShoot = false;
            StartCoroutine(CoolDown());
        }
    }

    private IEnumerator CoolDown()
    {
        yield return new WaitForSeconds(_cooldown);
        _readyShoot = true;
    }

    private void SetBullet(GameObject prefab)
    {
        prefab.SetActive(true);
        Bullet bullet = prefab.GetComponent<Bullet>();
        bullet.SetTopBoundary(_topBoundary);
        bullet.transform.position = transform.position;
    }
}
