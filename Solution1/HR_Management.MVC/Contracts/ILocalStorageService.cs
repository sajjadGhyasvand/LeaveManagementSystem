﻿namespace HR_Management.MVC.Contracts
{
    public interface ILocalStorageService
    {
        void ClearStorage(List<string> keys);
        bool Exsists(string key);
        T GetStorageValue<T>(string key);
        void SetStorageValue<T>(string key,T value);
    }
}
