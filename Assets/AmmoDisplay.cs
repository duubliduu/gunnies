using UnityEngine;
using UnityEngine.UI;

public class AmmoDisplay : MonoBehaviour
{
    private int ammo = 100;
    public Text ammoText;

    void Update()
    {
        ammoText.text = "Ammo: " + ammo;
    }
}
