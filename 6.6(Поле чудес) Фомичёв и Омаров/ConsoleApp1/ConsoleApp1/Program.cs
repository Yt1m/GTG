using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Collections.Generic;
using System.Linq;

namespace WheelOfFortuneServer
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> wordList = new List<string> { "программирование", "компьютер", "монитор", "клавиатура" };
            TcpListener server = new TcpListener(IPAddress.Any,13000);
            server.Start();
            Console.WriteLine("Сервер запущен и ожидает подключения...");

            try
            {
                while (true)
                {
                    TcpClient client = server.AcceptTcpClient();
                    Console.WriteLine("Подключен клиент. Отправка шаблона слова...");
                    Random rand = new Random();
                    string secretWord = wordList[rand.Next(wordList.Count)];
                    string wordTemplate = new string('_', secretWord.Length);
                    NetworkStream stream = client.GetStream();
                    byte[] templateData = Encoding.UTF8.GetBytes(wordTemplate);
                    stream.Write(templateData, 0, templateData.Length);

                    while (true)
                    {
                        byte[] guessData = new byte[1024];
                        int bytes = stream.Read(guessData, 0, guessData.Length);
                        string guess = Encoding.UTF8.GetString(guessData, 0, bytes).Trim();

                        if (guess.Length == 1)
                        {
                            char guessedLetter = guess[0];
                            if (secretWord.Contains(guessedLetter))
                            {
                                wordTemplate = RevealLetters(secretWord, wordTemplate, guessedLetter);
                                byte[] updatedTemplateData = Encoding.UTF8.GetBytes(wordTemplate);
                                stream.Write(updatedTemplateData, 0, updatedTemplateData.Length);
                            }
                            else
                            {
                                stream.Write(templateData, 0, templateData.Length);
                            }
                        }
                        else if (guess.Equals(secretWord, StringComparison.OrdinalIgnoreCase))
                        {
                            byte[] successMessage = Encoding.UTF8.GetBytes("Вы угадали слово!");
                            stream.Write(successMessage, 0, successMessage.Length);
                            break;
                        }
                        else
                        {
                            byte[] tryAgainMessage = Encoding.UTF8.GetBytes("Попробуйте еще раз.");
                            stream.Write(tryAgainMessage, 0, tryAgainMessage.Length);
                        }
                    }

                    client.Close();
                }
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
            }
            finally
            {
                server.Stop();
            }
        }

        static string RevealLetters(string secretWord, string wordTemplate, char guessedLetter)
        {
            return new string(secretWord.Select((c, i) => c == guessedLetter ? c : wordTemplate[i]).ToArray());
        }
    }
}
