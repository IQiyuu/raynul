using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject playerPrefab;
    [SerializeField] GameObject groundPrefab;
    private GameObject playerObject;

    // Start is called before the first frame update
    void Start() {
        playerObject = Instantiate(playerPrefab);
        playerObject.name = "Player";
        Instantiate(groundPrefab);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
