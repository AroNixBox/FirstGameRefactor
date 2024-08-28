using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponControl : MonoBehaviour
{
    private int whichWeaponSelected;
    private GameObject weapon;
    // Start is called before the first frame update
    void Start()
    {
        whichWeaponSelected = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            SwitchWeapon();
        }
    }
    private void SwitchWeapon()
    {
        switch (whichWeaponSelected)
        {
            case 1: 
                if (weapon != null)
                {
                    Destroy(weapon.gameObject);
                }
                weapon = Instantiate(Resources.Load("Prefabs/Pistol_"), transform.position, transform.rotation) as GameObject;
                weapon.transform.SetParent(gameObject.transform);
                //position of the weapon regarding to starting position of player. CHANGE HERE
                weapon.transform.localPosition = new Vector3(0.5f, 2.65f, 0f);
                weapon.GetComponent<Renderer>().sortingOrder = gameObject.GetComponent<Renderer>().sortingOrder + 1;
                whichWeaponSelected += 1;
                break;

            case 2:
                if (weapon != null)
                {
                    Destroy(weapon.gameObject);
                }
                weapon = Instantiate(Resources.Load("Prefabs/Shotgun_"), transform.position, transform.rotation) as GameObject;
                weapon.transform.SetParent(gameObject.transform);
                //position of the weapon regarding to starting position of player. CHANGE HERE
                weapon.transform.localPosition = new Vector3(0.35f, 1.7f, 0f);
                weapon.GetComponent<Renderer>().sortingOrder = gameObject.GetComponent<Renderer>().sortingOrder + 1;
                whichWeaponSelected += 1;
                break;

        }

        if(whichWeaponSelected > 2)
        {
            whichWeaponSelected = 1;
        }
    }
}
