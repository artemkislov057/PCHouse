using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestRTF_bot.model.Components;
using TestRTF_bot.Models.Accessories;

namespace TestRTF_bot.Models
{
    class ConfigurationPC
    {
        public readonly UserInformation UserInformation;
        public readonly IReadOnlyList<IComponent> Components;
        public readonly Processor Processor;
        public readonly Motherboard Motherboard;
        public readonly VideoCard VideoCard;
        public readonly RAM RAM;
        public readonly PowerModule PowerModule;
        public readonly ProcessorCooling ProcessorCooling;
        public readonly Case Case;
        public readonly Storage Storage;
        public readonly M2 M2;
        public readonly CaseCooling CaseCooling;

        // ToDo сделать так, чтобы поля заполнялись из массива
        //public ConfigurationPC(IComponent[] components)
        //{
        //    Components = components;
        //}

        public ConfigurationPC(UserInformation userInformation, Processor processor, Motherboard motherboard, VideoCard videoCard, RAM ram, PowerModule powerModule, ProcessorCooling processorCooling, Case body, Storage storage, M2 m2, CaseCooling caseCooling)
        {
            UserInformation = userInformation;
            Processor = processor;
            Motherboard = motherboard;
            VideoCard = videoCard;
            RAM = ram;
            PowerModule = powerModule;
            ProcessorCooling = processorCooling;
            Case = body;
            Storage = storage;
            M2 = m2;
            CaseCooling = caseCooling;
            Components = new IComponent[]
            {
                processor,
                motherboard,
                videoCard,
                ram,
                powerModule,
                processorCooling,
                body,
                storage,
                m2,
                caseCooling
            };
        }

        public double Rating
        {
            get
            {
                return Processor.Rating * 1.0
                    + Motherboard.Rating * 0.9
                    + VideoCard.Rating * 1.0
                    + RAM.Rating * 0.5
                    + PowerModule.Rating * 0.1
                    + ProcessorCooling.Rating * 0.05
                    + Case.Rating * 0.1
                    + Storage.Rating * 0.1
                    + M2.Rating * 0.15
                    + CaseCooling.Rating * 0.05;
            }
        }

        public int Cost => Components?.Sum(component => component.Cost) ?? 0;
    }
}
