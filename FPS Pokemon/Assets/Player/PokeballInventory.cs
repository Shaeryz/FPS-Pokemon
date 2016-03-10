using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PokeballInventory : MonoBehaviour {

	public List <pokeball> Liste; // on crée la liste de pokeball (vide)

	public int nbPokemon()
	{
		return Liste.Count;
	}

	public void dropPokemon()
	{
		foreach (pokeball P in Liste) 
		{
			Destroy (P.gameObject);
		}

		Liste.Clear ();
	}

}
