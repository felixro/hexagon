using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public PlayerController player;
    public Camera mapCamera;

    public HexMapEditor hexMapEditor;

	private void Start () 
    {
        BeginGame();
	}
	
	void Update () 
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            RestartGame();
        }

        if (Input.GetKeyDown(KeyCode.M))
        {
            bool curState = mapCamera.gameObject.activeSelf;
            mapCamera.gameObject.SetActive(!curState);
        }
	}

    private void BeginGame()
    {
        mapCamera.clearFlags = CameraClearFlags.Skybox;
        mapCamera.clearFlags = CameraClearFlags.Depth;
        mapCamera.gameObject.SetActive(true);
    }

    private void RestartGame()
    {
        StopAllCoroutines();
        BeginGame();
    }
}
