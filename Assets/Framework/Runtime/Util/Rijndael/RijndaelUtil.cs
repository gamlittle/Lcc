﻿using System;
using System.Security.Cryptography;

namespace LccModel
{
    public static class RijndaelUtil
    {
        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="keyBytes"></param>
        /// <param name="valueBytes"></param>
        /// <returns></returns>
        public static byte[] RijndaelEncrypt(byte[] keyBytes, byte[] valueBytes)
        {
            //加密
            RijndaelManaged rijndael = new RijndaelManaged();
            rijndael.Key = keyBytes;
            rijndael.Mode = CipherMode.ECB;
            rijndael.Padding = PaddingMode.PKCS7;
            ICryptoTransform crypto = rijndael.CreateEncryptor();
            //加密后的数据
            return crypto.TransformFinalBlock(valueBytes, 0, valueBytes.Length);
        }
        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="key"></param>
        /// <param name="valueBytes"></param>
        /// <returns></returns>
        public static byte[] RijndaelEncrypt(string key, byte[] valueBytes)
        {
            byte[] keyBytes = key.GetBytes();
            return RijndaelEncrypt(keyBytes, valueBytes);
        }
        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string RijndaelEncrypt(string key, string value)
        {
            byte[] keyBytes = key.GetBytes();
            byte[] valueBytes = value.GetBytes();
            byte[] bytes = RijndaelEncrypt(keyBytes, valueBytes);
            return Convert.ToBase64String(bytes, 0, bytes.Length);
        }
        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="keyBytes"></param>
        /// <param name="valueBytes"></param>
        /// <returns></returns>
        public static byte[] RijndaelDecrypt(byte[] keyBytes, byte[] valueBytes)
        {
            //解密
            RijndaelManaged rijndael = new RijndaelManaged();
            rijndael.Key = keyBytes;
            rijndael.Mode = CipherMode.ECB;
            rijndael.Padding = PaddingMode.PKCS7;
            ICryptoTransform crypto = rijndael.CreateDecryptor();
            //解密后的数据
            return crypto.TransformFinalBlock(valueBytes, 0, valueBytes.Length);
        }
        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="key"></param>
        /// <param name="valueBytes"></param>
        /// <returns></returns>
        public static byte[] RijndaelDecrypt(string key, byte[] valueBytes)
        {
            byte[] keyBytes = key.GetBytes();
            return RijndaelDecrypt(keyBytes, valueBytes);
        }
        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string RijndaelDecrypt(string key, string value)
        {
            byte[] keyBytes = key.GetBytes();
            byte[] valueBytes = Convert.FromBase64String(value);
            byte[] bytes = RijndaelDecrypt(keyBytes, valueBytes);
            return bytes.Utf8ToStr();
        }
    }
}