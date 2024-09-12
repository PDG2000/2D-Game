using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int totalPoint;
    public int stagePoint;
    public int stageIndex;
    public int health;
    public PlayerMove player;
    public GameObject[] Stages;

    public Image[] UIhealth;
    public Text UIPoint;
    public Text UIStage;
    public GameObject UIRestarBtn;

    private void Update()
    {
        UIPoint.text = (totalPoint + stagePoint).ToString();
    }

    public void NextStage()
    {
        if (stageIndex < Stages.Length - 1) //���� �������� �̵� �ƴϸ�~
        {
            Stages[stageIndex].SetActive(false);
            stageIndex++;
            Stages[stageIndex].SetActive(true);
            PlayerReposition();

            UIStage.text = "STAGE" + (stageIndex + 1);
        }
        else // ���� Ŭ����
        {
            Time.timeScale = 0;

            UIRestarBtn.SetActive(true);
            Text btnText = UIRestarBtn.GetComponentInChildren<Text>();
            btnText.text = "Clear!";
            UIRestarBtn.SetActive(true);
        }

        totalPoint += stagePoint;
        stagePoint = 0;
    }

    public void HealthDown()
    {
        if (health > 1)
        {
            health--;
            UIhealth[health].color = new Color(1, 0, 0, 0.4f);
        }
        else
        {
            UIhealth[0].color = new Color(1, 0, 0, 0.4f);

            health--;
            player.OnDie();

            UIRestarBtn.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) //tag == "Player")
        {
            //�������� �ٽ� �÷��̾� ����ġ
            if (health > 1)
            {
                PlayerReposition();
            }
            HealthDown();
        }
    }

    public void PlayerReposition()
    {
        player.transform.position = new Vector3(-8, -2, 0);
        player.VelocityZero();
    }

    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}