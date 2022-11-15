using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkManager : MonoBehaviour
{
  public void CreateUser(string userName,string Email,string pass, Action <Response> response)
{
  StarCoroutine(CO_CreateUser(userName,Email,Password,response));
}
private IEnumerator CO_CreateUser(string userName,string Email,string pass, Action <Response> response)//inicio de COrrutina para esperar al sevidor (por q no c hace en un frame)
{
   wwwwform form = new wwwwform();
   form.addField("username",userName);
   form.addField("Email",Email);
   form.addField("Password",Password);

   WWW w = new wwww("http://localhost/Game/createuser.php",form);

   yield return w;

 response (JsonUtility.FromJson<Response>(w.text));//trasforma la respuesta en linea por una tipo response
}

}
[Serializable]
public class Response
{
    public bool done = false;
    public string message = "usuario no registrado";
}