using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
	public Zonbiedates _zonbi; // instancia de la estructura zombie 

	int rnd; //entero que llame rnd para el random del caso

	Estado estado; // enum estado

	//int idle = 0; //idle es el estado quieto del zombie 
	int moving; //idle es el estado en movimiento del zombie 

	// esta es una coorutina que cada 5 segundos me realizar un random en el estado y la direccion del zombie
	IEnumerator MovimientoZombie ()
	{
		yield return new WaitForSeconds(5); // estoy diciendo que me espere 5 segundos para llamar el ramdom de los estados
		estado = (Estado) Random.Range(0,2); // llamando los estados 
		rnd = Random.Range(0, 4);// realizado el ramdom de los estados se llama este que es el ramdom de los movimientos 
		StartCoroutine (MovimientoZombie ()); // iniciando la corrutina Movimiento zombie
	}
	void Start()
	{
		_zonbi.part = (body)Random.Range (0, 5); // ramdon de de las partes del cuerpo
		StartCoroutine (MovimientoZombie ());// llamando e iniciando la corrutina Movimiento zombie
	}

     void Update () 
	{
		//switch que me controla los estados idle y moving del zombie 
		switch (estado) 
		{
		case Estado.idle: // zombie quieto
			break;
		case Estado.moving: // zombie en movimiento
			 Moving (); //llamando el metodo del movimiento
			break;
		}
	}
	//metodo que contiene un switch con los movimientos del zombie 
	public void Moving()
	{
		_zonbi.Speed = 0.1f; // defini la velocidad del zombie a 0.1float
		switch (rnd)
		{
		case 0:
			transform.position += transform.forward * _zonbi.Speed; //avanzar hacia adelante 
			break;
		case 1:
			transform.position -= transform.forward * _zonbi.Speed;	//avanzar hacia atras
			break;
		case 2:
			transform.position += transform.right * _zonbi.Speed; // avanzar hacia la izquierda
			break;
		case 3:
			transform.position -= transform.right * _zonbi.Speed; // avanzar hacia la derecha
			break;
		}
	}
}
// estructura que me contiene los elementos del color y de las partes de cuerpo del zombie
public struct Zonbiedates                                                     
{
	public  Color[] col; // vector de los colores del zombie que llame coler 
	public body part; // enum body de las partes del cuerpo que llame part 
	public float Speed; // velocidad flotante que se le da al zombie 
	
}
//enum que me tiene las partes del cuerpo del zombie
public enum body                                           
{
	Cabesa, piernas, brazos, torso, Cerebro 
}
//enum que tiene idle que es cuando el zombie esta quieto y moving que esta en movimiento
public enum Estado
{
	idle,moving
}