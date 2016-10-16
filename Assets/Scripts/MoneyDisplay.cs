using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MoneyDisplay : MonoBehaviour {
    private GameObject grandpaBase;
    private Text textDis;
	// Use this for initialization
	void Start () {
        grandpaBase = gameObject.transform.parent.gameObject.transform.parent.gameObject;
        textDis = gameObject.GetComponent<Text>();
        updateDisplay();
        //Debug.Log(grandpaBase);
	}
	
    public void updateDisplay() {
        textDis.text = grandpaBase.GetComponent<Base>().money.ToString();
    }
}
