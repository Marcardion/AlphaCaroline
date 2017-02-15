using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Player_Movement : MonoBehaviour {

	public enum Player_State {Idle, Walking, Sprinting, Firing, Uncontrollable};

	public Player_State my_state;

	public float speed;
	public float sprint_speed;

	public enum Direction{Left, Right, Up, Down};

	public Direction player_direction;

	public bool direction_change = true;

	private float moveHorizontal;
	private float moveVertical;
	public float modifier;
	private Vector3 movement;


	public bool accept_control = true;
	public bool being_moved = false;

	private Rigidbody my_rigidbody;
	private Animator my_body_anim;

	public Slider energy_bar;

	// Use this for initialization
	void Start () {

		my_rigidbody = GetComponent<Rigidbody> ();

		my_body_anim = GetComponentInChildren<Animator> ();

		energy_bar = GameObject.Find ("Energy_Bar").GetComponent<Slider>();

		sprint_speed = speed * 2f;
	
	}

	// Update is called once per frame
	void Update () {

		if (accept_control == true)
		{
			moveHorizontal = Input.GetAxis ("Horizontal");
			moveVertical = Input.GetAxis ("Vertical");
			modifier = Input.GetAxis ("Modifier");

			if (moveHorizontal != 0 || moveVertical != 0)
			{
				if (modifier != 0 && energy_bar.value >= 5f)
				{
					if (being_moved == false)
					{
						my_rigidbody.velocity = new Vector3 (moveHorizontal * sprint_speed, my_rigidbody.velocity.y, moveVertical * sprint_speed);
					}
					energy_bar.value = energy_bar.value - Time.deltaTime * 20f;
					my_state = Player_State.Sprinting;
				} else
				{
					if (being_moved == false)
					{
						my_rigidbody.velocity = new Vector3 (moveHorizontal * speed, my_rigidbody.velocity.y, moveVertical * speed);	
					}
					my_state = Player_State.Walking;
				}
			} else
			{
				my_state = Player_State.Idle;
			}
		} else
		{
			my_state = Player_State.Uncontrollable;
		}

		if (direction_change == true && (moveHorizontal != 0 || moveVertical != 0))
		{
			DirectionChange ();
		}

		if ((player_direction == Direction.Left || player_direction == Direction.Right) && moveHorizontal == 0)
		{
			direction_change = true;
		}


		if ((player_direction == Direction.Up || player_direction == Direction.Down) && moveVertical == 0)
		{
			direction_change = true;
		}

		switch (player_direction)
		{
			case Direction.Up:
				my_body_anim.SetInteger ("Direction", 0);
				break;
			case Direction.Right:
				my_body_anim.SetInteger ("Direction", 1);
				break;
			case Direction.Down:
				my_body_anim.SetInteger ("Direction", 2);
				break;
			case Direction.Left:
				my_body_anim.SetInteger ("Direction", 3);
				break;
		}

	}

	void DirectionChange ()
	{
		if (moveHorizontal != 0)
		{
			if (moveHorizontal > 0)
			{
				player_direction = Direction.Right;	
			} 
			else
			{
				player_direction = Direction.Left;
			}
		} else if (moveVertical != 0)
		{
			if (moveVertical > 0)
			{
				player_direction = Direction.Up;	
			} 
			else
			{
				player_direction = Direction.Down;
			}
		}

		direction_change = false;


	}
		
}
