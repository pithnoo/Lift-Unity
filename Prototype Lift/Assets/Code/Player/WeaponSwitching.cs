using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitching : MonoBehaviour
{
    public int selectedWeapon = 0;

    // Start is called before the first frame update
    void Start()
    {
        selectedWeapon = PlayerPrefs.GetInt("SelectedWeapon");
        SelectWeapon(selectedWeapon);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SelectWeapon(int selectedWeapon){
        int i = 0;
        foreach (Transform weapon in transform)
        {
            if(i == selectedWeapon){
                weapon.gameObject.SetActive(true);
            }
            else{
                weapon.gameObject.SetActive(false);
            }
            i++;
        }
    }
}
