using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //MAnagers de sonido
    private SFXManager sfxManager;
    private BGMManager bgmManager;

    //variable para almacenar cantidad de monedas
    private int coins;
    //variable para el texto de monedas del canvas
    public Text coinsText;

    public List<GameObject> enemiesInScreen = new  List<GameObject>();

    void Awake()
    {
        sfxManager = GameObject.Find("SFXManager").GetComponent<SFXManager>();
        bgmManager = GameObject.Find("BGMManager").GetComponent<BGMManager>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
      {

         KillAllEnemies();

      }
    }

    void KillAllEnemies()
   {      
      foreach(GameObject enemy in enemiesInScreen)
      {

         Destroy(enemy);

      }

   }

    //Funcion para matar a Mario
    public void DeathMario()
    {
        //Reproducimos sonido de muerte
        sfxManager.DeathSound();
        //Paramos la BGM
        bgmManager.StopBGM();
        //Lllamamos la funcion de cargar el menu principal despues de 3 segundos
        Invoke("LoadMainMenu", 3);
    }

    //Funcion para cargar el menu principal
    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    //Funcion para matar goombas
    public void DeathGoomba(GameObject goomba)
    {
        //variable para el animator del goomba
        Animator goombaAnimator;
        //variable para el script del goomba
        Enemy goombaScript;
        //variable para el collider
        BoxCollider2D goombaCollider;

        //asignamos las variable
        goombaScript = goomba.GetComponent<Enemy>();
        goombaAnimator = goomba.GetComponent<Animator>();
        goombaCollider = goomba.GetComponent<BoxCollider2D>();

        //cambiamos a la animacion de muerte
        goombaAnimator.SetBool("GoombaDeath", true);

        //cambiamos la variable del goomba a false
        goombaScript.isAlive = false;

        //desactivo el collider
        goombaCollider.enabled = false;

        //destruimos el goomba
        Destroy(goomba, 0.3f);

        //llamamos la funcion del sonido de muerte del goomba
        sfxManager.GoombaSound();
    }

    //Funcion para recoger monedas
    public void Coin(GameObject moneda)
    {
        //Destruimos la moneda
        Destroy(moneda);
        //Reproducimos sonido
        sfxManager.MonedaSound();
        //Sumamos 1 al contador de monedas
        coins++;
        //Actualizamos el texto de la UI
        coinsText.text = "Coins: " + coins;
    }
}
