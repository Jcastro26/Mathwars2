using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Barco : MonoBehaviour
{
    //[SerializeField] private float healthAmout;
    //[SerializeField] private float healthAmin;
    [SerializeField] private float cantidadPuntos;
    [SerializeField] private Punto puntaje;
    public Image healthBar;
    public float healthAmount =100;

    //para empezar una estructura del puntaje declaramos el nombre
    /* una clase Barco que contenga informaci�n sobre cada barco, como su nombre y puntaje.
      Esta clase tambi�n puede tener m�todos para actualizar el puntaje cuando se le ataque.
     
     public string Nombre { get; set; }
      public int Puntaje { get; private set; }

      public Barco(string barcoenemigo)
      {
          Nombre = barcoenemigo;
          Puntaje = 50;
      }

      public void Atacar()
      {
          // L�gica para disminuir el puntaje cuando se ataque al barco
          Puntaje -= 10;
      }
    diccionario para almacenar los barcos, donde la clave ser� el nombre del barco y el valor ser� una instancia de la clase Barco. 
      Dictionary<string, Barco> barco = new Dictionary<string, Barco>();

      // Crear los barcos enemigos
      barco["barcoenemigo1"] = new Barco("barcoenemigo1");
      barco["barcoenemigo2"] = new Barco("barcoenemigo2");
      barco["barcoenemigo3"] = new Barco("barcoenemigo3");
     
    Cuando la funci�n toque a un barco enemigo, puedes buscarlo en el diccionario utilizando su nombre y luego llamar al m�todo Atacar() para disminuir su puntaje

      string nombreBarcoEnemigo = "barcoenemigo";
         if (barcos.ContainsKey(nombreBarcoEnemigo)){
             Barco barcoEnemigo = barcos[barcoenemigo];
              barcoEnemigo.Atacar();
     }
    Para mostrar los puntajes de los barcos en el cuadro de puntos, puedes recorrer el diccionario de barcos y acceder a los nombres y puntajes de cada uno.

     foreach (KeyValuePair<string, Barco> kvp in barcos){
        string nombreBarco = kvp.Key;
            Barco barco = kvp.Value;
            int puntajeBarco = barco.Puntaje;
            Debug.Log(nombreBarco + ": " + puntajeBarco);
    }
    Registro de barcos atacados:  usamos una lista para llevar un registro de los barcos
    que han sido atacados. Cada vez que se toca un barco enemigo, se puede agregar su nombre 
    a la lista de barcos atacados. 

    List<string> barcosAtacados = new List<string>();

// Cuando se toca un barco enemigo
         string nombreBarcoEnemigo = "barcoenemigo";
          if (barcos.ContainsKey(barcoenemigo))
           {
                Barco barcoEnemigo = barcos[barcoenemigo];
                barcoEnemigo.Atacar();
                barcosAtacados.Add(barcoenemigo);
           }

            Ordenar los puntajes:  mostrar los puntajes en un orden espec�fico, ordenar la lista de barcos en funci�n de los
            puntajes utilizando el m�todo Sort de la lista. 
            
                List<Barco> listaBarcos = new List<Barco>(barcos.Values);
            listaBarcos.Sort((b1, b2) => b1.Puntaje.CompareTo(b2.Puntaje));

            // Mostrar los puntajes ordenados
            foreach (Barco barco in listaBarcos)
            {
                Debug.Log(barco.Nombre + ": " + barco.Puntaje);
            }


      */
    // Start is called before the first frame update
    void Start(){
        
    }

    // Update is called once per frame
    void Update()
    {

    }


    

    public void TakeDamage(float damage){
        healthAmount-=damage;
        healthBar.fillAmount =healthAmount/100;
    }
    public void OnTriggerEnter2D(Collider2D other){
        if(other.tag=="punto"){
        this.TakeDamage(30);
        }
    }
}


/*
Dictionary<string, int> puntajes = new();

// Agregar puntajes
puntajes["barco"] = 100;


// Obtener puntaje de un jugador
int puntajeBarco = puntajes["barco"]; // Devuelve 200

// Actualizar puntaje de un jugador
puntajes["barco"] += 50;

// Eliminar puntaje de un jugador
puntajes.Remove("barcoenemigo");

// Recorrer los puntajes de los jugadores
foreach (KeyValuePair<string, int> puntaje in puntajes)
{
    string jugador = puntaje.Key;
    int puntajeValor = puntaje.Value;
    Debug.Log(jugador + ": " + puntajeValor);
}

*/

// Esto permitir�a gestionar el orden en el que se realizan los ataques a los barcos enemigos. Cada vez que se activa una funci�n de ataque, se
/* agregar�a el nombre del barco enemigo a la cola de ataques, y luego los ataques se realizar�an en el orden en el que fueron encolados.
* 
       * Queue<string> colaAtaques = new Queue<string>();

      // Cuando se activa una funci�n de ataque
      string nombreBarcoEnemigo = "Barco2";
      colaAtaques.Enqueue(nombreBarcoEnemigo);

      // Realizar los ataques en el orden de la cola
      while (colaAtaques.Count > 0)
      {
          string barcoAtacado = colaAtaques.Dequeue();

          // Verificar si el barco atacado existe en el diccionario
          if (barcos.ContainsKey(barcoAtacado))
          {
              Barco barcoEnemigo = barcos[barcoAtacado];
              barcoEnemigo.Atacar();
          }
      }
      //a cola colaAtaques se utiliza para almacenar los nombres de los barcos enemigos que ser�n atacados. 
         Cada vez que se activa una funci�n de ataque, el nombre del barco enemigo se agrega a la cola utilizando el m�todo Enqueue. 
          Luego, se realiza un bucle mientras la cola tenga elementos, extrayendo el primer elemento de la cola utilizando el m�todo Dequeue. 
          Se verifica si el barco atacado existe en el diccionario de barcos utilizando el nombre como clave. 
         Si existe, se obtiene la instancia del barco correspondiente y se llama al m�todo Atacar() para disminuir su puntaje.
*/

// Pilas
/*una pila de acciones realizadas. Esto permitir�a registrar y deshacer las acciones realizadas en el juego, como los ataques a los barcos enemigos. 
 * Cada vez que se realiza una acci�n, como un ataque, se agrega la acci�n a la pila, lo que permite deshacer las acciones en orden inverso.
 * 
         * Stack<Action> pilaAcciones = new Stack<Action>();

        // Cuando se realiza una acci�n, como un ataque
        string nombreBarcoEnemigo = "barcoenemigo";

        // Guardar la acci�n en la pila
        pilaAcciones.Push(() =>
        {
            if (barcos.ContainsKey(nombreBarcoEnemigo))
            {
                Barco barcoEnemigo = barcos[nombreBarcoEnemigo];
                barcoEnemigo.Atacar();
            }
        });

        // Realizar las acciones en orden inverso (deshacer)
        while (pilaAcciones.Count > 0)
        {
            Action accion = pilaAcciones.Pop();
            accion.Invoke();
        }

 * la pila pilaAcciones se utiliza para almacenar acciones que representan las operaciones realizadas en el juego, 
 * como los ataques a los barcos enemigos. Cada vez que se realiza una acci�n, se crea una funci�n an�nima (lambda) 
 * que encapsula la l�gica de la acci�n y se agrega a la pila utilizando el m�todo Push.
 * Luego, se puede deshacer las acciones en orden inverso, extrayendo las acciones de la pila utilizando 
 * el m�todo Pop y llamando a Invoke para ejecutar la acci�n correspondiente.
 * El uso de una pila permite deshacer las acciones en el orden inverso en el que se realizaron,
 * lo que puede ser �til para implementar funcionalidades como deshacer movimientos o retroceder en el tiempo dentro del juego.
 */

//arreglos
/*
 * Almacenar los barcos enemigos: un arreglo para almacenar los barcos enemigos. 
 * Cada elemento del arreglo representar�a un barco enemigo y contendr�a informaci�n como su nombre, puntaje, posici�n, estado
 * 
 * BarcoEnemigo[] barcosEnemigos = new BarcoEnemigo[3];

        barcosEnemigos[0] = new BarcoEnemigo("Barco1", 100, new Vector3(0, 0, 0));
        barcosEnemigos[1] = new BarcoEnemigo("Barco2", 150, new Vector3(2, 0, 0));
        barcosEnemigos[2] = new BarcoEnemigo("Barco3", 200, new Vector3(4, 0, 0));

// almacenar los Ataques
Almacenar los ataques realizados: Puedes utilizar un arreglo para almacenar los ataques realizados por los jugadores. Cada elemento del arreglo
representar�a un ataque y podr�a contener informaci�n como el jugador que realiz� el ataque, el barco enemigo atacado, el da�o infligido

int[] puntajesJugadores = new int[4];

puntajesJugadores[0] = 100;
puntajesJugadores[1] = 150;
puntajesJugadores[2] = 200;
puntajesJugadores[3] = 50;


 */