using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;


namespace dreambot.UserCommands
{
    public class Fun
    {

        [Command("ass"), Aliases("butt", "bum"), Description("Rates your butt")]
        public async Task Ass(CommandContext ctx)
        {
            Random rand = new Random();
            List<string> buttlist = new List<string>() { "great", "nice", "good", "flat", "pancake", };

            await ctx.RespondAsync($"{buttlist[rand.Next(0, buttlist.Count)]} ass, {ctx.User.Mention}!");
        }

        [Command("8ball"), Aliases("8", "8b"), Description("Ask the magic 8ball!")]
        public async Task EightBall(CommandContext ctx)
        {
            Random rand = new Random();
            List<string> balls = new List<string>()
                {
                            "Signs point to yes",
                            "Yes",
                            "Reply hazy, try again",
                            "Without a doubt",
                            "My sources say no",
                            "As I see it, yes",
                            "You may rely on it",
                            "Concentrate and ask again",
                            "Outlook not so good",
                            "It is decidedly so",
                            "Better not tell you now",
                            "Very doubtful",
                            "Yes - definitely",
                            "It is certain",
                            "Cannot predict now",
                            "Most likely",
                            "Ask again later",
                            "My reply is no",
                            "Outlook good",
                            "Don't count on it",
                };
            await ctx.RespondAsync($"{balls[rand.Next(0, balls.Count)]}, {ctx.User.Mention}");
        }
    }
}

