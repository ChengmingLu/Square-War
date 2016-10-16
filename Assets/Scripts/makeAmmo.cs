using UnityEngine;
using System.Collections;

public class makeAmmo : MonoBehaviour {
    public int ammoCost;
    // Use this for initialization
    public void makeNewAmmo() {
        GameObject baseObject = gameObject.transform.parent.gameObject;
        if (baseObject.GetComponent<Base>().money >= ammoCost && baseObject.GetComponentInChildren<Base>().totalAmmo < baseObject.GetComponent<Base>().maxAmmo) {
            baseObject.GetComponent<Base>().money -= ammoCost;
            baseObject.GetComponent<Base>().totalAmmo += 1;
            baseObject.GetComponentInChildren<AmmoDisplay>().updateDisplay();
            baseObject.GetComponentInChildren<MoneyDisplay>().updateDisplay();
        }
    }
}
