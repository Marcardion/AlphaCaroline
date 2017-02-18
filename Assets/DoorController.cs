using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : InteractableObject {

	public override void Interact ()
	{
		gameObject.SetActive (false);
	}
}
