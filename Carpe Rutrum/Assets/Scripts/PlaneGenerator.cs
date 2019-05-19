using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneGenerator : MonoBehaviour
{
    [Range(1, 500)]
    public int height;
    [Range(1, 50)]
    public int width;
    [Range(1, 1)]
    public int depth;

    public int initialX, initialY, initialZ = 0;

    //Initial Generation Percent is how much of the level
    //do we want to pre-generate before allowing the player to play?
    //Generating the entire level is costly so we want to chunk it out
    [Range(1, 100)]
    public int initialGenerationPercent;

    public GameObject parentHierarchyObject;

    //IMPORTANT NOTE: WHEN DEFININING OBJECT PERCENTS,
    //THE SUM TOTAL OF ALL OBJECT PERCENTAGES MUST ADD UP BUT NOT EXCEED 100
    //SETTING AN ITEM PERCENT > 100 WILL CAUSE IT NOT TO FALL WITHIN THE RANDOM RANGE
    //AND THUS IT WILL NOT SPAWN
    //public GameObject basePlaneObject;
    public GameObject[] oreFamily0;
    [Range(1, 100)]
    public int basePlaneObjectPercent;
    private int intermediateBasePlaneObjectPercent;

    public GameObject[] oreFamily1;
    [Range(1, 100)]
    public int additionalPlaneObject1Percent;
    private int intermediateAdditionalPlaneObject1Percent;

    public GameObject[] oreFamily2;
    [Range(1, 100)]
    public int additionalPlaneObject2Percent;
    private int intermediateAdditionalPlaneObject2Percent;

    public GameObject[] oreFamily3;
    [Range(1, 100)]
    public int additionalPlaneObject3Percent;
    private int intermediateAdditionalPlaneObject3Percent;

    public GameObject[] oreFamily4;
    [Range(1, 100)]
    public int additionalPlaneObject4Percent;
    private int intermediateAdditionalPlaneObject4Percent;

    public GameObject[] oreFamily5;
    [Range(1, 100)]
    public int additionalPlaneObject5Percent;
    private int intermediateAdditionalPlaneObject5Percent;

    public GameObject[] oreFamily6;
    [Range(1, 100)]
    public int additionalPlaneObject6Percent;
    private int intermediateAdditionalPlaneObject6Percent;

    public GameObject[] oreFamily7;
    [Range(1, 100)]
    public int additionalPlaneObject7Percent;
    private int intermediateAdditionalPlaneObject7Percent;

    public GameObject[] oreFamily8;
    [Range(1, 100)]
    public int additionalPlaneObject8Percent;
    private int intermediateAdditionalPlaneObject8Percent;

    public GameObject[] oreFamily9;
    [Range(1, 100)]
    public int additionalPlaneObject9Percent;
    private int intermediateAdditionalPlaneObject9Percent;

    public GameObject[] oreFamily10;
    [Range(1, 100)]
    public int additionalPlaneObject10Percent;
    private int intermediateAdditionalPlaneObject10Percent;

    public GameObject[] oreFamily11;
    [Range(1, 100)]
    public int additionalPlaneObject11Percent;
    private int intermediateAdditionalPlaneObject11Percent;

    

    public bool randomizePlaneObjectsInLevel = false;

    private int randomNum = 0;

    private int numOreZones = 10;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //check far below us to make sure we have generated the level enough
        //ToggleRenderObjectsNearMe();
    }


    void Awake()
    {

        //Resolution[] resolutions = Screen.resolutions;

        // Print the resolutions
        //foreach (var res in resolutions)
        //{
        //    Debug.Log(res.width + "x" + res.height + " : " + res.refreshRate);
        //}
        //how much of the level do we want to generate before the game starts?
        int totalBlocks = height * width * depth;
        int divisor = 100 / initialGenerationPercent;
        int initialGenNumBlocks = totalBlocks / divisor;
        int gennedBlocks = 0;
        int yValueOreZoneSize = height / numOreZones;
        int currentOreZone = 0; 

        //If we have any object percentages at 0%, set them to be higher than 101% so that they never spawn
        for (int y = height-1; y >= 0; --y)
        {
            if (y <= (height - yValueOreZoneSize))
            {
                yValueOreZoneSize = yValueOreZoneSize + yValueOreZoneSize;
                currentOreZone++;
                
            }

            for (int x = width-1; x >= 0; --x)
            {
                for (int z = depth-1; z >= 0; --z)
                {



                    if (randomizePlaneObjectsInLevel && gennedBlocks <= initialGenNumBlocks)
                    {
                        //Debug.Log("currentOreZone was " + currentOreZone);
                        generateLevel(yValueOreZoneSize, x, y, z, currentOreZone);

                        gennedBlocks++;
                    }
                    /*else if (gennedBlocks <= initialGenNumBlocks)
                    {
                        //Instantiate(oreFamily0[0], new Vector3(x + initialX, y + initialY, z + initialZ), Quaternion.identity, parentHierarchyObject.transform);
                        gennedBlocks++;
                    }*/


                }

            }
        }


        //making objects static improves performance but disables physics
        //StaticBatchingUtility.Combine(parentHierarchyObject);
    }


    void generateLevel(int yValueOreZoneSize, int x, int y, int z, int currentOreZone)
    {

        randomNum = Random.Range(0, 101);
        //we have different cases for different height levels
        //top all the way to first 100 blocks
        if(currentOreZone == 10)
        {
            //Debug.Log("Spawning ores for " + currentOreZone);
            //allow only basePlaneObject and additionalPlaneObject1 to spawn
            //set chances for everything else to zero
            intermediateBasePlaneObjectPercent = basePlaneObjectPercent;
            intermediateAdditionalPlaneObject1Percent = additionalPlaneObject1Percent * 0;
            intermediateAdditionalPlaneObject2Percent = additionalPlaneObject2Percent * 0;
            intermediateAdditionalPlaneObject3Percent = additionalPlaneObject3Percent * 0;
            intermediateAdditionalPlaneObject4Percent = additionalPlaneObject4Percent * 0;
            intermediateAdditionalPlaneObject5Percent = additionalPlaneObject5Percent * 0;
            intermediateAdditionalPlaneObject6Percent = additionalPlaneObject6Percent * 0;
            intermediateAdditionalPlaneObject7Percent = additionalPlaneObject7Percent * 0;
            intermediateAdditionalPlaneObject8Percent = additionalPlaneObject8Percent * 0;
            intermediateAdditionalPlaneObject9Percent = additionalPlaneObject9Percent * 0;
            intermediateAdditionalPlaneObject10Percent = additionalPlaneObject10Percent;
            intermediateAdditionalPlaneObject11Percent = additionalPlaneObject11Percent;
        }
        if (currentOreZone == 9)
        {
            //Debug.Log("Spawning ores for " + currentOreZone);
            //allow only basePlaneObject and additionalPlaneObject1 to spawn
            //set chances for everything else to zero
            intermediateBasePlaneObjectPercent = basePlaneObjectPercent;
            intermediateAdditionalPlaneObject1Percent = additionalPlaneObject1Percent * 0;
            intermediateAdditionalPlaneObject2Percent = additionalPlaneObject2Percent * 0;
            intermediateAdditionalPlaneObject3Percent = additionalPlaneObject3Percent * 0;
            intermediateAdditionalPlaneObject4Percent = additionalPlaneObject4Percent * 0;
            intermediateAdditionalPlaneObject5Percent = additionalPlaneObject5Percent * 0;
            intermediateAdditionalPlaneObject6Percent = additionalPlaneObject6Percent * 0;
            intermediateAdditionalPlaneObject7Percent = additionalPlaneObject7Percent * 0;
            intermediateAdditionalPlaneObject8Percent = additionalPlaneObject8Percent * 0;
            intermediateAdditionalPlaneObject9Percent = additionalPlaneObject9Percent;
            intermediateAdditionalPlaneObject10Percent = additionalPlaneObject10Percent/2;
            intermediateAdditionalPlaneObject11Percent = 0;
        }
        if (currentOreZone == 8)
        {
            //Debug.Log("Spawning ores for " + currentOreZone);
            //allow only basePlaneObject and additionalPlaneObject1 to spawn
            //set chances for everything else to zero
            intermediateBasePlaneObjectPercent = basePlaneObjectPercent;
            intermediateAdditionalPlaneObject1Percent = additionalPlaneObject1Percent * 0;
            intermediateAdditionalPlaneObject2Percent = additionalPlaneObject2Percent * 0;
            intermediateAdditionalPlaneObject3Percent = additionalPlaneObject3Percent * 0;
            intermediateAdditionalPlaneObject4Percent = additionalPlaneObject4Percent * 0;
            intermediateAdditionalPlaneObject5Percent = additionalPlaneObject5Percent * 0;
            intermediateAdditionalPlaneObject6Percent = additionalPlaneObject6Percent * 0;
            intermediateAdditionalPlaneObject7Percent = additionalPlaneObject7Percent * 0;
            intermediateAdditionalPlaneObject8Percent = additionalPlaneObject8Percent;
            intermediateAdditionalPlaneObject9Percent = additionalPlaneObject9Percent/2;
            intermediateAdditionalPlaneObject10Percent = 0;
            intermediateAdditionalPlaneObject11Percent = 0;
        }
        if (currentOreZone == 7)
        {
            //Debug.Log("Spawning ores for " + currentOreZone);
            //allow only basePlaneObject and additionalPlaneObject1 to spawn
            //set chances for everything else to zero
            intermediateBasePlaneObjectPercent = basePlaneObjectPercent;
            intermediateAdditionalPlaneObject1Percent = additionalPlaneObject1Percent * 0;
            intermediateAdditionalPlaneObject2Percent = additionalPlaneObject2Percent * 0;
            intermediateAdditionalPlaneObject3Percent = additionalPlaneObject3Percent * 0;
            intermediateAdditionalPlaneObject4Percent = additionalPlaneObject4Percent * 0;
            intermediateAdditionalPlaneObject5Percent = additionalPlaneObject5Percent * 0;
            intermediateAdditionalPlaneObject6Percent = additionalPlaneObject6Percent * 0;
            intermediateAdditionalPlaneObject7Percent = additionalPlaneObject7Percent;
            intermediateAdditionalPlaneObject8Percent = additionalPlaneObject8Percent/2;
            intermediateAdditionalPlaneObject9Percent = 0;
            intermediateAdditionalPlaneObject10Percent = 0;
            intermediateAdditionalPlaneObject11Percent = 0;
        }
        if (currentOreZone == 6)
        {
            //Debug.Log("Spawning ores for " + currentOreZone);
            //allow only basePlaneObject and additionalPlaneObject1 to spawn
            //set chances for everything else to zero
            intermediateBasePlaneObjectPercent = basePlaneObjectPercent;
            intermediateAdditionalPlaneObject1Percent = additionalPlaneObject1Percent * 0;
            intermediateAdditionalPlaneObject2Percent = additionalPlaneObject2Percent * 0;
            intermediateAdditionalPlaneObject3Percent = additionalPlaneObject3Percent * 0;
            intermediateAdditionalPlaneObject4Percent = additionalPlaneObject4Percent * 0;
            intermediateAdditionalPlaneObject5Percent = additionalPlaneObject5Percent * 0;
            intermediateAdditionalPlaneObject6Percent = additionalPlaneObject6Percent;
            intermediateAdditionalPlaneObject7Percent = additionalPlaneObject7Percent/2;
            intermediateAdditionalPlaneObject8Percent = 0;
            intermediateAdditionalPlaneObject9Percent = 0;
            intermediateAdditionalPlaneObject10Percent = 0;
            intermediateAdditionalPlaneObject11Percent = 0;
        }
        if (currentOreZone == 5)
        {
            //Debug.Log("Spawning ores for " + currentOreZone);
            //allow only basePlaneObject and additionalPlaneObject1 to spawn
            //set chances for everything else to zero
            intermediateBasePlaneObjectPercent = basePlaneObjectPercent;
            intermediateAdditionalPlaneObject1Percent = additionalPlaneObject1Percent * 0;
            intermediateAdditionalPlaneObject2Percent = additionalPlaneObject2Percent * 0;
            intermediateAdditionalPlaneObject3Percent = additionalPlaneObject3Percent * 0;
            intermediateAdditionalPlaneObject4Percent = additionalPlaneObject4Percent * 0;
            intermediateAdditionalPlaneObject5Percent = additionalPlaneObject5Percent;
            intermediateAdditionalPlaneObject6Percent = additionalPlaneObject6Percent/2;
            intermediateAdditionalPlaneObject7Percent = 0;
            intermediateAdditionalPlaneObject8Percent = 0;
            intermediateAdditionalPlaneObject9Percent = 0;
            intermediateAdditionalPlaneObject10Percent = 0;
            intermediateAdditionalPlaneObject11Percent = 0;
        }
        if (currentOreZone == 4)
        {
            //Debug.Log("Spawning ores for " + currentOreZone);
            //allow only basePlaneObject and additionalPlaneObject1 to spawn
            //set chances for everything else to zero
            intermediateBasePlaneObjectPercent = basePlaneObjectPercent;
            intermediateAdditionalPlaneObject1Percent = additionalPlaneObject1Percent * 0;
            intermediateAdditionalPlaneObject2Percent = additionalPlaneObject2Percent * 0;
            intermediateAdditionalPlaneObject3Percent = additionalPlaneObject3Percent * 0;
            intermediateAdditionalPlaneObject4Percent = additionalPlaneObject4Percent;
            intermediateAdditionalPlaneObject5Percent = additionalPlaneObject5Percent/2;
            intermediateAdditionalPlaneObject6Percent = 0;
            intermediateAdditionalPlaneObject7Percent = 0;
            intermediateAdditionalPlaneObject8Percent = 0;
            intermediateAdditionalPlaneObject9Percent = 0;
            intermediateAdditionalPlaneObject10Percent = 0;
            intermediateAdditionalPlaneObject11Percent = 0;
        }
        if (currentOreZone == 3)
        {
            //Debug.Log("Spawning ores for " + currentOreZone);
            //allow only basePlaneObject and additionalPlaneObject1 to spawn
            //set chances for everything else to zero
            intermediateBasePlaneObjectPercent = basePlaneObjectPercent;
            intermediateAdditionalPlaneObject1Percent = additionalPlaneObject1Percent * 0;
            intermediateAdditionalPlaneObject2Percent = additionalPlaneObject2Percent * 0;
            intermediateAdditionalPlaneObject3Percent = additionalPlaneObject3Percent;
            intermediateAdditionalPlaneObject4Percent = additionalPlaneObject4Percent/2;
            intermediateAdditionalPlaneObject5Percent = 0;
            intermediateAdditionalPlaneObject6Percent = 0;
            intermediateAdditionalPlaneObject7Percent = 0;
            intermediateAdditionalPlaneObject8Percent = 0;
            intermediateAdditionalPlaneObject9Percent = 0;
            intermediateAdditionalPlaneObject10Percent = 0;
            intermediateAdditionalPlaneObject11Percent = 0;
        }
        if (currentOreZone == 2)
        {
            //Debug.Log("Spawning ores for " + currentOreZone);
            //allow only basePlaneObject and additionalPlaneObject1 to spawn
            //set chances for everything else to zero
            intermediateBasePlaneObjectPercent = basePlaneObjectPercent;
            intermediateAdditionalPlaneObject1Percent = additionalPlaneObject1Percent * 0;
            intermediateAdditionalPlaneObject2Percent = additionalPlaneObject2Percent;
            intermediateAdditionalPlaneObject3Percent = additionalPlaneObject3Percent/2;
            intermediateAdditionalPlaneObject4Percent = 0;
            intermediateAdditionalPlaneObject5Percent = 0;
            intermediateAdditionalPlaneObject6Percent = 0;
            intermediateAdditionalPlaneObject7Percent = 0;
            intermediateAdditionalPlaneObject8Percent = 0;
            intermediateAdditionalPlaneObject9Percent = 0;
            intermediateAdditionalPlaneObject10Percent = 0;
            intermediateAdditionalPlaneObject11Percent = 0;
        }
        if (currentOreZone == 1)
        {
            //Debug.Log("Spawning ores for " + currentOreZone);
            //allow only basePlaneObject and additionalPlaneObject1 to spawn
            //set chances for everything else to zero
            intermediateBasePlaneObjectPercent = basePlaneObjectPercent;
            intermediateAdditionalPlaneObject1Percent = additionalPlaneObject1Percent;
            intermediateAdditionalPlaneObject2Percent = additionalPlaneObject2Percent/2;
            intermediateAdditionalPlaneObject3Percent = 0;
            intermediateAdditionalPlaneObject4Percent = 0;
            intermediateAdditionalPlaneObject5Percent = 0;
            intermediateAdditionalPlaneObject6Percent = 0;
            intermediateAdditionalPlaneObject7Percent = 0;
            intermediateAdditionalPlaneObject8Percent = 0;
            intermediateAdditionalPlaneObject9Percent = 0;
            intermediateAdditionalPlaneObject10Percent = 0;
            intermediateAdditionalPlaneObject11Percent = 0;
        }
        if (currentOreZone == 0)
        {
            //Debug.Log("Spawning ores for " + currentOreZone);
            //allow only basePlaneObject and additionalPlaneObject1 to spawn
            //set chances for everything else to zero
            intermediateBasePlaneObjectPercent = basePlaneObjectPercent;
            intermediateAdditionalPlaneObject1Percent = additionalPlaneObject1Percent/2;
            intermediateAdditionalPlaneObject2Percent = additionalPlaneObject1Percent/4;
            intermediateAdditionalPlaneObject3Percent = 0;
            intermediateAdditionalPlaneObject4Percent = 0;
            intermediateAdditionalPlaneObject5Percent = 0;
            intermediateAdditionalPlaneObject6Percent = 0;
            intermediateAdditionalPlaneObject7Percent = 0;
            intermediateAdditionalPlaneObject8Percent = 0;
            intermediateAdditionalPlaneObject9Percent = 0;
            intermediateAdditionalPlaneObject10Percent = 0;
            intermediateAdditionalPlaneObject11Percent = 0;
        }
        if (y >= height - yValueOreZoneSize)
        {
            /*
            Debug.Log("intermediateBasePlaneObjectPercent was " + intermediateBasePlaneObjectPercent);
            Debug.Log("intermediateAdditionalPlaneObject1Percent was " + intermediateAdditionalPlaneObject1Percent);
            Debug.Log("intermediateAdditionalPlaneObject2Percent was " + intermediateAdditionalPlaneObject2Percent);
            Debug.Log("intermediateAdditionalPlaneObject3Percent was " + intermediateAdditionalPlaneObject3Percent);
            Debug.Log("intermediateAdditionalPlaneObject4Percent was " + intermediateAdditionalPlaneObject4Percent);
            Debug.Log("intermediateAdditionalPlaneObject5Percent was " + intermediateAdditionalPlaneObject5Percent);
            Debug.Log("intermediateAdditionalPlaneObject6Percent was " + intermediateAdditionalPlaneObject6Percent);
            Debug.Log("intermediateAdditionalPlaneObject7Percent was " + intermediateAdditionalPlaneObject7Percent);
            Debug.Log("intermediateAdditionalPlaneObject8Percent was " + intermediateAdditionalPlaneObject8Percent);
            Debug.Log("intermediateAdditionalPlaneObject9Percent was " + intermediateAdditionalPlaneObject9Percent);
            Debug.Log("intermediateAdditionalPlaneObject10Percent was " + intermediateAdditionalPlaneObject10Percent);
            Debug.Log("intermediateAdditionalPlaneObject11Percent was " + intermediateAdditionalPlaneObject11Percent);
            */

            //Debug.Log("Calling spawnOreBlocks with random seed " + randomNum);
            spawnOreBlocks(currentOreZone, randomNum, x, y, z, intermediateBasePlaneObjectPercent, intermediateAdditionalPlaneObject1Percent, intermediateAdditionalPlaneObject2Percent, intermediateAdditionalPlaneObject3Percent, intermediateAdditionalPlaneObject4Percent, intermediateAdditionalPlaneObject5Percent, intermediateAdditionalPlaneObject6Percent, intermediateAdditionalPlaneObject7Percent, intermediateAdditionalPlaneObject8Percent, intermediateAdditionalPlaneObject9Percent, intermediateAdditionalPlaneObject10Percent, intermediateAdditionalPlaneObject11Percent);
        }


    }

    

    void spawnOreBlocks(int currentOreZone, int randomNum, int x, int y, int z, int per0, int per1, int per2, int per3, int per4, int per5, int per6, int per7, int per8, int per9, int per10, int per11)
    {
        //if any percentage is zero, set it to be above 100 so that it never actually spawns
        /*if (per0 == 0)
            per0 = -101;
        if (per1 == 0)
            per1 = -101;
        if (per2 == 0)
            per2 = -101;
        if (per3 == 0)
            per3 = -101;
        if (per4 == 0)
            per4 = -101;
        if (per5 == 0)
            per5 = -101;
        if (per6 == 0)
            per6 = -101;
        if (per7 == 0)
            per7 = -101;
        if (per8 == 0)
            per8 = -101;
        if (per9 == 0)
            per9 = -101;
        if (per10 == 0)
            per10 = -101;
        if (per11 == 0)
            per11 = -101;
        Debug.Log("per0 " + per0);
        Debug.Log("per1 " + per1);
        Debug.Log("per2 " + per2);
        Debug.Log("per3 " + per3);
        Debug.Log("per4 " + per4);
        Debug.Log("per5 " + per5);
        Debug.Log("per6 " + per6);
        Debug.Log("per7 " + per7);
        Debug.Log("per8 " + per8);
        Debug.Log("per9 " + per9);
        Debug.Log("per10 " + per10);
        Debug.Log("per11 " + per11);*/
        //check out this sweet switch that can handle a range of numbers

        randomNum = Random.Range(0, (per0 + per1 + per2 + per3 + per4 + per5 + per6 + per7 + per8 + per9 + per10 + per11));
        switch (randomNum)
        {
            case int n when (n >= 0 && n <= per0):
                if (currentOreZone == 0)
                    Instantiate(getRandomOreFromOreFamily(oreFamily0, 70, 28, 2), new Vector3(x + initialX, y + initialY, z + initialZ), Quaternion.identity, parentHierarchyObject.transform);
                else if (currentOreZone == 1)
                    Instantiate(getRandomOreFromOreFamily(oreFamily0, 70, 22, 8), new Vector3(x + initialX, y + initialY, z + initialZ), Quaternion.identity, parentHierarchyObject.transform);
                else
                    Instantiate(getRandomOreFromOreFamily(oreFamily0), new Vector3(x + initialX, y + initialY, z + initialZ), Quaternion.identity, parentHierarchyObject.transform);
                break;
            case int n when (n >= per0 && n <= per0 + per1):
                Instantiate(getRandomOreFromOreFamily(oreFamily1), new Vector3(x + initialX, y + initialY, z + initialZ), Quaternion.identity, parentHierarchyObject.transform);
                break;
            case int n when (n >= per0 + per1 && n <= per0 + per1 + per2):
                Instantiate(getRandomOreFromOreFamily(oreFamily2), new Vector3(x + initialX, y + initialY, z + initialZ), Quaternion.identity, parentHierarchyObject.transform);
                break;
            case int n when (n >= per0 + per1 + per2 && n <= per0 + per1 + per2 +per3):
                Instantiate(getRandomOreFromOreFamily(oreFamily3), new Vector3(x + initialX, y + initialY, z + initialZ), Quaternion.identity, parentHierarchyObject.transform);
                break;
            case int n when (n >= per0 + per1 + per2 + per3 && n <= per0 + per1 + per2 + per3 + per4):
                Instantiate(getRandomOreFromOreFamily(oreFamily4), new Vector3(x + initialX, y + initialY, z + initialZ), Quaternion.identity, parentHierarchyObject.transform);
                break;
            case int n when (n >= per0 + per1 + per2 + per3 +per4 && n <= per0 + per1 + per2 + per3 + per4 + per5):
                Instantiate(getRandomOreFromOreFamily(oreFamily5), new Vector3(x + initialX, y + initialY, z + initialZ), Quaternion.identity, parentHierarchyObject.transform);
                break;
            case int n when (n >= per0 + per1 + per2 + per3 + per4 + per5 && n <= per0 + per1 + per2 + per3 + per4 + per5 + per6):
                Instantiate(getRandomOreFromOreFamily(oreFamily6), new Vector3(x + initialX, y + initialY, z + initialZ), Quaternion.identity, parentHierarchyObject.transform);
                break;
            case int n when (n >= per0 + per1 + per2 + per3 + per4 + per5 + per6 && n <= per0 + per1 + per2 + per3 + per4 + per5 + per6 + per7):
                Instantiate(getRandomOreFromOreFamily(oreFamily7), new Vector3(x + initialX, y + initialY, z + initialZ), Quaternion.identity, parentHierarchyObject.transform);
                break;
            case int n when (n >= per0 + per1 + per2 + per3 + per4 + per5 + per6 + per7 && n <= per0 + per1 + per2 + per3 + per4 + per5 + per6 + per7 + per8):
                Instantiate(getRandomOreFromOreFamily(oreFamily8), new Vector3(x + initialX, y + initialY, z + initialZ), Quaternion.identity, parentHierarchyObject.transform);
                break;
            case int n when (n >= per0 + per1 + per2 + per3 + per4 + per5 + per6 + per7 + per8 && n <= per0 + per1 + per2 + per3 + per4 + per5 + per6 + per7 + per8 + per9):
                Instantiate(getRandomOreFromOreFamily(oreFamily9), new Vector3(x + initialX, y + initialY, z + initialZ), Quaternion.identity, parentHierarchyObject.transform);
                break;
            case int n when (n >= per0 + per1 + per2 + per3 + per4 + per5 + per6 + per7 + per8 + per9 && n <= per0 + per1 + per2 + per3 + per4 + per5 + per6 + per7 + per8 + per9 + per10):
                Instantiate(getRandomOreFromOreFamily(oreFamily10), new Vector3(x + initialX, y + initialY, z + initialZ), Quaternion.identity, parentHierarchyObject.transform);
                break;
            case int n when (n >= per0 + per1 + per2 + per3 + per4 + per5 + per6 + per7 + per8 + per9 + per10 && n <= per0 + per1 + per2 + per3 + per4 + per5 + per6 + per7 + per8 + per9 + per10 + per11):
                Instantiate(getRandomOreFromOreFamily(oreFamily11), new Vector3(x + initialX, y + initialY, z + initialZ), Quaternion.identity, parentHierarchyObject.transform);
                break;
            default:
                //in the case where our random number didn't line up with anything, we need to spawn a default block
                //Instantiate(getRandomOreFromOreFamily(oreFamily0), new Vector3(x + initialX, y + initialY, z + initialZ), Quaternion.identity, parentHierarchyObject.transform);
                Debug.Log("Got an unknown case evaluation - placing a random block from oreFamily0");
                break;
        }
    }

    GameObject getRandomOreFromOreFamily(GameObject[] oreFamily)
    {
        
        int randomOreFamilyIndex = Random.Range(0, oreFamily.Length);
        //Debug.Log("Going to return oreFamily at index " + randomOreFamilyIndex);
        return oreFamily[randomOreFamilyIndex];
    }

    GameObject getRandomOreFromOreFamily(GameObject[] oreFamily, int bias1percent, int bias2percent, int bias3percent)
    {

        int randomOreBias = Random.Range(0, (bias1percent + bias2percent + bias3percent));
        int oreIndex = 0;
        switch (randomOreBias)
        {
            case int n when (n >= 0 && n <= bias1percent):
                oreIndex = 0;
                break;
            case int n when (n >= bias1percent && n <= bias1percent + bias2percent):
                oreIndex = 1;
                break;
            case int n when (n >= bias1percent + bias2percent && n <= bias1percent + bias2percent + bias3percent):
                oreIndex = 2;
                break;
            default:
                Debug.Log("Didn't obtain a good bias ore index.");
                oreIndex = 4;
                break;
        }

        return oreFamily[oreIndex];
    }

    
}
