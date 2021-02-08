using Task3.Models;

namespace Task3.Interfaces
{
    public interface ICheckInfoSavior
    {
        CheckInfo LoadCheckInfo();
        void SaveCheckInfo(CheckInfo info);
    }
}