using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitching : MonoBehaviour
{
    public int selectedWeapon = 0;

    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.HasKey("SelectedWeapon")){
            selectedWeapon = PlayerPrefs.GetInt("SelectedWeapon");
        }
        else{
            return;
        }
        SelectWeapon(selectedWeapon);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SelectWeapon(int chosenWeapon){
        int i = 0;
        foreach (Transform weapon in transform)
        {
            if(i == chosenWeapon){
                weapon.gameObject.SetActive(true);
            }
            else{
                weapon.gameObject.SetActive(false);
            }
            i++;
        }
        selectedWeapon = chosenWeapon;
    }
}
