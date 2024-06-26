using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Value_Script : MonoBehaviour
{
   //Script que lo contienen todos los objetos con precios y que seran mostrados encima de los pedestales 
    
    
    
    //Variable d etipo int que le da el precio a los bjetos que lo contenga
    public int Value;
    //variable que establece la velocidad con la cual rotan os objetos cuando se muestran 
    private float Rotation_Velocity = 40;

    void Start()
    {
        
    }

    void Update()
    {
        //funcion del transform para que rote 
        transform.Rotate(0, Rotation_Velocity * Time.deltaTime, 0, Space.World);
    }
}
