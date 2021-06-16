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
                return Processor.Rating * UserInformation.TargetInterface.ProcessorRating
                    + Motherboard.Rating * UserInformation.TargetInterface.MotherboardRating
                    + VideoCard.Rating * UserInformation.TargetInterface.VideoCardRating
                    + RAM.Rating * UserInformation.TargetInterface.RAMRating
                    + PowerModule.Rating * UserInformation.TargetInterface.PowerModuleRating
                    + ProcessorCooling.Rating * UserInformation.TargetInterface.ProcessorCoolingRating
                    + Case.Rating * UserInformation.TargetInterface.CaseRating
                    + Storage.Rating * UserInformation.TargetInterface.StorageRating
                    + M2.Rating * UserInformation.TargetInterface.M2Rating
                    + CaseCooling.Rating * UserInformation.TargetInterface.CaseCoolingRating;
            }
        }

        public int Cost => Components?.Sum(component => component.Cost) ?? 0;

        public override string ToString()
        {
            var result = new StringBuilder();
            if (Processor != null)
            {
                result.Append("Процессор: ");
                result.Append(Processor.Name);
                result.Append(" [" + Processor.Cost);
                result.Append(" руб.]\n");
            }
            if (Motherboard != null)
            {
                result.Append("Материнская плата: ");
                result.Append(Motherboard.Name);
                result.Append(" [" + Motherboard.Cost + " руб.]\n");
            }
            if (VideoCard != null)
            {
                result.Append("Видеокарта: ");
                result.Append(VideoCard.Name);
                result.Append(" [" + VideoCard.Cost + " руб.]\n");
            }
            if (RAM != null)
            {
                result.Append("Оперативная память: ");
                result.Append(RAM.Name);
                result.Append(" [" + RAM.Cost + " руб.]\n");
            }
            if (Storage != null)
            {
                result.Append("Накопитель: ");
                result.Append(Storage.Name);
                result.Append(" [" + Storage.Cost + " руб.]\n");
            }
            if (M2 != null)
            {
                result.Append("SSD: ");
                result.Append(M2.Name);
                result.Append(" [" + M2.Cost + " руб.]\n");
            }
            if (CaseCooling != null)
            {
                result.Append("Охлаждение корпуса: ");
                result.Append(CaseCooling.Name);
                result.Append(" [" + CaseCooling.Cost + " руб.]\n");
            }
            if (ProcessorCooling != null)
            {
                result.Append("Охлаждение корпуса: ");
                result.Append(ProcessorCooling.Name);
                result.Append(" [" + ProcessorCooling.Cost + " руб.]\n");
            }
            if (PowerModule != null)
            {
                result.Append("Блок питания: ");
                result.Append(PowerModule.Name);
                result.Append(" [" + PowerModule.Cost + " руб.]\n");
            }
            if (Case != null)
            {
                result.Append("Корпус: ");
                result.Append(Case.Name);
                result.Append(" [" + Case.Cost + " руб.]\n");
            }
            result.Append("[Стоимость сборки " + Cost + " руб.]\n");
            if (result.Length > 0)
                result.Remove(result.Length - 1, 1);
            return result.ToString();
        }
    }
}
