using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ficha : MonoBehaviour {
	private int ActualX{ set; get;}
    private int ActualY{ set; get;}
	public bool esVerde;



    ~Ficha()
    {
        Ficha ficha = this;
        ficha = null;
        
    }
		
    public int getActualX()
    {
        return ActualX;
    }
    public int getActualY()
    {
        return ActualY;
    }
    public void setActualX(int x)
    {
        ActualX = x;
    }
    public bool getEsVerde()
    {
        return esVerde;
    }
    public void setEsVerde(bool esv)
    {
        esVerde = esv;
    }
    public void setActualY(int y)
    {
        ActualY = y;
    }
    public void SetPosicion(int x,int y){
		ActualX = x;
		ActualY = y;
	}
    public bool swap(Ficha[,] fichas, bool turnoJugador, int x1, int y1, int x2, int y2)//valida y realiza el swap.
    {
        if (fichas[x1,y2].esVerde == fichas[x2, y2].esVerde)
        {
            return true;
        }
        return false;
    }
	public virtual bool PosibleMovimiento(Ficha[,]fichas, bool turnoJugador,int x1,int y1,int x2,int y2){//true si eligio una posicion valida para mover.  
        if (x2 >= 0 && y2 <= 8 && x2 <=10 && y2 >= 0)////arreglar
        {
            if (Math.Abs(x2 - x1) <= 1 && Math.Abs(y2 - y1) <= 1
                 && fichas[x2, y2] == null)
            {
                return true;
            }
        }
		return false;
	}

	public virtual bool CasillasExclusivas(Ficha[,]fichas,int x1,int y1,int x2,int y2){
		//Debug.Log (x1+" "+y1 +" piezas dos"+ x2+" "+y2);
		if (fichas [x1, y1].esVerde==false) {
			//if de la roja (x2 == 8 && y2 == 0) || (x2 == 8 && y2 == 7)
			if ((x2 == 1 && y2 == 0) || (x2 == 1 && y2 == 7) || (x2 == 9)) {
				Debug.Log ("No puede entrar rojo");
				return false;
			} else {
				Debug.Log ("no es verde");
				return true;
			}
		} else {
			//si es verde o blanca (x2 == 1 && y2 == 0) || (x2 == 1 && y2 == 7)
			if ((x2 == 8 && y2 == 0) || (x2 == 8 && y2 == 7) || (x2 == 0)) {
				Debug.Log ("No puede entrar verde");
				return false;
			} else {
				Debug.Log ("es verde");
				return true;
			}
		}
		return false;
	
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    

}
