using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;

public class playerController : Agent
{
    public Rigidbody2D playerBody;

    float horizontal;
    float vertical;

    public float runSpeed = 20.0f;
    public GameObject bullet;
    public GameObject[] enemies;

    void Start()
    {
        playerBody = GetComponent<Rigidbody2D>();
    }

    public override void OnEpisodeBegin()
    {
        transform.position = new Vector2(0,-4.2f);
    }

    public override void CollectObservations(VectorSensor sensor)
    {
        sensor.AddObservation((Vector2)transform.localPosition);

        GameObject[] enemies = GameObject.FindGameObjectsWithTag("enemy");
        if (enemies.Length < 1)
        {
            sensor.AddObservation((Vector2)transform.localPosition);
        }
        else
        {
            sensor.AddObservation((Vector2)enemies[0].transform.localPosition);
        }
    }

    public override void OnActionReceived(ActionBuffers actions)
    {
        int moveX = actions.DiscreteActions[0];
        int fire = actions.DiscreteActions[1];

        //Debug.Log(fire);
        //playerBody.velocity = new Vector2(moveX * runSpeed, 0f);


        transform.localPosition += new Vector3(moveX-1, 0) * Time.deltaTime * runSpeed;

        if (fire == 1)
        {
            Instantiate(bullet, transform.position, Quaternion.identity);
        }
    }

    public override void Heuristic(in ActionBuffers actionsOut)
    {
        ActionSegment<int> DiscreteActions = actionsOut.DiscreteActions;

        //DiscreteActions[0] = Input.GetAxisRaw("Horizontal");

        switch (Mathf.RoundToInt(Input.GetAxisRaw("Horizontal"))){
            case -1: 
                DiscreteActions[0] = 0; break;
            case 0:
                DiscreteActions[0] = 1; break;
            case 1:
                DiscreteActions[0] = 2; break;
        }


        DiscreteActions[1] = Input.GetKey(KeyCode.Space) ? 1 : 0;
        //Debug.Log(DiscreteActions[1]);
    }


    private void FixedUpdate()
    {
        //playerBody.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "enemy")
        {
            AddReward(-10f);
            EndEpisode();
        }
        if (other.gameObject.tag == "end")
        {
            AddReward(-5f);
            EndEpisode();
        }
    }
    public void IKilledSomeone()
    {
        AddReward(5f);
    }
    public void BulletMissed()
    {
        AddReward(-0.5f);
    }
}
