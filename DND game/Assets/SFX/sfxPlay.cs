using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sfxPlay : MonoBehaviour
{
	bool xMove = false;
	bool yMove = false;
	public AudioSource sliding;
    // Start is called before the first frame update
    void Start()
    {
       sliding = GetComponent <AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
       
	   
	   
	   if(transform.position.x >0){
		xMove = true;
	   }
	   if(transform.position.y != 0){
		yMove = true;
	   }
		
			
		}
		 
	void OnCollisionEnter2D(Collision2D col){
		if(col.gameObject.tag == "Platform" && xMove == true){
				
			Debug.Log("I hit it");
			sliding.Play();
			}
    }
	//if (xMove == true && yMove == false){
		//sliding.Play();
	//}
}
