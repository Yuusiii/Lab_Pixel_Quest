using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    // Prefab 
    public GameObject preFab;
    public Transform bulletTrash;
    public Transform bulletSpawn;

    // Timer 
    private const float Timer = 0.5f;
    private float _currentTime = 0.5f;
    private bool _canShoot = true;

    private void Update()
    {
        BulletSpawnTimer();
        SpawnBullet();
    }

    // Counts down until the player can shoot agian 
    private void BulletSpawnTimer()
    {
        // If can shoot don't do anything 
        if(_canShoot) { return; }
        // If can't shoot count down till you can 
        _currentTime -= Time.deltaTime;

        // If the time is larnger than zero don't do anyhting 
        if(_currentTime > 0) { return; }
        // If it's less than 0 reset the timer and allow player to shoot 
        _currentTime = Timer;
        _canShoot = true;
    }

    // Creates the bullet 
    private void SpawnBullet()
    {
        // If the player can't shoot or is clicking a diffrent key don't do anything 
        if (!Input.GetKey(KeyCode.Mouse0) || !_canShoot) { return; }
        // Create a copy of the bullet 
        var bullet = Instantiate(preFab, bulletSpawn.position, Quaternion.identity);
        // Connect the bullet to a trash collector object 
        bullet.transform.SetParent(bulletTrash);
        // Stop player from being able to shoot 
        _canShoot = false; 

    }
}
