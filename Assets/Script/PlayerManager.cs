using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public GameObject gameOverEffect;
    [SerializeField] private GameObject gameOver;
    [SerializeField] private GameObject gameClear;
    [SerializeField] private GameObject userGuide;

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.CompareTag("Goal"))
        {
            // ゲームクリア
            Debug.Log("ゲームクリア");
            // リザルト画面表示
            gameClear.SetActive(true);
            userGuide.SetActive(false);
            gameObject.SetActive(false);
        }
        if (hit.gameObject.CompareTag("Dead"))
        {
            // ゲームオーバー
            Debug.Log("ゲームオーバー");
            Die();
            userGuide.SetActive(false);
        }
    }
    private void Die()
    {
        //エフェクトPrefabをプレイヤーの現在位置に生成する処理
        if (gameOverEffect != null)
        {
            // エフェクトをプレイヤーの現在位置に生成 
            GameObject effectInstance = Instantiate(
                gameOverEffect,this.transform.position,Quaternion.identity // 回転は特に指定せず
            );

            // 生成したエフェクトを自動で破棄する処理を追加するのが望ましい
            // (エフェクトの再生時間が終わったら消えるように)
            ParticleSystem ps = effectInstance.GetComponent<ParticleSystem>();
            if (ps != null)
            {
                // パーティクルシステムの再生時間を取得し、その時間後にオブジェクトを破棄
                float duration = ps.main.duration + ps.main.startLifetime.constantMax;
                Destroy(effectInstance, duration);
            }
            else
            {
                // ParticleSystemがアタッチされていない場合のフォールバック
                Destroy(effectInstance, 5f);
            }
        }
      
        // プレイヤーオブジェクト削除
        gameObject.SetActive(false);
        // リザルト画面表示
        gameOver.SetActive(true);
    }
}
