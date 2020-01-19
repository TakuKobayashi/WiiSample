using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WiiCharacterController : MonoBehaviour
{
    [SerializeField] GameObject characterObject;

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < Wii.GetRemoteCount(); ++i)
        {
            if (Wii.IsActive(i) && Wii.GetExpType(i) == 3)
            {
                Vector2 theCenter = Wii.GetCenterOfBalance(i);
                Vector3 characterPosition = characterObject.transform.position;
                characterObject.transform.LookAt(new Vector3(characterPosition.x + theCenter.x, characterPosition.y, characterPosition.z + theCenter.y));
                break;
            }
        }
    }
}
