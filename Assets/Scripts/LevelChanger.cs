using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{
    public Animator animator;

    private int levelToLoad;
    private bool levelLoading = false;
    public float fadeTime;
    public static int levelIndexPrev;

    // Create a singleton for easy access
    #region Singleton

    public static LevelChanger Instance;

    private void Awake()
    {
        Instance = this;
    }

    #endregion

    void Start()
    {
        AnimationClip[] clips = animator.runtimeAnimatorController.animationClips;
        fadeTime = clips[0].length;
    }

    public void FadeOut()
    {
        animator.SetTrigger("FadeOut");
    }
    public void FadeIn()
    {
        animator.SetTrigger("FadeIn");
    }

    // Fade out and then change level
    public void FadeToLevel(int levelIndex)
    {
        levelToLoad = levelIndex;
        levelIndexPrev = SceneManager.GetActiveScene().buildIndex;
        animator.SetTrigger("FadeOut");
        levelLoading = true;
    }

    // When fade out has finished, change level if that was intended
    public void OnFadeComplete()
    {
        if (levelLoading == true)
            SceneManager.LoadScene(levelToLoad);
        levelLoading = false;
    }
}
