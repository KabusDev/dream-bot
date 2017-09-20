using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;


namespace dreambot
{
    public class UserCommands

    {
        [Command("ass"), Aliases("butt", "bum"), Description("Rates your butt")]
        public async Task ass(CommandContext ctx)
        {
            Random rand = new Random();
            List<string> buttlist = new List<string>() { "great", "nice", "good", "flat", "pancake", };

            await ctx.RespondAsync($"{buttlist[rand.Next(0, 4)]} ass, {ctx.User.Mention}!");
        }
    }
}

