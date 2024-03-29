﻿

using System.Text;

namespace CryptographyLogic.Core
{
    public class CryptographyLogicConfig
    {
        public const int VERSION = 1;

        public const int BLOCK_SIZE = 128;

        public const int IV_SIZE = BLOCK_SIZE;

        public const int KEY_SIZE = 256;

        public const char IV_SEPARATOR = ';';

        public const string SOLT = "hoge";

        public static readonly Encoding TEXT_ENCODING = Encoding.UTF8;

        public static string DetailToString()
        {
            return $"=== CryptographyLogic Configuration===" + Environment.NewLine +
                $"version : {VERSION}" + Environment.NewLine +
                $"Block Size(bits) : {BLOCK_SIZE}" + Environment.NewLine +
                $"IV Size(bits) : {IV_SIZE}" + Environment.NewLine +
                $"Key Size(bits) : {KEY_SIZE}" + Environment.NewLine +
                $"Text Encoding: {TEXT_ENCODING.EncodingName}";
        }
    }
}
