using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour {

    public Transform playerPrefab;
    public int nbPlayers;
    public bool initInputs = true;

    private Transform[] players;
    private GameObject[] playersStarts;

    // Use this for initialization
    void Start () {
        //Recup des player starts
        playersStarts = GameObject.FindGameObjectsWithTag("PlayerStart");
        players = new Transform[nbPlayers];
        for (int i = 0; i < nbPlayers; i++)
        {
            players[i] = GameObject.Instantiate(playerPrefab) as Transform;
            if(initInputs)
                players[i].GetComponent<PlayerShoot>().initialise(i,nbPlayers);
            players[i].transform.position = playersStarts[i % playersStarts.Length].transform.position;
            players[i].transform.rotation = playersStarts[i % playersStarts.Length].transform.rotation;
        }

        
	}

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < nbPlayers; i++)
        {
            if (players[i].GetComponent<PlayerShoot>().getLife() <= 0)
            {
                
                PlayerShoot ps = players[i].GetComponent<PlayerShoot>();
				ps.dropPokemon();
				ps.resetLife();

                players[i].transform.position = playersStarts[Random.Range(0, playersStarts.Length)].transform.position;
            }

        }
    }


}
