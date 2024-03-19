
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;


public class LoadingScene : MonoBehaviour
{
    public static LoadingScene Instance;
    public static bool isOverAnimationLoading = false;

    [SerializeField] private TextMeshProUGUI textLoading;
    [SerializeField] private Image imageLoading;

    private AsyncOperation loadingSceneAsync;
    private Animator anim;
    void Start()
    {
        Instance = this;
        anim = GetComponent<Animator>();
        if (isOverAnimationLoading)
            anim.SetTrigger("SceneClose");
    }

    void Update()
    {
        if (loadingSceneAsync != null)
        {
            textLoading.text = Mathf.RoundToInt(loadingSceneAsync.progress * 100) + "%";
            imageLoading.fillAmount = loadingSceneAsync.progress;
        }
    }

    public static void SwitchScene(string sceneName)
    {
        Instance.anim.SetTrigger("SceneOpen");
        Instance.loadingSceneAsync = SceneManager.LoadSceneAsync(sceneName);
        Instance.loadingSceneAsync.allowSceneActivation = false;
    }

    public void OnAnimationOver()
    {
        isOverAnimationLoading = true;
        loadingSceneAsync.allowSceneActivation = true;
    }

}
