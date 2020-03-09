using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    public float AlturaMinima = 4f; 
    public float FactorDeAltura = 1.5f; 
    public float smoothFactor = 10f;
    public GameObject Objetivo;    

    private float Altura;
    
    void LateUpdate()
    {
        float viperSpeed = Objetivo.GetComponent<Rigidbody>().velocity.magnitude;

        Altura = AlturaMinima * (1 + viperSpeed / FactorDeAltura);
        transform.position = Vector3.Lerp(transform.position, new Vector3(Objetivo.transform.position.x, Altura, Objetivo.transform.position.z), smoothFactor);
    }
}