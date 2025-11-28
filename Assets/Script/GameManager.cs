using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private float posX = -17f; // プレイヤー座標
    [SerializeField] private float posY = 22.55f;
    [SerializeField] private float posZ = -10f;

    [SerializeField] private GameObject gameOver;
    [SerializeField] private GameObject gameClear;
    [SerializeField] private GameObject userGuide;

    public void OnTitleButton()
    {
        SceneManager.LoadScene("TitleScene");
    }
    public void OnPlayButton()
    {
        SceneManager.LoadScene("PlayScene");
    }
  public void OnRetryButton()
  {
        player.SetActive(true);
        player.transform.position = new Vector3(posX, posY, posZ);
        gameClear.SetActive(false);
        gameOver.SetActive(false);
        userGuide.SetActive(true);
  }
}
