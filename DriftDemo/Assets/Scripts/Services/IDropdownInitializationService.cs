using Data;
using TMPro;

namespace Services
{
    public interface IDropdownInitializationService
    {
        void InitPaintingDropdown(TMP_Dropdown dropdown, CarName carName);
        void InitTuningDropdown(TMP_Dropdown dropdown, CarName carName);
    }
}