using Domain.DTOs;

namespace Application.Interfaces
{
    /// <summary>
    /// Check result save and load handler
    /// </summary>
    public interface ICheckInfoSavior
    {
        /// <summary>
        /// Load check result information
        /// </summary>
        /// <returns>Check result information</returns>
        CheckInfo LoadCheckInfo();
        
        /// <summary>
        /// Save check result information
        /// </summary>
        /// <param name="info">Check result information</param>
        void SaveCheckInfo(CheckInfo info);
    }
}