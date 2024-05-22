using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
	[SerializeField] TMP_Text life;
	[SerializeField] TMP_Text points;
    [SerializeField] PlayerLife player;
	void Start()
    {

        player.OnLifeChange.AddListener(UpdateLife);
		player.OnPointsChange.AddListener(UpdatePoints);

        life.text = $"Life: {player.life}";
		points.text = $"Points: {player.points}";
	
	}


	void UpdateLife(int life)
	{
		this.life.text = $"Life: {life}";
	}
	void UpdatePoints(int points)
	{
		this.points.text = $"Points: {points}";
	}
}
