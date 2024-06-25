using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Value_Script : MonoBehaviour
{
    public int Value;
    private float Rotation_Velocity = 40;

    void Start()
    {
        
    }

    void Update()
    {
        transform.Rotate(0, Rotation_Velocity * Time.deltaTime, 0, Space.World);
    }
}
