using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Creates prompt for unity's variables
[Header("The thing to fly towards")]
[SerializeField]
private GameObject target;
//Direction of Bullet's travel
private Vector2 trajectory;
public class ReimuDodgeBullet : MonoBehaviour {

	// Use this for initialization
	void Start () {
        //Finds the trajectory towards Reimu
        trajectory = (target.transform.position - transform.position).normalized;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
