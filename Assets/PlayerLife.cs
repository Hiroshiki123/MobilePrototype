using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    [SerializeField] int _life = 3;
    public int life => _life;
    public int points { get; private set; }
    public UnityEvent<int> OnLifeChange { get; set; }

	public UnityEvent<int> OnPointsChange { get; set; }
	private void Awake()
	{
		OnLifeChange = new UnityEvent<int>();
        OnPointsChange = new UnityEvent<int>();
	}
	public void LoseLife(int life) 
    {
        this._life -= life;
        OnLifeChange.Invoke(this._life);
        if (this._life <= 0) 
        {
            SceneManager.LoadScene("Menu");
        }
    }
    public void AddPoints(int points) 
    {
        this.points += points;
        OnPointsChange.Invoke(this.points);
    }

}
