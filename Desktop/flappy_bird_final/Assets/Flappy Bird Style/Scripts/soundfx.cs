using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundfx : MonoBehaviour
{
	public AudioSource fly;
	public AudioSource wall;
	public AudioSource ground;
	public AudioSource end;


	public void flyplay() {
		fly.Play();
	}

	public void wallplay()
	{
		wall.Play();
	}
	public void groundplay()
	{
		ground.Play();
	}
	public void endplay()
	{
		end.Play();
	}
    void OnTriggerEnter()
    {
		wall.Play();
	}


}
