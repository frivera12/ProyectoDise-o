using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tableroLogico : MonoBehaviour {

	//tamano del tablero
    private const float tamanioFicha = 1.0f;
    private const float borde = 0.5f;
	//posiciones de las fichas
    private int xActual = -1;
    private int yActual = -1;

	public Ficha[,] fichas{ set; get;}

	private Ficha FichaSeleccionada;

	//posible manaje de turnos
	private bool turnoJugadorVerde;
	private bool Movio;
	private bool Roto;
	private bool Laser;

	//posicion para rotar
	private float Xfloat = -1.0f;
	//fichas y sus posiciones
	public List<GameObject> PrefabsFichas;
	private List<GameObject>FichasActivas = new List<GameObject>() ;
	private Quaternion orientacion = Quaternion.Euler(0,180,0);


    // Use this for initialization
    void Start () {

		Roto = false;
		Movio = false;
		Laser = false;
		GenerarNivel1 ();
	}

	// Update is called once per frame
	void Update () {
		revisarSeleccion();
		dibujarTablero();
		if (Input.GetMouseButtonDown (0)) {
			if (xActual >= 0 && yActual >= 0) {
				if (FichaSeleccionada== null) {
					//seleccionar
					SeleccionarFicha(xActual,yActual);
				}else{
					//mover
					MoverFicha(xActual,yActual);
				}
			}
		}
		if (Input.GetMouseButtonDown (1)) {
			if (xActual >= 0 && yActual >= 0) {
				if (FichaSeleccionada == null) {
					SeleccionarFicha(xActual,yActual);
				}else{
					ActualizarFlotante();

					if (Xfloat  > (0.50f+ FichaSeleccionada.ActualX) && Xfloat < (1.0f+ FichaSeleccionada.ActualX) 
						&& yActual == FichaSeleccionada.ActualY) {
						FichaSeleccionada.transform.Rotate(0.0f, transform.rotation.y + 90, 0.0f);
						//Debug.Log("roto derecha");
					}
					else if(Xfloat< (0.50f+ FichaSeleccionada.ActualX) && Xfloat > FichaSeleccionada.ActualX 
						&& yActual == FichaSeleccionada.ActualY)
					{
						FichaSeleccionada.transform.Rotate(0.0f, transform.rotation.y - 90, 0.0f);
						//Debug.Log("roto izquierda");
					}
					Roto = true;
				}
			}
		}
	}

	private void ColocarFichas(int indice,int x,int y){
		GameObject go = Instantiate (PrefabsFichas [indice],
			Centrar(x,y),/*Quaternion.identity*/orientacion) as GameObject;
		go.transform.SetParent (transform);
		fichas [x, y] = go.GetComponent<Ficha> ();
		fichas [x, y].SetPosicion (x, y);
		FichasActivas.Add (go);
	}

	private Vector3 Centrar(int x,int y){
		//funcion que da una posicion a las fichas
		Vector3 origen = Vector2.zero;
		origen.x += (tamanioFicha * x) + borde;
		origen.z +=(tamanioFicha* y)+borde;
		return origen;
	}
	public void GenerarNivel1(){
		FichasActivas = new List<GameObject> ();
		fichas = new Ficha[8, 10];
		//piramide
		ColocarFichas(0,2,3);
		ColocarFichas (0,1,1);
		//faraon
		ColocarFichas(1,3,3);
	
	}
	public void GenerarNivel2(){
		FichasActivas = new List<GameObject> ();
		fichas = new Ficha[8, 10];

	}
	public void GenerarNivel3(){
		FichasActivas = new List<GameObject> ();
		fichas = new Ficha[8, 10];
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

	private void ActualizarFlotante()
	{
		if (!Camera.main)
			return;


		RaycastHit hit;
		if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 25.0f, LayerMask.GetMask("ChessPlane")))
		{    
			Xfloat = hit.point.x;          
		}
		else
		{
			Xfloat = -1;
		}
	}

	private void SeleccionarFicha(int x,int y){
		if (fichas [x, y] == null) {
			return;

		}
		/*if (fichas[x, y].esVerde != turnoJugadorVerde) {
			return;
		}*/
	/*	if (turnoJugadorVerde &&(fichas[x, y].EsVerde)) {
			FichaSeleccionada = fichas [x, y];
		} else {
			FichaSeleccionada = fichas [x, y];
		}*/
		FichaSeleccionada = fichas[x, y];

	}

	private void MoverFicha(int x,int y){
		if (FichaSeleccionada.PosibleMovimiento(fichas,FichaSeleccionada.ActualX,
			FichaSeleccionada.ActualY,x,y)) {
			//bool p=PoderMover (x, y);
			fichas [FichaSeleccionada.ActualX,
				FichaSeleccionada.ActualY]=null;
			FichaSeleccionada.transform.position = Centrar(x, y);
			FichaSeleccionada.SetPosicion (x, y);
			fichas [x, y] = FichaSeleccionada;
			Movio = true;
		}
		FichaSeleccionada = null;
	}

	private void TerminoTurno(){
	
	
	}




}
