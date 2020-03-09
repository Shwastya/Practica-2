using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{    
    public float Velocidad = 10f;
    
    private Vector3 BulletDir;
    private PlayerBehaviour player;
    public void setDirection(Vector3 dir) 
    { 
        BulletDir = dir; 
    }

    void FixedUpdate()
    {
        transform.Translate(BulletDir * Time.deltaTime * Velocidad);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != tag)
        {
            if (other.tag == "Turret")
            {
                Debug.Log("Turret: Destruida unidad " + other.name + " ");
                other.gameObject.SetActive(false);
            }
            if (other.tag == "Player")
            {
                other.GetComponent<PlayerBehaviour>().hit(BulletDir);              
            }            
            Destroy(gameObject);
        }
    }
}
