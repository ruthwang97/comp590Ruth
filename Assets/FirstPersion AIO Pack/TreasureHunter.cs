using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

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
        if (Input.GetKeyDown("1"))
        {   
            Debug.Log("pressed 1");
            RaycastHit hit;
            Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
            if (Physics.Raycast(ray, out hit))
            {
                if(hit.collider.gameObject.name == "Sphere"){
                    GameObject prefab = (GameObject)AssetDatabase.LoadAssetAtPath("Assets/ball.prefab", typeof(GameObject));
                    this.gameObject.GetComponent<TreasureHunterInventory>().inventoryItems.Add(prefab.GetComponent<Collectible>());
                }
                if(hit.collider.gameObject.name == "Cube"){
                    GameObject prefab = (GameObject)AssetDatabase.LoadAssetAtPath("Assets/cube.prefab", typeof(GameObject));
                    this.gameObject.GetComponent<TreasureHunterInventory>().inventoryItems.Add(prefab.GetComponent<Collectible>());
                }
                if(hit.collider.gameObject.name == "Cylinder"){
                    GameObject prefab = (GameObject)AssetDatabase.LoadAssetAtPath("Assets/cyl.prefab", typeof(GameObject));
                    this.gameObject.GetComponent<TreasureHunterInventory>().inventoryItems.Add(prefab.GetComponent<Collectible>());
                }
                Destroy(hit.collider.gameObject);
            }
            
            totScore = calculateScore();
            
            GameObject.Find("score").GetComponent<TextMesh>().text = "count: " + this.gameObject.GetComponent<TreasureHunterInventory>().inventoryItems.Count + "score: " + totScore + "Yiwei Wang";
        }

        
        float calculateScore()
        {
            float score = 0;
            List<Collectible> collectibleTreasures = this.gameObject.GetComponent<TreasureHunterInventory>().inventoryItems;
            foreach (Collectible treasure in collectibleTreasures)
            {
                score += treasure.value;
            }
            return score;
        }
    }


}
