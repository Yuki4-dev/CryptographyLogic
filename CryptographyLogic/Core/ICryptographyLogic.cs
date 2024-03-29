﻿#nullable enable

namespace CryptographyLogic.Core
{
    public interface ICryptographyLogic
    {
        string ToHash(string data);

        string EnCryptography(string textData, string password);

        string DeCryptography(string baseValue, string password);
    }
}
