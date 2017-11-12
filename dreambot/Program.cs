using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;




namespace dreambot
{

    class Program
    {
        public static string discordToken;

        static DiscordClient discord;
        static CommandsNextModule commands;
        

        static void Main(string[] args)
        {
            MainAsync(args).ConfigureAwait(false).GetAwaiter().GetResult();
        }



        static async Task MainAsync(string[] args)
        {
            if (!File.Exists("token.txt"))
            {
                Console.WriteLine("Have you set up the token.txt?");
                Console.ReadKey();
                Environment.Exit(0);
            }

            discordToken = File.ReadAllText("token.txt");

            discord = new DiscordClient(new DiscordConfiguration()
            {
                AutomaticGuildSync = true,
                AutoReconnect = true,
                EnableCompression = true,
                LogLevel = LogLevel.Debug,
                Token = discordToken,
                TokenType = TokenType.Bot,
                UseInternalLogHandler = true
            });

            discord.MessageCreated += async e =>
            {
                if (e.Message.Content.ToLower().StartsWith("test"))
                    await e.Message.RespondAsync("123");
            };

            commands = discord.UseCommandsNext(new CommandsNextConfiguration()
            {
                CaseSensitive = false,
                EnableDefaultHelp = true,
                EnableDms = false,
                EnableMentionPrefix = true,
                SelfBot = false,
                StringPrefix = "!"
            });

            commands.RegisterCommands<UserCommands.Fun>();

            // private command check,
            Type privateCheck = Type.GetType("dreambot.PrivateCommands");

            if (privateCheck != null)
            {
                Console.WriteLine("PrivateCommand Class  loaded.");
                commands.RegisterCommands<PrivateCommands>();
            }
            else Console.WriteLine("PrivateCommand Class not loaded.");

            await discord.ConnectAsync();
            await Task.Delay(-1);
        }
    }
}
