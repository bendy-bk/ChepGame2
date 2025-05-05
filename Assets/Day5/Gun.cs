using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform spawnPoint;

    void Update()
    {
       Invoke(nameof(SpwanBullet), 1f);
        
    }

    public void SpwanBullet()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("check Click");
            Instantiate(bulletPrefab, spawnPoint.position, spawnPoint.rotation);
        }
    }
}
