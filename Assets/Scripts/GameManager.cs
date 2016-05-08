using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public PlayerController player;
    public Camera mapCamera;

	private void Start () 
    {
        BeginGame();
	}
	
	void Update () 
    {
        if ( Input.GetKeyDown( KeyCode.R ) )
        {
            RestartGame();
        }
	}

    private void BeginGame()
    {
        mapCamera.rect = new Rect(0f, 0f, 0.5f, 0.5f);
        mapCamera.clearFlags = CameraClearFlags.Skybox;
        mapCamera.clearFlags = CameraClearFlags.Depth;

        PlayerController playerInstance = Instantiate(player) as PlayerController;
        playerInstance.transform.parent = transform;
        playerInstance.transform.localPosition =
            new Vector3(
                50f,
                5f,
                50f
            );
    }

    private void RestartGame()
    {
        StopAllCoroutines();
        BeginGame();
    }
}
