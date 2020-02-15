using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCollisionSoundBehaviour : MonoBehaviour
{
    public AudioSource soundFXWall;
    public AudioSource soundFXBrickHit;
    public AudioSource soundFXBrickBroken;
    public AudioSource soundTrack;
    // Start is called before the first frame update
    void Start()
    {
        soundTrack.Play();
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.collider.tag == "Wall" || other.collider.tag == "Paddle") 
        {
            soundFXWall.Play();
        }
        else if (other.collider.tag == "Brick") 
        {
             soundFXBrickHit.Play();
           /* if (other.collider.GetComponent<BrickCrackBehaviour>().getLife() > 1) 
            {
                soundFXBrickHit.Play();
            }
            else 
            {
                soundFXBrickBroken.Play();
            }*/
        }
    }
}
