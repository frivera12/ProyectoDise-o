using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Logica : khetappAsistente
{

    private TableroLogico tablerologico;//tablero logico
    private Validaciones validaciones;//instancia para as validaciones.



    public TableroLogico getTablerologico()
    {
        return tablerologico;
    }
    public void setTablerologico(TableroLogico tab)
    {
        tablerologico = tab;
    }
    public Validaciones getValidaciones()
    {
        return validaciones;
    }
    public void setValidaciones(Validaciones val)
    {
        validaciones = val;
    }

    public void actualizarEstadoFichas(List<GameObject> fichasgraficasactivas)
    {
        // fichasgraficasactivas[1,1]= null;
    }

    void Awake()
    {
        // tablerologico = GetComponent<TableroLogico>();
        //validaciones= GetComponent<Validaciones>();
    }
    // Use this for initialization
    void Start()
    {

        //tablerologico.GenerarNivel1();
        tablerologico = new TableroLogico();
        validaciones = new Validaciones();


    }

    // Update is called once per frame
    void Update()
    {

    }
}
