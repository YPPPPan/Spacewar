using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public int CurrentScore { get; private set; }
    private static Text _scoreText;
    private AudioSource[] _audio;
    // Start is called before the first frame update
    void Start()
    {
        _scoreText = GetComponent<Text>();
        CurrentScore = 0;
        UpdateScore();
        _audio = GetComponents<AudioSource>();
    }

    public void AddScore(int value)
    {
        CurrentScore = Mathf.Max(0, CurrentScore + value);
        UpdateScore();
        _audio[0].PlayOneShot(_audio[0].clip);
        _audio[1].PlayOneShot(_audio[1].clip);
    }

    private void UpdateScore()
    {
        _scoreText.text = string.Format("{0}", CurrentScore).PadLeft(4, '0');
    }

    public void AllyDestroy()
    {
        _audio[2].PlayOneShot(_audio[2].clip);
    }
}
