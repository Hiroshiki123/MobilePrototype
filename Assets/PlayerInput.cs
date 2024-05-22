using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInput : MonoBehaviour
{
    Touch playerInput;
    Vector2 initialPos;
	Vector2 secondPos;
    public bool click { get; set; }
    public UnityEvent<float> OnClickEnd { get; set; }
	void Awake()
    {
        OnClickEnd = new UnityEvent<float>();
    }
    void Update()
    {
        StartClick();


        MoveClick();


        ClickEnd();
	}


    void StartClick() 
    {
        if (Input.touchCount > 0) 
        {
            playerInput = Input.GetTouch(0);
            if (playerInput.phase == TouchPhase.Began) 
            { 
                initialPos = playerInput.position;
                click = true;
				print("Start");
			}
        }
    }
    void MoveClick() 
    {
        if (playerInput.tapCount > 0) 
        {
            if (playerInput.phase == TouchPhase.Moved || playerInput.phase == TouchPhase.Stationary) 
            {
                secondPos = playerInput.position;
				print("Move");
			}
        }
    }
    void ClickEnd() 
    {
		if (playerInput.tapCount > 0)
		{
			if (playerInput.phase == TouchPhase.Ended)
			{
                OnClickEnd.Invoke(secondPos.x - initialPos.x);
                secondPos = Vector2.zero;
                initialPos = Vector2.zero;
                click = false;
            }
		}
	}

}
