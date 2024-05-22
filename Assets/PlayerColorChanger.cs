using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColorChanger : MonoBehaviour
{
    [SerializeField]PlayerInput playerInput;
    [SerializeField]SkinnedMeshRenderer _renderer;
    public int minSwipe;
    [SerializeField] Material[] colors;
    [SerializeField] PlayerLife _life;
    [SerializeField] Animator ani;
    public PlayerLife life => _life;
    public PlayerColor currentColor { get; private set; }
    void Start()
    {
        playerInput.OnClickEnd.AddListener(OnSwipe);
        ColorChange(PlayerColor.none);
    }

    public void OnSwipe(float delta) 
    {
        if (playerInput.click && currentColor == PlayerColor.none) 
        {
            StartCoroutine(ReturnToNone());
            if(Mathf.Abs(delta) > minSwipe) 
            {
                if (delta > 0)
                {
					ColorChange(PlayerColor.red);

				}
			    if (delta < 0)
			    {
					ColorChange(PlayerColor.blue);

				}
                return;
		    }
            ColorChange(PlayerColor.yellow);
        }
	}


    IEnumerator ReturnToNone() 
    {
        yield return new WaitForSeconds(0.5f);
        ColorChange(PlayerColor.none);
    }
    public void ColorChange(PlayerColor color) 
    {
        currentColor = color;
        switch (color) 
        {
            case PlayerColor.red: _renderer.material = colors[0];ani.SetFloat("dance", 0); break;
            case PlayerColor.blue: _renderer.material = colors[1]; ani.SetFloat("dance", 1); break;
            case PlayerColor.yellow: _renderer.material = colors[2]; ani.SetFloat("dance", 2); break;
            case PlayerColor.none: _renderer.material = colors[3]; ani.SetFloat("dance", 3); break;
        }

    }



}
public enum PlayerColor 
{
    blue = 0,
    red = 1,
    yellow = 2,
	none = 3
}
