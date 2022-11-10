using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetInterac : MonoBehaviour
{
    // Start is called before the first frame update
  public Textos textos;  //llamando a la clase 

  private void OnMouseDown() // cuando pinchemos en un objeto buscará el objeto que tenga el control de dialogos
  {
    FindObjectOfType<DialogEin>().ActivarCartel(textos);
  }


}
