using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class logica : MonoBehaviour {
	private const float tamanioFicha = 1.0f;
	private const float borde = 0.5f;
	public bool turnoJugadorVerde;
	public bool Movio;
	public bool Roto;
	public bool Laser;
	public Vector3 Centrar(int x, int y) {
		//funcion que da una posicion a las fichas
		Vector3 origen = Vector3.zero;
		origen.x += (tamanioFicha * x) + borde;
		origen.y = 0.5f;
		origen.z += (tamanioFicha * y) + borde;
		return origen;
	}

	public void TerminoTurno() {
		if (Laser == true) {
			Debug.Log ("entro a laser turno");
			turnoJugadorVerde = !turnoJugadorVerde;
			Movio = false;
			Roto = false;
			Laser = false;
		}

	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
