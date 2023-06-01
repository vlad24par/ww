using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DivisionPanel : MonoBehaviour
{
    [SerializeField] private Button _closeButton;
    [SerializeField] private GameObject _panel;
    [SerializeField] private Button _nextButton;
    [SerializeField] private Button _previousButton;
    [SerializeField] private Button _doneButton;
    [SerializeField] private TMP_Text _divisionText;
    [SerializeField] private List<GameObject> _divisionPanels;

    private int _page = 0;

    private void OnEnable()
    {
        _closeButton.onClick.AddListener(OnButtonClick);
        _doneButton.onClick.AddListener(OnButtonClick);
        
        _nextButton.onClick.AddListener(NextButtonClick);
        _previousButton.onClick.AddListener(PreviousButtonClick);
        SelectPage(0);
    }

    private void OnDisable()
    {
        _closeButton.onClick.RemoveListener(OnButtonClick);
        _doneButton.onClick.RemoveListener(OnButtonClick);

        _nextButton.onClick.RemoveListener(NextButtonClick);
        _previousButton.onClick.RemoveListener(PreviousButtonClick);
    }

    private void OnButtonClick()
    {
        _panel.SetActive(!_panel.activeSelf);
    }

    private void NextButtonClick()
    {
        SelectPage(_page + 1);
    }

    private void PreviousButtonClick()
    {
        SelectPage(_page - 1);
    }

    private void SelectPage(int page)
    {
        if (page < 0)
            page = _divisionPanels.Count - 1;
        if (page >= _divisionPanels.Count)
            page = 0;

        _page = page;

        for (int i = 0; i < _divisionPanels.Count; i++)
        {
            
            if(i == _page)
                _divisionPanels[i].SetActive(true);
            else
            {
                _divisionPanels[i].SetActive(false);
            }
            //одно и то же
            _divisionPanels[i].SetActive(i == page);
        }

        //if _page == 0
        _divisionText.text = $"Division {_page + 1}";//Division 1
        // _divisionText.text = "Division {_page + 1}";//Division {_page + 1}
        // _divisionText.text = "Division " + _page + 1;//Division 01
        // _divisionText.text = "Division " + (_page + 1);//Division 1
        
    }
}
