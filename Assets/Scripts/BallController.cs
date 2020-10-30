using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallController : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 1f;

    [SerializeField] private float _jumpSpeed = 1f;

    private bool _isGrounded;

    [CanBeNull] private Rigidbody _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        CheckInput();
    }

    private void FixedUpdate()
    {
        
    }

    private void CheckInput()
    {
        if (Input.GetKey(KeyCode.D))
        {
            Move(Vector3.right);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            Move(Vector3.left);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }


    private void Jump()
    {
        if (!_isGrounded)
        {
            return;
        }

        _rigidbody.AddForce(Vector3.up * _jumpSpeed, ForceMode.Impulse);
    }

    private void Move(Vector3 direction)
    {
        _rigidbody.AddForce(direction * _moveSpeed, ForceMode.Acceleration);
    }

    //Çarpma durumu
    private void OnCollisionEnter(Collision other)
    {
        _isGrounded = true;
        
        

        CheckEnemyCollision(other);
    }

    private void CheckEnemyCollision(Collision collision)
    {
        bool hasCollidedWithEnemy = collision.collider.GetComponent<Enemy>();
        if (!hasCollidedWithEnemy)
        {
            return;
        }
        
        if (Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit, Mathf.Infinity))
        {
            Enemy enemy = hit.collider.GetComponent<Enemy>();
            bool isOnTopOfEnemy = enemy != null;
            if (isOnTopOfEnemy)
            {
                enemy.Die();
                return;
            }
                        
                       
        }
        Die();
    }

    //Aksi halde, isGrounded false.
    private void OnCollisionExit(Collision other)
    {
        _isGrounded = false;
    }

    //Objelere değer ama çarpmaz.
    private void OnTriggerEnter(Collider other)
    {
        Collectible collectible = other.GetComponent<Collectible>();
        bool isCollectible = collectible != null;

        if (isCollectible)
        {
            collectible.Collect();
        }
    }
    
    private void Die()
    {
        FindObjectOfType<LevelManager>().ChangeScene();
        GetComponent<MeshRenderer>().enabled = false;
    }
    
    
}
