using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AmmoDisplay : MonoBehaviour {
    private GameObject grandpaBase;
    private Text textDis;

	void Start () {
        grandpaBase = gameObject.transform.parent.gameObject.transform.parent.gameObject;
        textDis = gameObject.GetComponent<Text>();
        updateDisplay();
	}
	
    public void updateDisplay() {
        textDis.text = grandpaBase.GetComponent<Base>().totalAmmo.ToString();
    }

}   
