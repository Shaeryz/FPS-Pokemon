using UnityEngine;
using System.Collections;

public class pickup : MonoBehaviour {

	public Transform pokeball;
	public pokeball.Pokemon pokemon; // on déclare une variable pokemon qui est du même type que dans le script pokeball, donc une énum


	// Use this for initialization
	void Start () {
		
	}

	public void OnTriggerEnter (Collider other) {
		Debug.Log ("Trigger");

		if (other.gameObject.CompareTag ("Player"))
		{

			PokeballInventory inventory =  other.gameObject.GetComponent<PokeballInventory> (); // on appelle le composant "inventaire" du player 


			Transform pb = GameObject.Instantiate (pokeball, new Vector3 (other.gameObject.transform.position.x, other.gameObject.transform.position.y + 2, other.gameObject.transform.position.z), Quaternion.identity) as Transform;
			pb.parent = other.transform;

			pb.GetComponent<pokeball> ().pokemonPorte = pokemon; // on attache un type de pokemon à la pokeball que l'on vient de créer

			inventory.Liste.Add (pb.GetComponent<pokeball>()); // on ajoute la pokeball qui contient désormais la valeur du pokemon à l'inventaire du player
			Destroy (gameObject);
		}
	}


	// Update is called once per frame
	void Update () {
	

	}
}
