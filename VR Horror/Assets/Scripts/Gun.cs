using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class Gun : MonoBehaviour
{

   // [SteamVR_DefaultAction("Squeeze")]
    public SteamVR_Action_Single squeezeAction;

    public SteamVR_Action_Vector2 touchPadAction;

    public static bool triggerPressed = false;

    public GameObject bullet;
    public float bulletSpeed;
    private GameObject muzzle;

    // Start is called before the first frame update
    void Start()
    {
        muzzle = GameObject.Find("Muzzle");
    }

    // Update is called once per frame
    void Update()
    {
        if (SteamVR_Actions._default.GrabPinch.GetStateDown(SteamVR_Input_Sources.RightHand))
        {
            print("trigger pressed");
            GameObject spawnedBullet = Instantiate(bullet, muzzle.transform.position, Quaternion.identity);
            spawnedBullet.GetComponent<Rigidbody>().AddForce(transform.forward * bulletSpeed);
            Destroy(spawnedBullet, 6f);
            triggerPressed = true;
        }
        else if (SteamVR_Actions._default.GrabPinch.GetStateUp(SteamVR_Input_Sources.RightHand))
        {
            print("trigger released");
            triggerPressed = false;
        }
    }
}
