using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class MenuBehavior: MonoBehaviour
{
   [SerializeField] private GameObject blackScreen;
   [SerializeField] private GameObject menuPanel;
   [SerializeField] private GameObject levelPanel;
   [SerializeField] public GameObject resumeButton;
   [SerializeField] public GameObject startButton;
   [SerializeField] public Text menuText;
   [SerializeField] public Text levelText;
   private Vector3 menuPanelPosOnScreen = new Vector3(4, 5.5f, 0);
   private Vector3 menuPanelPosLeft = new Vector3(-10, 5.5f, 0);

   private void Start()
   {
      resumeButton.SetActive(false);
      menuPanel.SetActive(true);
      levelPanel.SetActive(true);
      menuPanel.transform.position = menuPanelPosLeft;
      DOVirtual.DelayedCall(0.4f, MovingPanel);
   }

   public void MovingPanel()
   {
      if (menuPanel.transform.position.x != menuPanelPosOnScreen.x)
      {
         menuPanel.transform.DOMove(menuPanelPosOnScreen, .2f);
      }
      else
      {
         menuPanel.transform.DOMove(menuPanelPosLeft, .2f);
      }
   }

   public void BlackScreenOnOff()
   {
      var image = blackScreen.GetComponent<Image>();
      if (image.color.a == 1)
      {
         image.DOFade(0, .3f).OnComplete(BlackScreenActivity);
      }
      else
      {
         BlackScreenActivity();
         image.DOFade(1, .3f);
      }
   }

   void BlackScreenActivity()
   {
      blackScreen.SetActive(!blackScreen.activeSelf);
   }

   public void ChangeLevelText(string str)
   {
      levelText.text = "Level - " + str;
   }

   public void LevelPanelActivity()
   {
      levelPanel.SetActive(!levelPanel.activeSelf);
   }
}
