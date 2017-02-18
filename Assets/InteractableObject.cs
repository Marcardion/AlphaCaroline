using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour {

	public bool is_active = false; //Se o objeto está no alcance do jogador
	public bool is_enabled = true; //Se o objeto está apto para fazer uma interacão

	public GameObject highlight;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (is_active && is_enabled) 
		{
			if (Input.GetButtonDown("Fire1")) 
			{
				Interact ();
			}
		}
		
	}

	void OnTriggerStay (Collider col)
	{
		if (is_enabled) 
		{
			if (col.CompareTag ("PlayerReach")) {
				//Aqui ativar o highligh de item interativo em alcance
				ActivateMe();
			}
		}
	}

	void OnTriggerExit (Collider col)
	{
		if (is_enabled) 
		{
			if (col.CompareTag ("PlayerReach")) {
				//Aqui desativar o highligh de item interativo em alcance
				DeactivateMe();
			}
		}
	}

	void ActivateMe()
	{
		if (!highlight.activeInHierarchy) {
			highlight.SetActive (true);
		}
		is_active = true;
	}

	void DeactivateMe()
	{
		if (highlight.activeInHierarchy) {
			highlight.SetActive (false);
		}
		is_active = false;
	}

	public virtual void Interact()
	{
		Debug.Log ("Hello my friend");
		Debug.Log ("Press shift to sprint");
		Debug.Log ("Bye!");
		is_enabled = false;

		DeactivateMe ();
	}
}
