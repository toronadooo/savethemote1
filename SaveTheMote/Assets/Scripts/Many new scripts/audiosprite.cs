using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class audiosprite : MonoBehaviour {
	public Sprite sprite1;
	public Sprite sprite2;
	Image[] images;
	public int sound;
	// Use this for initialization
	void Start () {
				images = gameObject.GetComponentsInChildren<Image> ();
				if (sound == 1) {
						AudioListener.pause = true;
						foreach (Image image in images) {
								image.sprite = sprite1;
						}
				}
				if (sound == 2) {
						AudioListener.pause = false;
						foreach (Image image in images) {
								image.sprite = sprite2;
						}

				}
		}
	
	// Update is called once per frame
	void Update () {
		PlayerPrefs.HasKey ("Sound");
		sound = PlayerPrefs.GetInt("Sound");
		if (sound== 1) {AudioListener.pause = true;
			foreach (Image image in images) {
				image.sprite = sprite1;
			}
		}
		if (sound== 2) {AudioListener.pause = false;
			foreach (Image image in images) {
				image.sprite = sprite2;
			}

		}


	}
	public void AudioClick(){
		if(sound==2){ PlayerPrefs.SetInt("Sound",1);AudioListener.pause = true;} else {PlayerPrefs.SetInt("Sound",2);AudioListener.pause = false;}
	}
}
