using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Validaciones {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public bool swap(FichaLogica[,] fichas, bool turnoJugador, int x1, int y1, int x2, int y2)//valida y realiza el swap.
    {//valida si el jugador escogio 2 de sus piezas para el swap, y si el swap es entre escarabajo y piramide o escarabajo y torre.
        if (fichas[x1, y1].getJugador() == fichas[x2, y2].getJugador() && fichas[x1, y1].getTipo() == 4 && (fichas[x2, y2].getTipo() == 3 || fichas[x2, y2].getTipo() == 2))
        {
            return true;
        }
        return false;
    }
    

    public virtual bool CasillasExclusivas(FichaLogica[,] fichas, int x1, int y1, int x2, int y2)
    {
        //Debug.Log (x1+" "+y1 +" piezas dos"+ x2+" "+y2);
        if (fichas[x1, y1].getJugador() == 1)
        {
            //if de la roja (x2 == 8 && y2 == 0) || (x2 == 8 && y2 == 7)
            if ((x2 == 1 && y2 == 0) || (x2 == 1 && y2 == 7) || (x2 == 9))
            {
                Debug.Log("No puede entrar rojo");
                return false;
            }
            else
            {
                Debug.Log("no es verde");
                return true;
            }
        }
        else
        {
            //si es verde o blanca (x2 == 1 && y2 == 0) || (x2 == 1 && y2 == 7)
            if ((x2 == 8 && y2 == 0) || (x2 == 8 && y2 == 7) || (x2 == 0))
            {
                Debug.Log("No puede entrar verde");
                return false;
            }
            else
            {
                Debug.Log("es verde");
                return true;
            }
        }
        return false;

    }
    public virtual bool PosibleMovimiento(FichaGrafica[,] fichas, bool turnoJugador, int x1, int y1, int x2, int y2)
    {//true si eligio una posicion valida para mover.  
        if (x2 >= 0 && y2 <= 8 && x2 <= 10 && y2 >= 0)////arreglar
        {
            if (Math.Abs(x2 - x1) <= 1 && Math.Abs(y2 - y1) <= 1
                 && fichas[x2, y2] == null)
            {
                return true;
            }
        }
        return false;
    }
}
