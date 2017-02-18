using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaOfReachPosition : MonoBehaviour {

	Player_Movement player_dir;

	// Use this for initialization
	void Start () {

		player_dir = GetComponentInParent<Player_Movement> ();
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		SetPosition ();
		
	}

	void SetPosition()
	{
		switch (player_dir.player_direction) 
		{
		case Direction.Left:
			transform.localPosition = new Vector3 (-1, 0, 0);
			break;
		case Direction.Right:
			transform.localPosition = new Vector3 (1, 0, 0);
			break;
		case Direction.Up:
			transform.localPosition = new Vector3 (0, 0, 1);
			break;
		case Direction.Down:
			transform.localPosition = new Vector3 (0, 0, -1);
			break;
		}
	}
}
