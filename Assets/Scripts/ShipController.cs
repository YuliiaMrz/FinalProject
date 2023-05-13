using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ShipController : MonoBehaviour
{
    public Rigidbody rb;
    public float speed=10;
    public float turnRate=10;
    public int Keys = 0;
    public Text Key_text;
    public float health=100;
    public Image Health_UI;
    public GameObject gameEndScreen;
    public GameObject hudMessage;
    public Text GameEndText;
    public Animator anim;
    private void Start()
    {
        Time.timeScale = 1;
        Keys = 0;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {

        if (Input.GetKey(KeyCode.W))
        {
            Moveforward();
        }
        if (Input.GetKey(KeyCode.S))
        {
            MoveReverse();
        }
        if (Input.GetKey(KeyCode.D))
        {
            TurnRight();
        }
        if (Input.GetKey(KeyCode.A))
        {
            TurnLeft();
        }

        if (Input.GetKeyUp(KeyCode.D))
        {
            Vector3 eulerRotation = transform.rotation.eulerAngles;
            transform.rotation = Quaternion.Euler(eulerRotation.x, eulerRotation.y, 0);
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            Vector3 eulerRotation = transform.rotation.eulerAngles;
            transform.rotation = Quaternion.Euler(eulerRotation.x, eulerRotation.y, 0);
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            anim.SetBool("ismoving", false);
        }

    }

    public void Moveforward()
    {
        rb.AddForce(transform.forward*speed, ForceMode.Acceleration);
        anim.SetBool("ismoving", true);
    }
    public void MoveReverse()
    {
        rb.AddForce(-transform.forward*(speed-2), ForceMode.Acceleration);
    }
    public void TurnRight()
    {
        transform.RotateAround(transform.position, Vector3.up, turnRate * Time.deltaTime);
    }
    public void TurnLeft()
    {
        transform.RotateAround(transform.position, Vector3.up, -turnRate * Time.deltaTime);
    }
    public void AddKey()
    {
        Keys++;
        Key_text.text = "Keys : " + Keys;
    }

    public void CheckWinCondition()
    {
        if (Keys>=5)
        {
            GameWin();
        }
    }
    public void GameWin()
    {
        gameEndScreen.SetActive(true);
        GameEndText.text = "Congratulations, you won";
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0;
    }
    public void ReturnToMain()
    {
        SceneManager.LoadScene(0);
    }
    public void PlayAgain()
    {
        SceneManager.LoadScene(1);
    }
    public void HealthCheck(int damage)
    {
        health = health - damage;
        if (health<=0)
        {
            GameLose();                       
        }

        Health_UI.fillAmount = health / 100;
    }
    public void GameLose()
    {
        gameEndScreen.SetActive(true);
        GameEndText.text = "You lost, try again";
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0;
    }

}
