using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boom : MonoBehaviour {
	private ParticleSystem boom;

	void OnEnable()
	{
		boom = GetComponent<ParticleSystem>();
		boom.Play();
	}

	void Update()
	{
		if(!boom.isPlaying)
		{
			GetComponentInParent<ObjPool>().recovery(gameObject);
		}
	}


}
