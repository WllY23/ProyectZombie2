﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour 
{
	Zonbiedates _zonbi; // instancia de la estructura zombie 
	datosciudadano _citi; // instancia de la estructura ciudadano 

	void Start () 
	{
		// variable entera inicializada en cero que es el switch de los casos de las primitivas
		int caractr = 0;
		// vector que contiene los colores del zombie
		_zonbi.col = new Color[] 
		{ 
			Color.cyan, Color.green, Color.magenta // colores que contiene el vector
		};  
		int rnd= Random.Range(10, 21); // ramdon de la cantidad al azar de cubos y zombie 

		for (int i = 0; i < rnd; i++)  // for que inicia en cero y me aumenta de a uno hasta la cantidad al azar que se hizo en el 
		{
			GameObject go = GameObject.CreatePrimitive (PrimitiveType.Cube);    // al gameobject lo llame go y le agrege la primitiva de cubo
			go.AddComponent<Rigidbody> ().constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ; // agregandole el rigidbody a las primitivas y congelando su rotagion en x y z
			Vector3 pos = new Vector3 (Random.Range(-10, 10), 0, Random.Range(-10, 10)); // un vector3 posicion que llame pos que coloca al azar las primitivas en la escena   
			go.transform.position = pos;  //al gameobject go le estoy dando la posicion de pos 
			// este switch crea la primitivas heroe ciudadano y zombie 
			switch (caractr)                                                           
			{
				case 0: // el switch en el caso 0 siempre me crea un solo heroe 
					go.name = "Hero"; // game object tipo heroe
					go.AddComponent<Hero> (); //agrega la clase heroe
					go.AddComponent<FPSMove>(); // agrega el script fpsmove para el movimiento del heroe
					Camera.main.gameObject.transform.localPosition = go.transform.position;  //le doy a la camara la posiscion del gameobject 
					Camera.main.transform.SetParent(go.transform); //la camara tieneel transforn del gameobject go "la camara sugue al heroe"
					go.GetComponent<Renderer>().material.color = Color.red; // le estoy dando el color rojo al gameobject go 
					go.tag = "Hero"; //al gameobject go de este caso le agrego el tag de hero
					break; // detiene el siclo en caso de cumplirse 
				case 1: // si el caso es uno me crea un ciudadano                                                               
					go.name = "Ciudadano"; // game object tipo heroe
					go.AddComponent<Ciudadano> (); // agrego la clase ciudadano
					go.tag = "Ciudadano"; // al gameobject go de este caso le agrego el tag de ciudadano
					break;// detiene el siclo en caso de cumplirse 		
				case 2:  // si el caso es dos me crea un zombie                                                      
					go.name = "Zombie"; //game object tipo zombie
					go.AddComponent<Zombie> (); // agrego la clase zombie 
					go.tag = "Zombie"; // al gameobject go de este caso le agrego el tag de zombie
					int col = Random.Range (0, 3); // variable col de colores con un random de 0 a 3 para el color de los zombies 
					go.GetComponent<Renderer> ().material.color = _zonbi.col [col]; // al game object le doy el color que se le dio al azar a col 
					break; // detiene el siclo en caso de cumplirse 
				default:    // por defaul el switch me creara un ciudadano                              
				go.name = "Ciudadano";// game object tipo heroe
				go.AddComponent<Ciudadano>();// agrego la clase ciudadano
				break; // detiene el siclo en caso de cumplirse 
			}
			caractr = Random.Range(1, 3);  // ramdom del switch caracter que coje un rango al azar y crea primitivas en tipo zombie 
		}
	}
}
