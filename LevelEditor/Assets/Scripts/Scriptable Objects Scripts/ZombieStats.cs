using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Zombie Stats", menuName = "Zombie Stats")]
public class ZombieStats : ScriptableObject 
{
	public string zomName;
	public float lookRange;
	public GameObject player;
	//public GameObject zombie;
	public GameObject monster;
}
