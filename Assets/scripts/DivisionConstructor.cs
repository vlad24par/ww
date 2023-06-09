using System.Collections.Generic;
using DefaultNamespace;
using TMPro;
using Units;
using UnityEngine;
using UnityEngine.UI;

public class DivisionConstructor : MonoBehaviour
{
    [SerializeField] private GameObject _panel;
    [SerializeField] private Button _nextButton;
    [SerializeField] private Button _previousButton;
    [SerializeField] private Button _doneButton;
    [SerializeField] private TMP_Text _divisionText;
    [SerializeField] private List<DivisionPanel> _divisionPanels;

    [SerializeField] private Division _divisionPrefab;
    
    private int _page = 0;

    private void OnEnable()
    {
        _doneButton.onClick.AddListener(Done);
        
        _nextButton.onClick.AddListener(NextButtonClick);
        _previousButton.onClick.AddListener(PreviousButtonClick);
        SelectPage(0);
    }

    private void OnDisable()
    {
        _doneButton.onClick.RemoveListener(Done);

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


    private void Done()
    {
        for (int i = 0; i < _divisionPanels.Count; i++)
        {
            if (_divisionPanels[i].Units.Count > 0)
            {
                var newDivision = Instantiate(_divisionPrefab, new Vector3(0, i * 2, 0), Quaternion.identity);
                newDivision.SetInfo(_divisionPanels[i].Units);
            }
        }
        
        gameObject.SetActive(false);
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
                _divisionPanels[i].gameObject.SetActive(true);
            else
            {
                _divisionPanels[i].gameObject.SetActive(false);
            }
            //одно и то же
            _divisionPanels[i].gameObject.SetActive(i == page);
        }

        //if _page == 0
        _divisionText.text = $"Division {_page + 1}";//Division 1
        // _divisionText.text = "Division {_page + 1}";//Division {_page + 1}
        // _divisionText.text = "Division " + _page + 1;//Division 01
        // _divisionText.text = "Division " + (_page + 1);//Division 1
        
    }
}
