using System;
using System.Collections.Generic;
using System.IO;
using NBitcoin;
using Nethereum.HdWallet;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Введите количество кошельков для создания: ");
        int numberOfWallets;
        while (!int.TryParse(Console.ReadLine(), out numberOfWallets) || numberOfWallets <= 0)
        {
            Console.WriteLine("Введите корректное положительное число.");
            Console.Write("Введите количество кошельков для создания: ");
        }

        List<WalletInfo> wallets = new List<WalletInfo>();

        for (int i = 0; i < numberOfWallets; i++)
        {
            // Создаем новую сид-фразу (mnemonic)
            var wallet = new Wallet(Wordlist.English, WordCount.Twelve);
            var account = wallet.GetAccount(0);

            wallets.Add(new WalletInfo
            {
                Address = account.Address,
                PrivateKey = account.PrivateKey,
                Mnemonic = string.Join(" ", wallet.Words)
            });
        }

        // Выводим информацию о кошельках в консоль и записываем в файл
        string filePath = "wallets.txt";
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            foreach (var wallet in wallets)
            {
                Console.WriteLine($"Address: {wallet.Address}");
                Console.WriteLine($"Private Key: {wallet.PrivateKey}");
                Console.WriteLine($"Mnemonic: {wallet.Mnemonic}");
                Console.WriteLine();

                // Записываем данные в файл
                writer.WriteLine($"Address: {wallet.Address}");
                writer.WriteLine($"Private Key: {wallet.PrivateKey}");
                writer.WriteLine($"Mnemonic: {wallet.Mnemonic}");
                writer.WriteLine();
            }
        }

        Console.WriteLine($"Данные о {numberOfWallets} кошельках записаны в файл: {Path.GetFullPath(filePath)}");
        Console.ReadLine(); // Чтобы консольное окно не закрывалось сразу
    }
}

public class WalletInfo
{
    public string? Address { get; set; }
    public string? PrivateKey { get; set; }
    public string? Mnemonic { get; set; }
}
