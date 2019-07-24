﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Security.Cryptography;
using UnityEngine;

public class Decryption
{
    public static string iv = "VhErPkN0wnDKil1R";
    public static string key = "dEadT8r0K14Mrr13";

    /// <summary>
    /// 対称鍵暗号を使って文字列を暗号化する
    /// </summary>
    /// <param name="text">暗号化する文字列</param>
    /// <param name="iv">対称アルゴリズムの初期ベクター</param>
    /// <param name="key">対称アルゴリズムの共有鍵</param>
    /// <returns>暗号化された文字列</returns>
    public static string Encrypt(string text, string iv, string key)
    {
        using (RijndaelManaged rijndael = new RijndaelManaged())
        {
            rijndael.BlockSize = 128;
            rijndael.KeySize = 128;
            rijndael.Mode = CipherMode.CBC;
            rijndael.Padding = PaddingMode.PKCS7;

            rijndael.IV = Encoding.UTF8.GetBytes(iv);
            rijndael.Key = Encoding.UTF8.GetBytes(key);

            ICryptoTransform encryptor = rijndael.CreateEncryptor(rijndael.Key, rijndael.IV);

            byte[] encrypted;
            using (MemoryStream mStream = new MemoryStream())
            {
                using (CryptoStream ctStream = new CryptoStream(mStream, encryptor, CryptoStreamMode.Write))
                {
                    using (StreamWriter sw = new StreamWriter(ctStream))
                    {
                        sw.Write(text);
                    }
                    encrypted = mStream.ToArray();
                }
            }
            return (System.Convert.ToBase64String(encrypted));
        }
    }

    /// <summary>
    /// 対称鍵暗号を使って暗号文を復号する
    /// </summary>
    /// <param name="cipher">暗号化された文字列</param>
    /// <param name="iv">対称アルゴリズムの初期ベクター</param>
    /// <param name="key">対称アルゴリズムの共有鍵</param>
    /// <returns>復号された文字列</returns>
    public static string Decrypt(string cipher, string iv, string key)
    {
        using (RijndaelManaged rijndael = new RijndaelManaged())
        {
            rijndael.BlockSize = 128;
            rijndael.KeySize = 128;
            rijndael.Mode = CipherMode.CBC;
            rijndael.Padding = PaddingMode.PKCS7;

            rijndael.IV = Encoding.UTF8.GetBytes(iv);
            rijndael.Key = Encoding.UTF8.GetBytes(key);

            ICryptoTransform decryptor = rijndael.CreateDecryptor(rijndael.Key, rijndael.IV);

            string plain = string.Empty;
            using (MemoryStream mStream = new MemoryStream(System.Convert.FromBase64String(cipher)))
            {
                using (CryptoStream ctStream = new CryptoStream(mStream, decryptor, CryptoStreamMode.Read))
                {
                    using (StreamReader sr = new StreamReader(ctStream))
                    {
                        plain = sr.ReadLine();
                    }
                }
            }
            return plain;
        }
    }
}
