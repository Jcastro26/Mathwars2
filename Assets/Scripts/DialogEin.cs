using System.Collections;

using UnityEngine;
using TMPro;

public class DialogEin : MonoBehaviour
{
    // Start is called before the first frame update

    private Animator anim; // para cntrolar animacion desde codigo
    private Queue <string> colaDialogos; // es como una lista "arraylis"
    Textos texto;
    [SerializeField] TextMeshProUGUI textoPantalla;
    
   
    public void ActivarCartel(Textos textoObjeto)
    {
        anim.SetBool("Cartel", true);
        texto = textoObjeto;
    }

    public void ActivaTexto()
    {
        colaDialogos.Clear();
        foreach (string textoGuardar in texto.arrayTextos)
        {
            colaDialogos.Enqueue(textoGuardar);
        }
       SiguienteFrase();
    }

    public void SiguienteFrase()
    {
        if(colaDialogos.Count == 0)
        {
            CierraCartel();
            return;
        }
        string fraseActual = colaDialogos.Dequeue();
        textoPantalla.text = fraseActual;
        StartCoroutine(MostrarCaracteres(fraseActual));

    }


    void CierraCartel ()
    {
        ani.SetBool("Cartel", false);
    }

}
