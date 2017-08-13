using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ficha : MonoBehaviour {
	private int ActualX{ set; get;}
    private int ActualY{ set; get;}
    private bool esVerde { get; set; }



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
            if (Math.Abs(x1 - x2) == 1 || Math.Abs(y1 - y2) == 1 && fichas[x2, y2] == null)
            {
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
