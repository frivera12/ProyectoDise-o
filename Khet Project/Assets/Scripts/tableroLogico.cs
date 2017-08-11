using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tableroLogico : MonoBehaviour {


    private const float tamanioFicha = 1.0f;
    private const float borde = 0.5f;

    private int xActual = -1;
    private int yActual = -1;

    public List<GameObject> fichas;
    public List<GameObject> fichasActivas;


    void Start () {

        iniciarTableroClasico();

	}
	
	void Update () {
        revisarSeleccion();
        //dibujarTablero();    
	}

    private void dibujarTablero()
    {
        Vector3 rayaAncho = Vector3.right * 10;
        Vector3 rayaAltura = Vector3.forward * 8;

        for (int i = 0; i <= 8; i++)
        {
            Vector3 inicio = Vector3.forward * i;
            Debug.DrawLine(inicio, inicio + rayaAncho);
            for (int j = 0; j <= 10; j++)
            {
                inicio = Vector3.right * j;
                Debug.DrawLine(inicio, inicio + rayaAltura);
            }
        }

        //dibujar actual
        if(xActual >= 0 && yActual >= 0)
        {
            Debug.DrawLine(
                Vector3.forward * yActual + Vector3.right * xActual,
                Vector3.forward * (yActual + 1) + Vector3.right * (xActual + 1));
            Debug.DrawLine(
                Vector3.forward * (yActual + 1) + Vector3.right * xActual,
                Vector3.forward * yActual + Vector3.right * (xActual+1));
        }
    }

    private void revisarSeleccion()
    {
        if (!Camera.main)
            return;


        RaycastHit hit;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 25.0f, LayerMask.GetMask("tablero")))
        {
            xActual = (int)hit.point.x;
            yActual = (int)hit.point.z;
        }
        else
        {
            xActual = -1;
            yActual = -1;
        }
    } 

    private void colocarFicha(int index, Vector3 posicion)
    {
        GameObject temporal = Instantiate(fichas[index], posicion, Quaternion.identity) as GameObject;
        temporal.transform.SetParent(transform);
        fichasActivas.Add(temporal);
    }

    private Vector3 centrar(int x, int y)
    {
        Vector3 origen = Vector3.zero;
        origen.x += (tamanioFicha * x) + borde;
        origen.y = 0.5f;
        origen.z += (tamanioFicha * y) + borde;
        return origen; 
    }

    private void iniciarTableroClasico()
    {
        fichasActivas = new List<GameObject>();
        //fichas rojas
        colocarFicha(0, centrar(0, 7));
        colocarFicha(2, centrar(4, 7));
        colocarFicha(1, centrar(5, 7));
        colocarFicha(2, centrar(6, 7));
        colocarFicha(3, centrar(7, 7));
        colocarFicha(3, centrar(2, 6));
        colocarFicha(3, centrar(0, 4));
        colocarFicha(4, centrar(4, 4));
        colocarFicha(4, centrar(5, 4));
        colocarFicha(3, centrar(7, 4));
        colocarFicha(3, centrar(0, 3));
        colocarFicha(3, centrar(7, 3));
        colocarFicha(3, centrar(6, 2));

        //fichas blancas  
        colocarFicha(8, centrar(3,0));
        colocarFicha(7, centrar(4, 0));
        colocarFicha(6, centrar(5, 0));
        colocarFicha(7, centrar(6, 0));
        colocarFicha(5, centrar(9, 0));
        colocarFicha(8, centrar(7, 1));
        colocarFicha(8, centrar(2, 3));
        colocarFicha(8, centrar(9, 3));
        colocarFicha(9, centrar(4, 3));
        colocarFicha(9, centrar(5, 3));
        colocarFicha(8, centrar(2, 4));
        colocarFicha(8, centrar(9, 4));
        colocarFicha(8, centrar(3, 5));
    }
}
