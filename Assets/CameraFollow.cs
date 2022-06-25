using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    PlayerScript player;
    Vector3 originPos;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerScript>();
        originPos = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, originPos.z);
    }
}
