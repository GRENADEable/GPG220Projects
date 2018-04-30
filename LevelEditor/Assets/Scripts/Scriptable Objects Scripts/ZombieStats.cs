using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Zombie Stats", menuName = "Zombie Stats")]
public class ZombieStats : ScriptableObject 
{
	public string zomName;
	public float chaseDistance;
	public float attackDistance;
	public GameObject monster;
	public int maxSpeed;
	public int maxForce;
}
