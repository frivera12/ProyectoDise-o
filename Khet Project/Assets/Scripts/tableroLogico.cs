using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tableroLogico : MonoBehaviour {
	private logica ScriptLogica;
    //tamano del tablero
    private const float tamanioFicha = 1.0f;
    private const float borde = 0.5f;
    //posiciones de las fichas
    private int xActual = -1;
    private int yActual = -1;

    public Ficha[,] fichas { set; get; }

    private Ficha FichaSeleccionada;

    //posible manejo de turnos
   

    //posicion para rotar
    private float Xfloat = -1.0f;
    //fichas y sus posiciones
    public List<GameObject> PrefabsFichas;
    private List<GameObject> FichasActivas = new List<GameObject>();
    private Quaternion orientacion = Quaternion.Euler(0, 180, 0);


    // Use this for initialization
    void Start() {
		ScriptLogica = this.GetComponent<logica> ();
		ScriptLogica.turnoJugadorVerde = true;
		ScriptLogica.Roto = false;
		ScriptLogica.Movio = false;
		ScriptLogica.Laser = false;
        GenerarNivel1();
		/*for (int i = 0; i < 10; i++) {
			for (int j = 0; j < 8; j++) {
				if (fichas [i, j] != null) {
					Debug.Log ("tiene" + fichas [i, j].getTipo ());
				}
			}
		}*/
    }

    // Update is called once per frame
    void Update() {
        revisarSeleccion();
        //dibujarTablero();
        if (Input.GetMouseButtonDown(0)) {
            if (xActual >= 0 && yActual >= 0) {
				if (FichaSeleccionada == null) {
					//seleccionar
					SeleccionarFicha (xActual, yActual);
				} else if (FichaSeleccionada != null && FichaSeleccionada.getTipo () == 0) {
					ScriptLogica.Laser = true;
					Debug.Log("ejecuto laser");
					ScriptLogica.TerminoTurno ();
					FichaSeleccionada = null;
				}
				else {
                    //mover
					if (ScriptLogica.Movio == false) {
						MoverFicha (xActual, yActual);
					}
					FichaSeleccionada = null;
                }
            }
        }else if (Input.GetMouseButtonDown(1)) {
			
            if (xActual >= 0 && yActual >= 0) {
                if (FichaSeleccionada == null) {

                    SeleccionarFicha(xActual, yActual);
                } else {
					if (ScriptLogica.Roto == false) {
						Rotar ();
						ScriptLogica.Roto = true;
					}
					FichaSeleccionada = null;
                }
            }
        }
    }
	private void Rotar(){
		ActualizarFlotante ();
		if (Xfloat > (0.50f + FichaSeleccionada.getActualX ()) && Xfloat < (1.0f + FichaSeleccionada.getActualX ())
			&& yActual == FichaSeleccionada.getActualY ()) {
			FichaSeleccionada.transform.Rotate (0.0f, transform.rotation.y + 90, 0.0f);
		} else if (Xfloat < (0.50f + FichaSeleccionada.getActualX ()) && Xfloat > FichaSeleccionada.getActualX ()
			&& yActual == FichaSeleccionada.getActualY ()) {
			FichaSeleccionada.transform.Rotate (0.0f, transform.rotation.y - 90, 0.0f);
		}
	}

    private void colocarFichas(int indice, int x, int y) {
		Vector3 p = ScriptLogica.Centrar (x, y);
        GameObject go = Instantiate(PrefabsFichas[indice], p,/*Quaternion.identity*/orientacion) as GameObject;
        go.transform.SetParent(transform);
        fichas[x, y] = go.GetComponent<Ficha>();
        fichas[x, y].SetPosicion(x, y);
        FichasActivas.Add(go);
    }
	/*
    private Vector3 Centrar(int x, int y) {
        //funcion que da una posicion a las fichas
        Vector3 origen = Vector3.zero;
        origen.x += (tamanioFicha * x) + borde;
        origen.y = 0.5f;
        origen.z += (tamanioFicha * y) + borde;
        return origen;
    }*/

    //clasico
    public void GenerarNivel1() {
        FichasActivas = new List<GameObject>();
        fichas = new Ficha[10, 8];
        //fichas rojas
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
        //fichas blancas
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


    //defensivo
    public void GenerarNivel2()
    {
        FichasActivas = new List<GameObject>();
        fichas = new Ficha[10, 8];
        //fichas rojas 
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
        //fichas blancas
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
    public void GenerarNivel3() {
        FichasActivas = new List<GameObject>();
        fichas = new Ficha[10, 8];
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
        //fichas blancas
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


	/*
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
        if (xActual >= 0 && yActual >= 0)
        {
            Debug.DrawLine(
                Vector3.forward * yActual + Vector3.right * xActual,
                Vector3.forward * (yActual + 1) + Vector3.right * (xActual + 1));
            Debug.DrawLine(
                Vector3.forward * (yActual + 1) + Vector3.right * xActual,
                Vector3.forward * yActual + Vector3.right * (xActual + 1));
        }
    }
*/
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

    private void SeleccionarFicha(int x, int y) {
        if (fichas[x, y] == null) {
            return;

        }
		if (fichas[x, y].esVerde != ScriptLogica.turnoJugadorVerde) {
			return;
		}
        /*	if (turnoJugadorVerde &&(fichas[x, y].EsVerde)) {
                FichaSeleccionada = fichas [x, y];
            } else {
                FichaSeleccionada = fichas [x, y];
            }*/
        FichaSeleccionada = fichas[x, y];

    }

    private void MoverFicha(int x, int y) {
		if ((FichaSeleccionada.PosibleMovimiento(fichas, ScriptLogica.turnoJugadorVerde, FichaSeleccionada.getActualX(),
			FichaSeleccionada.getActualY(), x, y))
			&& FichaSeleccionada.CasillasExclusivas(fichas,FichaSeleccionada.getActualX(),
				FichaSeleccionada.getActualY(), x, y)) {
            //bool p=PoderMover (x, y);
            fichas[FichaSeleccionada.getActualX(),
                FichaSeleccionada.getActualY()] = null;
			FichaSeleccionada.transform.position = ScriptLogica.Centrar(x, y);
            FichaSeleccionada.SetPosicion(x, y);
            fichas[x, y] = FichaSeleccionada;
			ScriptLogica.Movio = true;
            System.Console.WriteLine("probando");
        }
		if (FichaSeleccionada.swap(fichas,  ScriptLogica.turnoJugadorVerde, FichaSeleccionada.getActualX(),
           FichaSeleccionada.getActualY(), x, y))
        {
            //  Ficha temporal = FichaSeleccionada;
            fichas[FichaSeleccionada.getActualX(), FichaSeleccionada.getActualY()] = fichas[x, y];
            fichas[x, y] = FichaSeleccionada;
        }


        FichaSeleccionada = null;
		ScriptLogica.TerminoTurno ();
    }

   

 




}
