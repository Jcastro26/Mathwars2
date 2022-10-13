using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 3f; // es para determinar la velocidad en la que de va mover ncp, se puede modificar desde el inspector

    //esto es una referencia (un atributo)
    private Rigidbody2D playerRb;
    private Vector2 moveInput; //para que se vea reflejado en fixeatdate
    private Animator playerAnimator; //para setear los otros movientos

    void Start ()
     {
          playerRb = GetComponent<Rigidbody2D>();
          playerAnimator = GetComponent<Animator>();
     }

    // Update is called once per frame

    //es posible crear los movimientos aquí pero es recomendable hacerlo con la funcion fixedatDate para cuando usamos RigidBody para objetos 
    void Update()
    {
       //tardan más //input
       float moveX = Input.GetAxisRaw("Horizontal"); //para contolar el moviento horizontal, retrona valores entre -1 y 1
       float moveY = Input.GetAxisRaw("Vertical");
       moveInput = new Vector2(moveX, moveY).normalized; //el normalized sirve para que sea un vector unitario y la velicidad sea la misma al combinar teclas. Sabiendo que la suma de vectores es mayor
 
       playerAnimator.SetFloat("Horizontal", moveX);
       playerAnimator.SetFloat("Vertical", moveY);
       playerAnimator.SetFloat("Speed", moveInput.sqrMagnitude); //este sqrmagnude sirve para la presicion del performan


    }

    private void FixedUpdate () //para ejecucion de pruebas fisicas
    {
      playerRb.MovePosition(playerRb.position + moveInput * speed * Time.fixedDeltaTime);  //para poder mover el npc

    }
}
