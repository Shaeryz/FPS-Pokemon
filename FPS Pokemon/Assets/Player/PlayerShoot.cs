using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.UI;

[RequireComponent(typeof(MultiFPController))]
public class PlayerShoot : MonoBehaviour {

    public Transform Bullet;
    public Transform CrossHair;
    public Transform TextInfo;

    private int NumController;
    private string shootBtn = "Fire1";
    private string jmpBtn;
    private string hAxis;
    private string vAxis;
    private string hAxisView;
    private string vAxisView;
    private Camera camera;
    private Canvas canvas;
    private float life = 100;
    private int frag = 0;
    private Text m_textLife;

    public float getLife() { return life; }
    public void removeLife(float life) { this.life -= life; updateText(); }
    public void resetLife() { this.life = 100; updateText(); }
    public void addFrag(int frag) { this.frag += frag; updateText(); }
    public void updateText() { m_textLife.text = "Life : " + life + " / Frags : " + frag; }

    //To be called when instancing player
    public void initialise(int numController, int nbPlayers)
    {
        NumController = numController;
        shootBtn = "FireJst" + (numController + 1);
        jmpBtn = "JmpJst" + (numController + 1);
        hAxis = "hAxisJst" + (numController + 1);
        vAxis = "vAxisJst" + (numController + 1);
        hAxisView = "hAxisViewJst" + (numController + 1);
        vAxisView = "vAxisViewJst" + (numController + 1);
        GetComponent<MultiFPController>().setInputs(hAxis, vAxis, hAxisView, vAxisView, jmpBtn);
        camera = GetComponentInChildren<Camera>();
        canvas = GameObject.FindObjectOfType<Canvas>();
        
        float nbX = 1;
        float nbY = 1;
        if (nbPlayers > 1)
        {
            nbX = 2;
        }
        if (nbPlayers > 2)
        {
            nbX = 2;
            nbY = 2;
        }
        camera.rect = new Rect(numController%2 * 1 / nbX, (numController > 1 ? 1:0) * 1 / nbY, 1/ nbX, 1/ nbY);

        Vector3 centerVp = camera.ViewportToScreenPoint(new Vector3(0.5f, 0.5f,0));
        centerVp -= new Vector3(Screen.width / 2, Screen.height / 2, 0);
        Vector3 tlVp = camera.ViewportToScreenPoint(new Vector3(0, 1, 0));
        tlVp -= new Vector3(Screen.width / 2, Screen.height / 2, 0);

        Transform cross = GameObject.Instantiate(CrossHair) as Transform;
        cross.parent = canvas.transform;
        cross.localPosition = centerVp; 
        Transform textLife = GameObject.Instantiate(TextInfo) as Transform;
        textLife.parent = canvas.transform;
        textLife.localPosition = tlVp;
        m_textLife = textLife.GetComponent<Text>();

        Debug.Log("Player " + numController + " initialised ");
    }

    // Use this for initialization
    void Start () {
	        
	}
	
	// Update is called once per frame
	void Update () {
	    if(CrossPlatformInputManager.GetButtonDown(shootBtn))
        {
            shoot();
        }
	}

    private void shoot()
    {
        Transform bullet = GameObject.Instantiate(Bullet, transform.position + camera.transform.forward * 2, camera.transform.rotation) as Transform;
        bullet.GetComponent<Rigidbody>().AddForce(camera.transform.forward * 2000);
        bullet.GetComponent<Bullet>().owner = this;
    }
}
