using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    [Header("General")]
    public LayerMask hitLayers;
    public GameObject bulletPrefab;

    [Header("Stats")]
    public float gunRange = 200;

    private Transform cam_PlayerTransform;

    private void Start()
    {
        cam_PlayerTransform = GameObject.FindGameObjectWithTag("MainCamera").transform;
    }

    private void Update()
    {
        GunShoot();
    }

    private void GunShoot()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            RaycastHit hit;
            if (Physics.Raycast(cam_PlayerTransform.position, cam_PlayerTransform.forward, out hit, gunRange, hitLayers))
            {
                GameObject bulletClone = Instantiate(bulletPrefab, hit.point+hit.normal*0.001f, Quaternion.LookRotation(hit.normal));
                Destroy(bulletClone, 4f);
            }
        }
    }
}
