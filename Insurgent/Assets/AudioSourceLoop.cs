//Create an empty GameObject and attach this script
//Attach an AudioSource component. (Click on the GameObject, go to its Inspector and click Add Component Button. Go to Audio>Audio Source)
//Attach an Audio clip in the AudioClip field of the AudioSource
//Create a Button (Create>UI>Button) and a Toggle (Create>UI>Toggle). Attach these in the Inspector of your GameObject.

//This script allows you to toggle the loop of a sound on or off
using UnityEngine;
using UnityEngine.UI;

public class AudioSourceLoop : MonoBehaviour
{
    AudioSource m_AudioSource;

    public Toggle m_Toggle;
    public Button m_Button;

    void Start()
    {
        //Fetch the AudioSource component of the GameObject (make sure there is one in the Inspector)
        m_AudioSource = GetComponent<AudioSource>();
        //Stop the Audio playing
        m_AudioSource.Stop();
        //Call the PlayButton function when you click this Button
        m_Button.onClick.AddListener(PlayButton);
    }

    void Update()
    {
        //Turn the loop on and off depending on the Toggle status
        m_AudioSource.loop = m_Toggle.isOn;
    }

    //This plays the Audio clip when you press the Button
    void PlayButton()
    {
        m_AudioSource.Play();
    }
}
