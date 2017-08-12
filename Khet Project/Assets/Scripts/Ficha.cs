using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ficha : MonoBehaviour {
	public int ActualX{ set; get;}
	public int ActualY{ set; get;}
	public bool esVerde;

	public void SetPosicion(int x,int y){
		ActualX = x;
		ActualY = y;
	}

	public virtual bool PosibleMovimiento(Ficha[,] fichas,int x1,int y1,int x2,int y2){
		
		return true;
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
