using UnityEngine;

namespace BallDispenser.Scripts
{
    public class BallDispenserScript : MonoBehaviour
    {
        [SerializeField] private GameObject[] ballInstances;
        [SerializeField] private float fireRateInSeconds = 3f;
        [SerializeField] private float speed = 10f;
        [SerializeField] private bool toTheLeft = true;

        private int maxActiveBalls;
        private BallDispenserScript ballDispenser;
        private float seconds;
        private int ballCount;

        private void Start()
        {
            Debug.Log("start");
            maxActiveBalls = ballInstances.Length;
            ballDispenser = gameObject.GetComponent<BallDispenserScript>();
        }

        private void LateUpdate()
        {
            foreach (var ball in ballInstances)
            {
                var vel = ball.GetComponent<Rigidbody2D>().velocity;
                ball.GetComponent<Rigidbody2D>().velocity = speed * vel.normalized;
            }
        }

        void Update()
        {
            if (!(Time.time > seconds) || ballCount >= maxActiveBalls) return;
        
            ballInstances[ballCount].SetActive(true);
            ballInstances[ballCount].transform.position = ballDispenser.transform.position;
            ballInstances[ballCount].GetComponent<Rigidbody2D>().velocity = new Vector2(toTheLeft ? -10f : 10f, 0);

            seconds += fireRateInSeconds;
            ballCount++;
        }
    }
}
