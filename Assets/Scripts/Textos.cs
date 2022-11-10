using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] // no va estar asociado a ningun objeto y se podra modificar


public class Textos // no se hereda de monobahabior porque va ser importada en otras clases
{
    // Start is called before the first frame update
     [TextArea (4,6)]  // area de texto min y max
     public string[] arrayTextos; // tendrá diferentes cajas de texto

    
   
}
