using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WiiCharacterController : MonoBehaviour
{
    // カメラを追従させたいのならここにSetする
    [SerializeField] Camera relationalMoveCamera;
    [SerializeField] GameObject characterObject;
	// この重量以下なら体重計に乗っていないと断定
	[SerializeField] private float RideThreasoldWeight = 15f;
    // 移動速度
    [SerializeField] private float MoveSpeedRate = 1f;



    void Update()
    {
        for (int i = 0; i < Wii.GetRemoteCount(); ++i)
        {
            if (Wii.IsActive(i) && Wii.GetExpType(i) == 3)
            {
                // WiiFitの重心の方向にCharacterを向かせる
                Vector2 theCenter = Wii.GetCenterOfBalance(i);
                Vector3 currentCharacterPosition = characterObject.transform.position;
                Vector3 willNormalizedPosition = new Vector3(currentCharacterPosition.x + theCenter.x, currentCharacterPosition.y, currentCharacterPosition.z + theCenter.y);
                characterObject.transform.LookAt(willNormalizedPosition);
                // Characterが向いている方向に1歩を踏み出すことで移動できる
                characterObject.transform.position = currentCharacterPosition + ((characterObject.transform.forward * Time.deltaTime * (willNormalizedPosition - currentCharacterPosition).sqrMagnitude) * MoveSpeedRate);
                if (relationalMoveCamera != null)
                {
                    relationalMoveCamera.transform.position += (characterObject.transform.position - currentCharacterPosition);
                }
                break;
            }
        }
    }
}
