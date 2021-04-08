using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Indicator : MonoBehaviour
{

    public LayerMask whatIsPlayer;
    public Transform indicatorPosition1;
    public Transform indicatorPosition2;
    public float indicatorRadius;
    public bool isPlayerInRange1;
    public bool isPlayerInRange2;
    public GameObject itemDetails;
    public TextMeshProUGUI itemText;
    public int itemCost;
    public WeaponSwitching weaponSwitching;
    public bool isWeapon;
    public bool isStatus;
    public int weaponIdentity;
    public LevelManager levelManager;
    public PlayerController playerController;
    public GameObject purchaseParticle;

    // Start is called before the first frame update
    void Start()
    {
        //itemText = GetComponent<TextMeshPro>();
        itemText.text = itemCost.ToString();
        levelManager = FindObjectOfType<LevelManager>();
        playerController = FindObjectOfType<PlayerController>();

    }

    // Update is called once per frame
    void Update()
    {
        isPlayerInRange1 = Physics2D.OverlapCircle(indicatorPosition1.position, indicatorRadius, whatIsPlayer);
        isPlayerInRange2 = Physics2D.OverlapCircle(indicatorPosition2.position, indicatorRadius, whatIsPlayer);

        if(isPlayerInRange1 || isPlayerInRange2){

            itemDetails.SetActive(true);

            if(Input.GetKeyDown(KeyCode.E)) {
                //levelManager.purchaseItem(isWeapon, isStatus, weaponIdentity);
                if(isWeapon){
                    levelManager.purchaseWeapon(weaponIdentity, purchaseParticle, itemCost);
                }
                else if(isStatus){
                    levelManager.purchaseStatus(purchaseParticle, itemCost);
                }
            }
        }
        else{
            itemDetails.SetActive(false);
        }
    }

    
}
