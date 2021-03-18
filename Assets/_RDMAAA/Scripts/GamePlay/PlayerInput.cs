using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public IInputManager inputManager;
    public Vector3SO movement;
    [SerializeField]
    UIBarSO timeBar;
    [SerializeField]
    EnemySO timeSlowSO;
    [SerializeField]
    float timeScale = 7;
    [SerializeField]
    bool switchPlayers;
    [SerializeField]
    bool ability;
    [SerializeField]
    JetPackSO jetSO;
    [SerializeField]
    float timeUsage = 5;
    [SerializeField]
    EventSO onSwitchJetPlayer;
    [SerializeField]
    EventSO onSwitchTimePlayer;
    [SerializeField]
    bool isJet = true;
    float initialEnemySpeed;
    bool alive = true;

    void Start()
    {
        jetSO.canJump = false;
        jetSO.canJet = false;
        //getting abilities components
        if (null == inputManager)
        {
            inputManager = new InputHandler();
        }
        //getback button listener
        initialEnemySpeed = timeSlowSO.EnemySpeed;
    }

    void Update()
    {
        if (!alive) return;
        Vector3 moving = Vector3.zero;

        if (inputManager.GetForword())
        {
            moving.z++;
        }
        if (inputManager.GetBackword())
        {
            moving.z--;
        }
        if (inputManager.GetRight())
        {
            moving.x++;
        }
        if (inputManager.GetLeft())
        {
            moving.x--;
        }
        if (inputManager.Jump())
        {
            jetSO.canJump = true;
        }
        if (inputManager.UseJetPack())
        {
            // Debug.Log("can jet");
            jetSO.canJet = true;
            // jetSO.grounded = false;
        }
        else
        {
            jetSO.canJet = false;
        }
        if (!isJet && inputManager.useTime() && timeBar.Value >= timeUsage * Time.deltaTime)
        {
            timeSlowSO.EnemySpeed = timeScale;
            timeBar.Value -= timeUsage * Time.deltaTime;
        }
        else
        {
            ResetEnemySO();
        }
        if (inputManager.SwitchPlayer())
        {
            if (isJet)
            {
                onSwitchJetPlayer.Raise();
            }
            else
            {
                onSwitchTimePlayer.Raise();
            }
        }
        this.movement.vector = moving;
    }

    public void ResetEnemySO()
    {
        timeSlowSO.EnemySpeed = initialEnemySpeed;
    }
    public void Die()
    {
        alive = false;
    }

}
