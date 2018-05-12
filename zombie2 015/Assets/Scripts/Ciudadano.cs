using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ciudadano : MonoBehaviour
{
	public datosciudadano _citi; // instancia de la estructura de los ciudadanos 

	void Start () 
	{
		_citi.name = (nomciu)Random.Range(1, 20); //random para los nombres de los ciudadanos 
		_citi.age = Random.Range(15, 101);// ramdom para las edades de los cuudadanos 
	}
}
// enum que me contiene los nombres de los ciudadanos 
public enum nomciu                                           
{
	dan, will, mia, hernan, jose, pipe, leila, altaf, ismael, bills,
	mike, reslo, shen, barbatos, bruslas, yuri, boris, doris, juan, jiren
}
//estuctura que me contiene un entero de edad y el enum para los nombres y edad de los ciudadanos  
public struct datosciudadano                                              
{
	public int age; // edad del ciudadano
	public nomciu name; // enum nombre del ciudadano que llame name
}