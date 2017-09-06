using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grafica : khetappAsistente
{
    private TableroGrafico tablerografico;


    public TableroGrafico getTableroGrafico()
    {
        return tablerografico;
    }

    public void setTableroGrafico(TableroGrafico tab)
    {
        tablerografico=tab;
    }
    public Grafica getGrafica()
    {
        return this;
    }
    // Use this for initialization
    void Start () {
        

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    
}
