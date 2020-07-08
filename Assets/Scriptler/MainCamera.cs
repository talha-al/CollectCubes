using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    [SerializeField] GameObject delik;
    private Vector3 mesafe;

    void Start()
    {
        mesafe = transform.position - delik.transform.position;
    }

    void LateUpdate()
    {
        transform.position = mesafe + delik.transform.position;
    }
}
