using System.Collections;
using UnityEngine;
using TMPro; // crear referencia de textm pro

public class Dialog_Eins : MonoBehaviour
{
    [SerializeField] private GameObject Fallastetexto;   
    [SerializeField] private GameObject DialogBombi; 
    [SerializeField] private GameObject dialoguePanel; // para activar y desactivar
    [SerializeField] private TMP_Text dialogueText;
    [SerializeField, TextArea(4,6)] private string [] dialogueLines; //es para crear las lineas de texto, al parecer el serializeField crea espacios para modificar en el unity
    // el textArea es para delimitar un limite min y max de lineas
   
   private float typingTime = 0.05f; //creamos esta variabla para sarla como parametro
   
   private bool isPlayerInRange; //principalmente creamos un buleano nos indicara si está cerc del npc
   private bool didDialogueStart; // indica si el dialogo comienza si es verdadero que el jugador esta cerca
   private int lineIndex; // para saber que linea de dialogo está mostrando

   
     void Update() //deteccion para empezar dialogo
    {
       if (isPlayerInRange && Input.GetButtonDown("Fire1")) 
       { 
         if (!didDialogueStart) // para empezar toca determinar que no ha iniciado
         {
            StartDialogue(); // inicia el dialogo
         }
         else if (dialogueText.text == dialogueLines[lineIndex]) // si mostró la linea completa pasa a la otra linea
         {
            NextDialogueLine();
         }
         else //para dejar de tipear y muestre de una las lineas completas
         {
            StopAllCoroutines();
            dialogueText.text = dialogueLines[lineIndex];

         }
         
       }
       var puntos = GameObject.FindGameObjectsWithTag ("punto");
      foreach(var punto in puntos){
         if(punto.transform.position.x>=5.1f){
         dialoguePanel.SetActive(true); 
         Fallastetexto.SetActive(true);
         }
         
      }

    }

     private void StartDialogue()
   {
         didDialogueStart = true; //inicia conver
         dialoguePanel.SetActive(true); // muestra el texto del panel
         DialogBombi.SetActive(false); // desactiva la negacion que se usó con el signo de exclamación ya que inicó la conver.
         lineIndex = 0; // para que con cada cambio de linea de texto se muestre la primera linea de cada texto
         Time.timeScale = 0f; //para que cuando inicie el dialogo no se mueva
         StartCoroutine(ShowLine());
   }

   private void NextDialogueLine() // para tipear las lineas siguiente
    {
          lineIndex++; // aunmentamos el indice para tipear la siguiente
          if (lineIndex <dialogueLines.Length) // si el indice es menor a las lineas tendrá que seguir
          {
              StartCoroutine (ShowLine()); //inicia la corutina hasta que no haya más lineas

          }
          else // sino hay mas lineas se detiene
          {
            didDialogueStart = false;
            dialoguePanel.SetActive(false);
            DialogBombi.SetActive(true);
            Time.timeScale = 1f;
          }
    }

     //con esto que haremos como toca mostrar la primera linea, la haremos tipeada. corrutina
    private IEnumerator ShowLine()
    {
      dialogueText.text = string.Empty;

      foreach (char ch in dialogueLines[lineIndex])
      {
         dialogueText.text += ch;
         yield return new WaitForSecondsRealtime(typingTime);
      }
    }


     private void OnTriggerEnter2D(Collider2D collision)  // si se toca el npc se diaparará el ontritriger
    {
      if (collision.gameObject.CompareTag("Player"))
      {
         isPlayerInRange = true; 
         DialogBombi.SetActive(true); //aparecer bombillo cuando player se hacerque
         Debug.Log("Se puede iniciar un dialogo"); // para comprobar si el jugador toca la franja de npc
      }
      
    }

     private void OnTriggerExit2D(Collider2D collision)  // si se sale del npc el ontritriger
     {
        if(collision.gameObject.CompareTag("Player"))
        {
             isPlayerInRange = false;   
             DialogBombi.SetActive(false); //desaparece cuando el jugador se aleja de box
             Debug.Log("No se puede iniciar un dialogo"); // para comprobar si el jugador sale de la franja de npc
        }
       

     }
}
