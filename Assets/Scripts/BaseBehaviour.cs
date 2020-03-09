using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseBehaviour : MonoBehaviour
{
    private bool founded = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (!founded)
            {
                founded = true;
                Debug.Log("Base: Vidas recargadas!!");
                gameObject.GetComponent<MeshRenderer>().materials[1].SetColor("_EmissionColor", Color.green);
                other.GetComponent<PlayerBehaviour>().baseFounded();                
            }            
        }
    }
}
