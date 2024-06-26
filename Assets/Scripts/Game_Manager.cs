using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Game_Manager : MonoBehaviour
{
    //Declaramos la lista de Pre-Fabs
    public GameObject[] PrefabList;

    //Creamos dos variables publicas de tipo "Transform", para tener la ubicacion de Pedestal 1 y 2
    public Transform Pedestal_1;
    public Transform Pedestal_2;

    //Declaramos una variable que manejara el dinero
    public int Cash;
    public Text CashText;

    //Declaramos 2 variables de tipo "Text", para vincularlo con nuestros textos de cuanto cuesta el articulo
    public Text Texto_Objeto1;
    public Text Texto_Objeto2;

    //Crea las variables de valor de Objeto, para simplificar codigo mas adelante
    public int Objeto1_Value;
    public int Objeto2_Value;

    //Suma del valor de ambos Objetos
    public int Objeto1y2_Value;

    //Despues de responder se mostrara este panel que originalemnete staba oculto
    public GameObject PanelAnswer;
    //Texto de si la respuesta fue correcta o no el cual se encuentra dentro del AnswerPanel
    public Text Answer_Text;
    //Al precionarse este button, se reinicia el juego, este es el texto del button, ya que depnediendo de si la respuesta fue correcta o no apreceera una frase o otra.
    public Text Button_Reiniciar_Text;
    void Start()
    {     
        //Calcula un numero Random entre 0 y 75, que sera el cash, y lo coloca en el texto "CashText"
        Cash = Random.Range(0, 76);
        CashText.text = Cash + " $";

        //Declaramos dos variables de tipo "int", que son nuestros dos numeros random que usaremos para seleccionar el objeto que saldra
        int Random_Number_1 = Random.Range(0, PrefabList.Length);
        int Random_Number_2 = Random.Range(0, PrefabList.Length);

        //Instantea los dos objetos encima de los pedestales correspondientes
        Instantiate(PrefabList[Random_Number_1], new Vector3 (Pedestal_1.position.x, Pedestal_1.position.y + 1.3f, Pedestal_1.position.z), PrefabList[Random_Number_1].transform.rotation);
        Instantiate(PrefabList[Random_Number_2], new Vector3 (Pedestal_2.position.x, Pedestal_2.position.y + 1.3f, Pedestal_2.position.z), PrefabList[Random_Number_2].transform.rotation);

        //Asigna valor a las variables de valor de Objeto
        Objeto1_Value = PrefabList[Random_Number_1].GetComponent<Value_Script>().Value;
        Objeto2_Value = PrefabList[Random_Number_2].GetComponent<Value_Script>().Value;

        //Asigna al texto del pequeño panel abajo de los pedestales el valor con el simbolo de dinero
        Texto_Objeto1.text = Objeto1_Value + "  $";
        Texto_Objeto2.text = Objeto2_Value + "  $";

        Objeto1y2_Value = Objeto1_Value + Objeto2_Value;
    }

    public void No_Alcanza_Button() 
    {
        if (Cash < Objeto1y2_Value)
        {
            Debug.Log("Correct");
            MostrarPanelCorrecto();
        }
        else 
        {
            Debug.Log("InCorrect");
            MostrarPanelInCorrecto();
        }
    }
    public void Alcanza_Justo_Button()
    {
        //logica del boton que compara si el presupuesto es suficiente para saldar justo
        if (Cash == Objeto1y2_Value)
        {
            Debug.Log("Correct");
            MostrarPanelCorrecto();
        }
        else
        {
            Debug.Log("InCorrect");
            MostrarPanelInCorrecto();
        }
    }

    public void Alcanza_y_Sobra_Button()
    {
        //logica del boton que compara si el presupuesto no alcanza
        if (Cash > Objeto1y2_Value)
        {
            Debug.Log("Correct");
            MostrarPanelCorrecto();
        }
        else
        {
            Debug.Log("InCorrect");
            MostrarPanelInCorrecto();
        }
    }
    public void CargarEcenaJuego3() 
    {
        SceneManager.LoadScene("Juego3");
    }
    public void CargarEcenaSeleccionarJuegos()
    {
        SceneManager.LoadScene("SeleccionarJuegos");
    }

    public void MostrarPanelCorrecto() 
    {
        Answer_Text.text = "Correcto";
        Button_Reiniciar_Text.text = "Reiniciar el desafío";

        PanelAnswer.SetActive(true);
    }
    public void MostrarPanelInCorrecto()
    {
        Answer_Text.text = "Incorrecto";
        Button_Reiniciar_Text.text = "Volver a intentarlo";

        PanelAnswer.SetActive(true);
    }

}
