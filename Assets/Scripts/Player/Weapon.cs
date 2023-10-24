using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;
    public float fireRate = .5f;
    public float bulletSpeed = 10f;
    public float weaponDamage = 1;
    public bool canShoot = false;

    private float nextFireTime = 0;

    void Update()
    {
        if (canShoot && Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + 1f / fireRate;
        }
    }

    void Shoot()
    {
        Bullet bulletInstance = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation).GetComponent<Bullet>();
        bulletInstance.SetDirectionAndSpeed(-bulletSpawnPoint.forward, bulletSpeed,weaponDamage);
        //bulletInstance.damageAmount = weaponDamage;
    }
}
