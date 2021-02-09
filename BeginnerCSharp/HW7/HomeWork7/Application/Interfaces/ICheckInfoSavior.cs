using Domain.DTOs;

namespace Application.Interfaces
{
    public interface ICheckInfoSavior
    {
        CheckInfo LoadCheckInfo();
        void SaveCheckInfo(CheckInfo info);
    }
}