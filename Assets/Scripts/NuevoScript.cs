using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NuevoScript : MonoBehaviour
{
    [SerializeField] private Transform _target;

    void Start()
    {
        
    }

    void Update()
    {
        this.gameObject.transform.position = new Vector3(_target.position.x, _target.position.y, _target.position.z - 10);
    }

    //Modificacion del script
}
