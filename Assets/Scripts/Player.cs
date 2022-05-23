using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using static UnityEngine.Debug;

namespace LevelMaze
{
    [RequireComponent(typeof(CharacterController))]
    public sealed class Player : MonoBehaviour
    {
        internal static int keys { get; private set; }

        internal static float speed;

        CharacterController controller;

        [SerializeField] float gravity = -9.81f;
        Vector3 velocity;

        bool groundCheck;
        [SerializeField] Transform groundObject;
        [SerializeField] LayerMask groundMask;

        [SerializeField] Animator cameraAnim;

        [SerializeField] AudioSource audioSource;
        [SerializeField] List<AudioClip> footSteps;

        internal static UnityAction onPlayerInZone;
        internal static UnityAction onPlayerCollectKey;

        void Start()
        {
            controller = GetComponent<CharacterController>();
            KeyPanel.onPlayerTouchedPanel += onTouchPanel;

            WinController.onPlayerWin += OnPlayerWin;

            speed = 5f;
            keys = 0;
        }

        void UnitMove()
        {
            groundCheck = Physics.CheckSphere(groundObject.position, 0.3f, groundMask);
            if (groundCheck)
            {
                velocity.y = -2f;
            }
            //движение на земле
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            if (x != 0 || z != 0) 
            {
                cameraAnim.SetBool("isWalking", true);
                if (!audioSource.isPlaying) 
                {
                    audioSource.clip = footSteps[Random.Range(0, footSteps.Count - 1)];
                    audioSource.Play();
                }
            }
            else 
            { 
                cameraAnim.SetBool("isWalking", false);
            }

            Vector3 move = transform.right * x + transform.forward * z;
            controller.Move(speed * move * Time.deltaTime);

            //гравитация
            velocity.y += gravity * Time.deltaTime;
            controller.Move(velocity * Time.deltaTime);
        }

        void Update()
        {
            UnitMove();
        }

        void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Key")
            {
                keys++;
                onPlayerCollectKey.Invoke();
                Destroy(other.gameObject);
                Log("destroy");
            }
        }

        void onTouchPanel()
        {
            Log("touch");
            if (keys == 4)
            {
                KeyPanel.hasKeys = true;
            }
        }

        void OnPlayerWin()
        {
            speed = 0f;
        }
    }
}