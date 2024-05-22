using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    [SerializeField]PlayerColor color;
	[SerializeField]MeshRenderer _renderer;
	[SerializeField]Material[] colors;
	[SerializeField]Rigidbody rg;
	[SerializeField]int velocity;

	private void Start()
	{
		rg.velocity = new Vector3(-velocity , 0, 0);
	}
	public void ColorChange(PlayerColor color)
	{
		this.color = color;
		switch (color)
		{
			case PlayerColor.red: _renderer.material = colors[0]; break;
			case PlayerColor.blue: _renderer.material = colors[1]; break;
			case PlayerColor.yellow: _renderer.material = colors[2]; break;
			case PlayerColor.none: _renderer.material = colors[3]; break;
		}
	}
	private void OnTriggerEnter(Collider other)
	{
		if (other.TryGetComponent(out PlayerColorChanger pl)) 
		{
			if (color == pl.currentColor)
			{
				pl.ColorChange(PlayerColor.none);
				pl.life.AddPoints(1);
			}
			else {
				pl.ColorChange(PlayerColor.none);
				pl.life.LoseLife(1); 
			}
			Destroy(gameObject);
		}
	}
}
