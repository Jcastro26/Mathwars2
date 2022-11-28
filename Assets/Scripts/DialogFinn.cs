using System.Collections;
using UnityEngine;
using TMPro; // crear referencia de textm pro

public class DialogFinn : MonoBehaviour
{
    //creamos referencias para los clip de audio
   [SerializeField] private AudioClip npcVoice; // efectos de audio del npc
   [SerializeField] private AudioClip playerVoice; // efectos de sonido para el player pero en esta caso no hablo entonces los omitimos
   [SerializeField] private float typingTime; //la serializamos para poder editarla desde unity en el inspector
   [SerializeField] private int charsToPlaySound; //esto es para que cada x caracteres se reproduce el sonido
   [SerializeField] private bool isPlayerTalking; // para alternar sonidos

   [SerializeField] private GameObject dialogueMark; 
   [SerializeField] private GameObject dialoguePanel; // para activar y desactivar
   [SerializeField] private TMP_Text dialogueText;
    
   [SerializeField, TextArea(4, 6)] private string [] dialogueLines; //es para crear las lineas de texto, al parecer el serializeField crea espacios para modificar en el unity
    // el textArea es para delimitar un limite min y max de lineas

   //private float typingTime = 0.05f; //creamos esta variabla para sarla como parametro, la volvemos comentario porque modicaremos el tipio
   
   private AudioSource audioSource; // esto lo hacemos para poder agregar el audio, creamos aquí una variable que sirva de referencia 
   private bool isPlayerInRange; //principalmente creamos un buleano nos indicara si está cerc del npc
   private bool didDialogueStart; // indica si el dialogo comienza si es verdadero que el jugador esta cerca
   private int lineIndex; // para saber que linea de dialogo está mostrando

   private void Start () //dentro de este metodo vamos a establecer las componentes
   {
      audioSource = GetComponent<AudioSource>();
      audioSource.clip = npcVoice;   
   }

    void Update() //deteccion para empezar dialogo
    {
       if (isPlayerInRange && Input.GetButtonDown("Fire1")) 
       { 
         if (!didDialogueStart) // para empezar toca determinar que no ha iniciado
         {
            StartDialogue(); // inicia el dialogo
         }
         else if (dialogueText.text == dialogueLines[lineIndex])
         {
            NextDialogueLine();
         }
          else //para dejar de tipear y muestre de una las lineas completas
         {
            StopAllCoroutines();
            dialogueText.text = dialogueLines[lineIndex];

         }
         
       }

    }
   private void StartDialogue()
   {
         didDialogueStart = true; //inicia conver
         dialoguePanel.SetActive(true); // muestra el texto del panel
         dialogueMark.SetActive(false); // desactiva la negacion que se usó con el signo de exclamación ya que inicó la conver.
         lineIndex = 0; // para que con cada cambio de linea de texto se muestre la primera linea de cada texto
         Time.timeScale = 0.5f; //para que cuando inicie el dialogo no se mueva
         StartCoroutine(ShowLine2());
   }

    private void NextDialogueLine() // para tipear las lineas siguiente
    {
          lineIndex++; // aunmentamos el indice para tipear la siguiente
          if (lineIndex <dialogueLines.Length) // si el indice es menor a las lineas tendrá que seguir
          {
              StartCoroutine (ShowLine2()); //inicia la corutina hasta que no haya más lineas

          }
          else
          {
            didDialogueStart = false;
            dialoguePanel.SetActive(false);
            dialogueMark.SetActive(true);
            Time.timeScale = 1f;
          }
    }

   private void SelectAudioClip()
   {
      if(lineIndex != 0) //esto es para reproducir audio alternado
      {
         isPlayerTalking = !isPlayerTalking;
      }
      
      audioSource.clip = isPlayerTalking ? playerVoice : npcVoice; // operador ternario otra forma de alternar audio, es equivalente al if

       
   }


    //con esto que haremos como toca mostrar la primera linea, la haremos tipeada
    private IEnumerator ShowLine2()
    {
      SelectAudioClip();
      dialogueText.text = string.Empty;
      int charIndex = 0; //creamos un indice para saber el valor de los carateres actuales

      foreach (char ch in dialogueLines[lineIndex])
      {
        dialogueText.text += ch;
         
         if (charIndex % charsToPlaySound == 0)//para reproducir sonido, se le conoce como modulo, devuel la division entera para reproducir y ssi es entero cada 3 si el charstoplay sound se define en 3
         {
            audioSource.Play();
         }

         charIndex++;
         yield return new WaitForSeconds(typingTime);
      }
    }

     private void OnTriggerEnter2D(Collider2D collision)  // si se toca el npc se diaparará el ontritriger
    {
      if (collision.gameObject.CompareTag("Player"))
      {
         isPlayerInRange = true; 
         dialogueMark.SetActive(true); //aparecer bombillo cuando player se hacerque
         // Debug.Log("Se puede iniciar un dialogo"); // para comprobar si el jugador toca la franja de npc
      }
      
    }

     private void OnTriggerExit2D(Collider2D collision)  // si se sale del npc el ontritriger
     {
        if(collision.gameObject.CompareTag("Player"))
        {
            isPlayerInRange = false;   
             dialogueMark.SetActive(false); //desaparece cuando el jugador se aleja de box
           // Debug.Log("No se puede iniciar un dialogo"); // para comprobar si el jugador sale de la franja de npc
        }
       

     }
}
