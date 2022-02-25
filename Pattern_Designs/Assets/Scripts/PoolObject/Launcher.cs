using System;
using UnityEngine;
using UnityEngine.Pool;

//https://docs.unity3d.com/2021.1/Documentation/ScriptReference/Pool.ObjectPool_1.html
public class Launcher : MonoBehaviour
{
    [SerializeField] Bullet bulletScriptPrefab;
    private IObjectPool<Bullet> bulletPool;

    private void Awake()
    {
        bulletPool = new ObjectPool<Bullet>(
            CreateBullet,
            OnGet,
            OnRelease,
            OnDestroyBullet,
            maxSize: 3
            );
    }

    //Enabled the bullet
    private void OnGet(Bullet bullet)
    {
        bullet.gameObject.SetActive(true);
        bullet.transform.position = transform.position;
    }

    //Dissabled the bullet
    private void OnRelease(Bullet bullet)
    {
        bullet.gameObject.SetActive(false);
    }

    private Bullet CreateBullet()
    {
        Bullet bullet =  Instantiate(bulletScriptPrefab, transform.position, transform.rotation);
        bullet.SetPool(bulletPool);
        return bullet;
    }

    private void OnDestroyBullet(Bullet bullet)
    {
        Destroy(bullet.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            bulletPool.Get();
        }
    }
}
