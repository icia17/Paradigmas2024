using Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using Microsoft.DirectX;
using Microsoft.DirectX.DirectSound;


public class AudioManager 
{
    public static AudioManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new AudioManager();
            }
            return instance;
        }
    }

    private static AudioManager instance;

    private SoundPlayer soundPlayer;


    public void PlayAudioLoop(string filePath)
    {
        try
        {
            if (System.IO.File.Exists(filePath))
            {
                soundPlayer = new SoundPlayer(filePath);
                soundPlayer.PlayLooping();  // Play the audio
                Engine.Debug($"Playing audio: {filePath}");
            }
            else
            {
                Engine.Debug($"File not found: {filePath}");
            }
        }
        catch (Exception e)
        {
            Engine.Debug($"Error playing audio: {e.Message}");
        }
    }

    public void StopAudio()
    {
        if (soundPlayer != null)
        {
            soundPlayer.Stop(); 
           
        }
    }

}



