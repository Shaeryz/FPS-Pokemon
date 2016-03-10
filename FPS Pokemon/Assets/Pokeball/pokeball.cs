using UnityEngine;
using System.Collections;
public class pokeball : MonoBehaviour {

	public enum Pokemon{
		pokeNull,
		pokeA,
		pokeB,
		pokeC,
	};
	public GameObject pokeA;
	public GameObject pokeB;
	public GameObject pokeC;

	public Pokemon pokemonPorte = Pokemon.pokeNull;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void OnDestroy () {

		switch (pokemonPorte) {
			case Pokemon.pokeA:
			{
				InstantiatePokemon (pokeA);
				break;
			}
			case Pokemon.pokeB:
			{
				InstantiatePokemon (pokeB);
				break;
			}
			case Pokemon.pokeC:
			{
				InstantiatePokemon (pokeC);
				break;
			}
		}
	}

	void InstantiatePokemon (GameObject poke)
	{
		Vector3 newPos = new Vector3 (transform.position.x + Random.Range(-1,1), transform.position.y - 2, transform.position.z + Random.Range(-1,1));
		Instantiate (poke,newPos,Quaternion.identity);
	}
}
