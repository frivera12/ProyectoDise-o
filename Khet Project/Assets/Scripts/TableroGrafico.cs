using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableroGrafico : MonoBehaviour {

    //tamano del tablero
    private const float tamanioFicha = 1.0f;
    private const float borde = 0.5f;
    //posiciones de las matrizgrafica
    private int xActual = -1;
    private int yActual = -1;
    private FichaGrafica[,] fichasgraficasactivas { set; get; }
    private ArrayList FichasGraficas;  
    private FichaGrafica FichaSeleccionada;

    //posible manejo de turnos

    //posicion para rotar
    private float Xfloat = -1.0f;
    //matrizgrafica y sus posiciones
    public List<GameObject> PrefabsFichas;
    private List<GameObject> FichasActivas = new List<GameObject>();
    private Quaternion orientacion = Quaternion.Euler(0, 180, 0);

    TableroGrafico()
    {
       // matrizgrafica = new FichaGrafica[10,8];
    }
    public FichaGrafica[,] getFichasActivas()
    {
        return fichasgraficasactivas;
    }


    
    // Use this for initialization
    void Start()
    {
        setFichasTablero();
    }

    public void setFichasTablero()
    {
        FichaLogica ficha;
        FichaLogica[,] matriz = khetappAsistente.getkhetapp.logica.getTablerologico().getMatrizLogicaFichas();
        int lenghtX = matriz.GetLength(0), lenghtY = matriz.GetLength(1);

        for (int i = 0; i < lenghtX; i++)
        {
            for (int j = 0; j < lenghtY; j++)
            {   
                ficha = matriz[i, j];
                if (matriz[i, j] != null)
                {
                    ficha = matriz[i, j];
                    Debug.Log("tipo: " + ficha.getIndicePrefab() + " x: " + ficha.getActualX() + " y: " + ficha.getActualY());
                    colocarFichas(ficha.getIndicePrefab(), ficha.getActualX(), ficha.getActualY());
                }
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        revisarSeleccion();
        //dibujarTablero();
        if (Input.GetMouseButtonDown(0))
        {
            if (xActual >= 0 && yActual >= 0)
            {
                if (FichaSeleccionada == null)
                {
                    //seleccionar
                    SeleccionarFicha(xActual, yActual);
                }
                else if (FichaSeleccionada != null && FichaSeleccionada.getTipo() == 0)
                {

                    FichaSeleccionada = null;
                }
                else
                {
                    //mover
                    //if (ScriptLogica.Movio == false) {
                    //MoverFicha (xActual, yActual);
                    //}
                    FichaSeleccionada = null;
                }
            }
            //khetappAsistente.getkhetapp.logica.actualizarEstadoFichas(FichasActivas);//para pasar mensajes, usar metodos de otras clases.
        }
        else if (Input.GetMouseButtonDown(1))
        {

            if (xActual >= 0 && yActual >= 0)
            {
                if (FichaSeleccionada == null)
                {

                    SeleccionarFicha(xActual, yActual);
                }
                else
                {
                    /*if (ScriptLogica.Roto == false) {
						Rotar ();
						ScriptLogica.Roto = true;
					}*/
                    FichaSeleccionada = null;
                }
            }
        }
    }
    /*private void Rotar(){
		ActualizarFlotante ();
		if (Xfloat > (0.50f + FichaSeleccionada.getActualX ()) && Xfloat < (1.0f + FichaSeleccionada.getActualX ())
			&& yActual == FichaSeleccionada.getActualY ()) {
			FichaSeleccionada.transform.Rotate (0.0f, transform.rotation.y + 90, 0.0f);
		} else if (Xfloat < (0.50f + FichaSeleccionada.getActualX ()) && Xfloat > FichaSeleccionada.getActualX ()
			&& yActual == FichaSeleccionada.getActualY ()) {
			FichaSeleccionada.transform.Rotate (0.0f, transform.rotation.y - 90, 0.0f);
		}
	}*/

    private void colocarFichas(int indice, int x, int y)
    {
        Vector3 p = Centrar (x, y);
        GameObject go = Instantiate(PrefabsFichas[indice], p,/*Quaternion.identity*/orientacion) as GameObject;
        go.transform.SetParent(transform);
        //matrizgrafica[x, y] = go.GetComponent<FichaGrafica>();
       // matrizgrafica[x, y].SetPosicion(x, y);
        FichasActivas.Add(go);
    }
    
    private Vector3 Centrar(int x, int y) {
        //funcion que da una posicion a las matrizgrafica
        Vector3 origen = Vector3.zero;
        origen.x += (tamanioFicha * x) + borde;
        origen.y = 0.5f;
        origen.z += (tamanioFicha * y) + borde;
        return origen;
    }

    //clasico
   /* public void GenerarNivel1()
    {
        FichasActivas = new List<GameObject>();
        //matrizgrafica = new FichaGrafica[10, 8];
        //matrizgrafica rojas
        colocarFichas(0, 0, 7);
        colocarFichas(2, 4, 7);
        colocarFichas(1, 5, 7);
        colocarFichas(2, 6, 7);
        colocarFichas(3, 7, 7);
        colocarFichas(3, 2, 6);
        colocarFichas(3, 0, 4);
        colocarFichas(4, 4, 4);
        colocarFichas(4, 5, 4);
        colocarFichas(3, 7, 4);
        colocarFichas(3, 0, 3);
        colocarFichas(3, 7, 3);
        colocarFichas(3, 6, 2);
        //matrizgrafica blancas
        colocarFichas(8, 2, 0);
        colocarFichas(7, 3, 0);
        colocarFichas(6, 4, 0);
        colocarFichas(7, 5, 0);
        colocarFichas(5, 9, 0);
        colocarFichas(8, 7, 1);
        colocarFichas(8, 2, 3);
        colocarFichas(8, 9, 3);
        colocarFichas(9, 4, 3);
        colocarFichas(9, 5, 3);
        colocarFichas(8, 2, 4);
        colocarFichas(8, 9, 4);
        colocarFichas(8, 3, 5);

    }
    */

    //defensivo
    public void GenerarNivel2()
    {
        FichasActivas = new List<GameObject>();
        //matrizgrafica = new FichaGrafica[10, 8];
        //matrizgrafica rojas 
        colocarFichas(0, 0, 7);
        colocarFichas(2, 4, 7);
        colocarFichas(1, 5, 7);
        colocarFichas(2, 6, 7);
        colocarFichas(4, 7, 7);
        colocarFichas(3, 6, 5);
        colocarFichas(3, 0, 4);
        colocarFichas(4, 5, 4);
        colocarFichas(3, 8, 4);
        colocarFichas(3, 0, 3);
        colocarFichas(3, 5, 3);
        colocarFichas(3, 8, 3);
        colocarFichas(3, 6, 2);
        //matrizgrafica blancas
        colocarFichas(9, 2, 0);
        colocarFichas(7, 3, 0);
        colocarFichas(6, 4, 0);
        colocarFichas(7, 5, 0);
        colocarFichas(5, 9, 0);
        colocarFichas(8, 3, 2);
        colocarFichas(8, 1, 3);
        colocarFichas(8, 9, 3);
        colocarFichas(8, 4, 4);
        colocarFichas(9, 4, 3);
        colocarFichas(8, 1, 4);
        colocarFichas(8, 9, 4);
        colocarFichas(8, 3, 5);


    }

    // ofensivo y defensivo
    public void GenerarNivel3()
    {
        FichasActivas = new List<GameObject>();
       // matrizgrafica = new FichaGrafica[10, 8];
        colocarFichas(0, 0, 7);
        colocarFichas(3, 4, 7);
        colocarFichas(2, 5, 7);
        colocarFichas(3, 6, 7);
        colocarFichas(1, 5, 6);
        colocarFichas(3, 0, 5);
        colocarFichas(3, 4, 5);
        colocarFichas(2, 5, 5);
        colocarFichas(4, 6, 5);
        colocarFichas(3, 0, 4);
        colocarFichas(4, 2, 4);
        colocarFichas(3, 3, 3);
        colocarFichas(3, 5, 3);
        //matrizgrafica blancas
        colocarFichas(8, 3, 0);
        colocarFichas(7, 4, 0);
        colocarFichas(8, 5, 0);
        colocarFichas(5, 9, 0);
        colocarFichas(6, 4, 1);
        colocarFichas(9, 3, 2);
        colocarFichas(7, 4, 2);
        colocarFichas(8, 5, 2);
        colocarFichas(8, 9, 2);
        colocarFichas(9, 7, 3);
        colocarFichas(8, 9, 3);
        colocarFichas(8, 4, 4);
        colocarFichas(8, 6, 4);
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

    private void ActualizarFlotante()
    {
        if (!Camera.main)
            return;


        RaycastHit hit;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 25.0f, LayerMask.GetMask("tablero")))
        {
            Xfloat = hit.point.x;
        }
        else
        {
            Xfloat = -1;
        }
    }

    private void SeleccionarFicha(int x, int y)
    {
        /*if (matrizgrafica[x, y] == null)
        {
            return;

        }*/
        //if (matrizgrafica[x, y].esVerde != ScriptLogica.turnoJugadorVerde) {
        //return;
        //}
        /*	if (turnoJugadorVerde &&(matrizgrafica[x, y].EsVerde)) {
                FichaSeleccionada = matrizgrafica [x, y];
            } else {
                FichaSeleccionada = matrizgrafica [x, y];
            }*/

        //FichaSeleccionada = matrizgrafica[0, 2];

    }

    private void MoverFicha(int x, int y)
    {
       // matrizgrafica[FichaSeleccionada.getActualX(),
       // FichaSeleccionada.getActualY()] = null;
        //FichaSeleccionada.transform.position = ScriptLogica.Centrar(x, y);
        FichaSeleccionada.SetPosicion(x, y);
       // matrizgrafica[x, y] = FichaSeleccionada;
        /*if ((FichaSeleccionada.PosibleMovimiento(matrizgrafica, ScriptLogica.turnoJugadorVerde, FichaSeleccionada.getActualX(),
			FichaSeleccionada.getActualY(), x, y))
			&& FichaSeleccionada.CasillasExclusivas(matrizgrafica,FichaSeleccionada.getActualX(),
				FichaSeleccionada.getActualY(), x, y)) {
            //bool p=PoderMover (x, y);
            matrizgrafica[FichaSeleccionada.getActualX(),
                FichaSeleccionada.getActualY()] = null;
			//FichaSeleccionada.transform.position = ScriptLogica.Centrar(x, y);
            FichaSeleccionada.SetPosicion(x, y);
            matrizgrafica[x, y] = FichaSeleccionada;
			//ScriptLogica.Movio = true;
            System.Console.WriteLine("probando");
        }
		if (FichaSeleccionada.swap(matrizgrafica,  ScriptLogica.turnoJugadorVerde, FichaSeleccionada.getActualX(),
           FichaSeleccionada.getActualY(), x, y))
        {
            //  Ficha temporal = FichaSeleccionada;
            matrizgrafica[FichaSeleccionada.getActualX(), FichaSeleccionada.getActualY()] = matrizgrafica[x, y];
            matrizgrafica[x, y] = FichaSeleccionada;
        }


        FichaSeleccionada = null;
		ScriptLogica.TerminoTurno ();*/
    }





}
