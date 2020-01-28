using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureHunter : MonoBehaviour
{
    public float totScore;
    OVRCameraRig oVRCameraRig;
    OVRManager oVRManager;
    OVRHeadsetEmulator oVRHeadsetEmulator;
    Camera viewpointCamera;

    public bool test;
    //PostProcessLayer postProcessLayer;
    //LocomotionHandler locomotionHandler;
    // Start is called before the first frame update
    
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("1")){
            if(!this.gameObject.GetComponent<TreasureHunterInventory>().inventoryItems.Contains(GameObject.Find("Sphere").GetComponent<Collectible>())){
                this.gameObject.GetComponent<TreasureHunterInventory>().inventoryItems.Add(GameObject.Find("Sphere").GetComponent<Collectible>());
                Debug.Log("press1") ;           
            }
           
           totScore = calculateScore();
        }
        if(Input.GetKeyDown(KeyCode.Alpha2)){
           if(!this.gameObject.GetComponent<TreasureHunterInventory>().inventoryItems.Contains(GameObject.Find("Sphere (1)").GetComponent<Collectible>())){
                this.gameObject.GetComponent<TreasureHunterInventory>().inventoryItems.Add(GameObject.Find("Sphere (1)").GetComponent<Collectible>());
                Debug.Log("press2") ;   
            }
            totScore = calculateScore();
        }
        if(Input.GetKeyDown(KeyCode.Alpha3)){
           if(!this.gameObject.GetComponent<TreasureHunterInventory>().inventoryItems.Contains(GameObject.Find("Sphere (2)").GetComponent<Collectible>())){
                this.gameObject.GetComponent<TreasureHunterInventory>().inventoryItems.Add(GameObject.Find("Sphere (2)").GetComponent<Collectible>());
                Debug.Log("press3") ;   
            }
            totScore = calculateScore();
        }
        if(Input.GetKeyDown(KeyCode.Alpha4)){
           totScore = calculateScore();
           GameObject.Find("Score").GetComponent<TextMesh>().text = totScore + "Yiwei Wang" + "Yichen Wu"+ this.gameObject.GetComponent<TreasureHunterInventory>().inventoryItems.Count;
           Debug.Log("press4") ;   
        }
    }

    float calculateScore(){
        float score = 0;
        List<Collectible> collectibleTreasures=this.gameObject.GetComponent<TreasureHunterInventory>().inventoryItems;
        foreach (Collectible treasure in collectibleTreasures){
            score += treasure.value;
        }
        if(collectibleTreasures.Count == 3){
               GameObject.Find("Win").GetComponent<TextMesh>().text = "You win";
           }
        return score;
    }
}
