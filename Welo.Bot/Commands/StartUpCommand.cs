﻿using System;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using Welo.Application.Interfaces;

namespace Welo.Bot.Commands
{
    [Serializable]
    public class StartUpCommand :  IStartUpCommand
    {
        private readonly IStandartCommandsAppService _appService;

        public StartUpCommand(IStandartCommandsAppService appService)
        {
            _appService = appService;
        }

        public async Task StartAsync(IDialogContext context)
        {
            context.Wait(MessageReceivedAsync);
        }

        public async Task MessageReceivedAsync(IDialogContext context, IAwaitable<IMessageActivity> argument)
        {
            var message = await argument;

            var response = _appService.GetResponseMessageToTrigger(message.Text);
            if (response != null)
            {
                await context.PostAsync(response);
                context.Wait(MessageReceivedAsync);
            }
            else
            {
                await context.PostAsync("Não deu");
                context.Wait(MessageReceivedAsync);
            }
        }
    }
}