using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBehaviour : MonoBehaviour
{
    public Transform Pylons;
    public GameObject player;
    public GameObject bulletPrefab = null;
    public float Distancia = 5f;
    public int Frecuencia = 300;

    private int count;
  
    void Update()
    {
        Pylons.transform.LookAt(player.transform.position);
        if (player.activeSelf)
        {
            if ((player.transform.position - Pylons.transform.position).sqrMagnitude < Distancia)
            {
                if (count < Frecuencia) count++;
                else if (count >= Frecuencia)
                {
                    shot();
                    count = 0;
                }
            }
        }               
    }
    void shot()
    {
        GameObject bullet = Instantiate(bulletPrefab);

        bullet.tag = "Turret";

        bullet.GetComponent<BulletBehaviour>().setDirection(Pylons.transform.forward);
        bullet.GetComponent<Transform>().position = Pylons.transform.position + (Pylons.transform.forward * .15f);

        Destroy(bullet, 5.0f);
    }
}