using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Store : MonoBehaviour
{
    [SerializeField] private Text _text;

    private string _storeName;
    private string _itemType1;
    private string _itemType2;

    bool _shopping = true;
    bool _buying = true;

    List<string> _storeItemsList = new List<string>();
    List<string> _playerItemsList = new List<string>();

    static string input;

    public Store(string storeName, string soldItem_1, string soldItem_2)
    {
        FillStore();

        _storeName = storeName;
        _itemType1 = soldItem_1;
        _itemType2 = soldItem_2;
    }

    public void FillStore()
    {
        _text.color = Color.cyan;

        _storeItemsList.Add("Roll Again Card");
        _storeItemsList.Add("Get Out Of Jail Free Card");
    }
    public void StoreLoop()
    {
        PrintGreeting();

        while (_shopping)
        {
            if (Input.GetKeyDown(KeyCode.Y))
            {
                PurchaseLoop();
            }
            else if (Input.GetKeyDown(KeyCode.N))
            {
                PrintGoodbye();
            }
            else
            {
                PrintError();
            }
        }
    }
    private void PurchaseLoop()
    {
        PrintItems();

        _buying = true;
        while (_buying)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Alpha2))
            {
                int choice;
                if (int.TryParse(input, out choice))
                {
                    _playerItemsList.Add(_storeItemsList[choice - 1]);
                    _storeItemsList.RemoveAt(choice - 1);

                    _text.color = Color.yellow;
                    _text.text = $"You have purchased {_playerItemsList[_playerItemsList.Count - 1]}!";

                    PrintItems();


                }
            } else if (Input.GetKeyDown(KeyCode.Backspace))
            {
                PrintGoodbye();
            } 
            else
            {
                PrintError();
            }
        }
    }
    private void PrintItems()
    {
        _text.color = Color.green;
        _text.text = "Please Input the number next to the item you would like to purchase.\n";

        for(int i = 0; i < _storeItemsList.Count; i++)
        {
            _text.text = $"{i + 1}: {_storeItemsList[i]}\n";
        }

        _text.text = "What would you like to purchase?\n";
    }
    private void PrintGreeting()
    {
        _text.color = Color.green;
        _text.text = $"Welcome to the {_storeName} store! \n" +
            $"At this store, we sell the following items: {_itemType1}, and {_itemType2}! ";
    }
    public void PrintGoodbye()
    {
        _shopping = false;

        _text.color = Color.green;
        _text.text = $"Thank you player {_currentplayer} for visting the store today!\n" +
            $"I hope we made your day better!";
    }
    private void PrintError()
    {
        _text.color = Color.red;
        _text.text = "Please enter a valid command!!!";
    }
}
