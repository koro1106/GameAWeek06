using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform  target; // プレイヤー
    public float smooth = 5f; //滑らかに追いかける
    public float fixedZ = -10f; // Zの固定値
    public float offsetY = 1.5f;
    void LateUpdate()
    {
        if (target == null) return;

        Vector3 targetPos = new Vector3(
            target.position.x, target.position.y + offsetY, fixedZ);

        // カメラの位置を滑らかに追従させる
        transform.position = Vector3.Lerp(transform.position, targetPos, smooth * Time.deltaTime);
    }
}
