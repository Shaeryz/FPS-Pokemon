using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

    public PlayerShoot owner =  null;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnCollisionEnter(Collision col)
    {
        PlayerShoot ps = col.gameObject.GetComponentInChildren<PlayerShoot>();
        if(ps)
        {
            Debug.Log("BOUUUUUUUUMMMM");
            ps.removeLife(10);
            if (ps.getLife() <= 0)
                owner.addFrag(1);
        }
        GameObject.Destroy(this.gameObject);
    }
}
