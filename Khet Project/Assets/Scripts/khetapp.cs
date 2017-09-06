
using UnityEngine;
//clase base para comunicar lo grafico de lo logico.
//podria comunicar tambien cliente-servidor




public class khetapp : MonoBehaviour
{
    public Grafica grafica;
    public Logica logica;
    public Manager manager;
    

    
    public void start()
    {

    }
}

public class khetappAsistente : MonoBehaviour
{
    //da el acceso a toda la aplicacion y todas las instancias.
    public static khetapp getkhetapp
    {
        get { return GameObject.FindObjectOfType<khetapp>(); }

    }
}