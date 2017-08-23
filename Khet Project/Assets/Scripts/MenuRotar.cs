using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuRotar : MonoBehaviour {
	public int Roto;
	void Awake(){
		
		DontDestroyOnLoad (gameObject);

	}
	// Use this for initialization
	void Start () {
		
	}
	public void Arriba(){
		Roto = 1;
		SceneManager.LoadScene ("Game");
	}
	public void Abajo(){
		Roto = 3;
		SceneManager.LoadScene ("Game");
	}
	public void Derecha(){
		Roto = 4;
		SceneManager.LoadScene ("Game");
	}
	public void Izquierda(){
		Roto = 5;
		SceneManager.LoadScene ("Game");
	}
	// Update is called once per frame
	void Update () {
		
		
	}
}
