using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Energy_Bar : MonoBehaviour {

	private Slider my_slider;

	private Image fill_image;

	public bool fade = true;

	// Use this for initialization
	void Start () 
	{
		
		my_slider = GetComponent<Slider> ();

		fill_image = GetComponentInChildren<Image> ();
	
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		if (my_slider.value < 100)
		{
			fade = false;
			if (my_slider.value <= 15f)
			{
				my_slider.value = my_slider.value + Time.deltaTime * 3f;
			} else if (my_slider.value <= 30f)
			{
				my_slider.value = my_slider.value + Time.deltaTime * 13f;
			} else if (my_slider.value <= 60f)
			{
				my_slider.value = my_slider.value + Time.deltaTime * 10f;
			} else
			{
				my_slider.value = my_slider.value + Time.deltaTime * 7f;
			}
		} else
		{
			fade = true;
		}

		Fade ();
	}

	void Fade()
	{
		if (fade == true)
		{
			Debug.Log ("hello");
			fill_image.color = new Color (fill_image.color.r, fill_image.color.g, fill_image.color.b, 0);
		} else
		{
			fill_image.color = new Color (fill_image.color.r, fill_image.color.g, fill_image.color.b, 1);
		}
	}

}
