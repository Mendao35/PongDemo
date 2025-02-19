using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveControler : MonoBehaviour
{
    public Color colorPlayer = Color.white;
    public Color colorEnemy = Color.white;

    public string namePlayer;
    public string nameEnemy;

    private static SaveControler _instance;

    private void Awake()
    {
        //Garanta que apenas uma instancia do Singleton exista
        if(_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        //Mantenha o Singleton vivo entre cenas
        DontDestroyOnLoad(this.gameObject);
    }
    //Propriedade estatica para acessar a instancia
    public static SaveControler Instance
    {
        get
        {
            if(_instance == null)
            {
                //Procure a instancia na cena
                _instance = FindObjectOfType<SaveControler>();

                //Se nao encontrar, crie uma nova instancia
                if(_instance == null)
                {
                    GameObject singletonObject = new GameObject(typeof(SaveControler).Name);
                    _instance = singletonObject.AddComponent<SaveControler>();
                }
            }
            return _instance;
        }
    }

    public string GetName(bool isPlayer)
    {
        return isPlayer ? namePlayer : nameEnemy;// Se for Player e o primeiro valor, se nao e o segundo
    }

    public void Reset()
    {
        nameEnemy = "";
        namePlayer = "";
        colorEnemy = Color.white;
        colorPlayer = Color.white;
    }

    public void SaveWuinner(string winner)
    {
        PlayerPrefs.SetString("SavedWinner", winner);
    }

    public string GetLastWinner()
    {
        return PlayerPrefs.GetString("SavedWinner");
    }

    public void ClearSave()
    {
        PlayerPrefs.DeleteAll(); //Apagam todas as Keys
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);//A sena Sera recarregada apos apagar os dados.
        //PlayerPrefs.DeleteKey("NomeDaKey"); //Apaga uma Key Especifica
    }

}
